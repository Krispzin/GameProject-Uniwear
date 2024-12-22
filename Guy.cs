using Game10;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
using System.Linq;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class Guy : SpriteActor
    {
        AnimationStates states;
        public delegate void TileCollisionHandler(int tileX, int tileY, TileMap currentCollisionMap);
        public event TileCollisionHandler OnTileCollision;
        

        public Guy(TileMap tileMap)
        {
            //var texture = TextureCache.Get("Guy.png");
            var texture = TextureCache.Get("Content/resource/img/char1.png");
            SetTextureRegion(new TextureRegion(texture, new RectF(0, 0, 32, 32)));

            Origin = new Vector2(16, 50);
            Scale = new Vector2(1, 1);


            var regions2d = RegionCutter.Cut(texture, 32, 64);
            var selector = new RegionSelector(regions2d);



            var stay = new Animation(this, 2.0f, selector.Select(start: 74, count: 6));
            var left = new Animation(this, 0.5f, selector.Select(start: 124, count: 6));
            var right = new Animation(this, 0.5f, selector.Select(start: 112, count: 6));
            var up = new Animation(this, 0.5f, selector.Select(start: 118, count: 6));
            var down = new Animation(this, 0.5f, selector.Select(start: 130, count: 6));
            states = new AnimationStates([stay, left, right, up, down]);
            AddAction(states);
            player = this;
            this.tileMap = tileMap;
        }

        KeyQueue keyQueue = new KeyQueue();
        LinearMotion motion = LinearMotion.Empty();

        Actor player;
        private TileMap tileMap;
        public int[] ProhibitTiles { get; set; } = [0];

        public void SetCollisionMap(TileMap newCollisionMap)
        {
            this.tileMap = newCollisionMap;
        }
        public override void Act(float deltaTime)
        {
            var keyInfo = GlobalKeyboardInfo.Value;
            //keyQueue.EnqueueAll(keyInfo.GetPressedKeys());

            motion.Act(deltaTime);
            SmoothMovement();

            //StepJumpMovement();
            base.Act(deltaTime);
            var direction = DirectionKey.Normalized;
            //Position += 500 * direction * deltaTime;
            if (direction.X > 0)
                states.Animate(2); // right
            else if (direction.X < 0)
                states.Animate(1); // left
            else if (direction.Y < 0)
                states.Animate(3); // up
            else if (direction.Y > 0)
                states.Animate(4); // down
            else
                states.Animate(0); // stay
        }
        private void SmoothMovement()
        {
            if (!motion.IsFinished()) // ถ้าไม่มีบรรทัดนี้ จะกดคีย์ใหม่ก่อนเคลื่อนที่เสร็จได้ 
            {
                var command1 = keyQueue.PeekCommand();
                if (command1.IsOpposite(motion.Direction))
                    UnstableMoveOpposite(keyQueue.GetCommand().Direction);
                return;
            }

            var command = keyQueue.GetCommand();
            Vector2 direction = Vector2.Zero;
            if (command.HasCommand())
                direction = command.Direction;
            else
            {
                direction = DirectionKey.Direction4;
            //    if (DirectionKey.Direction4 == Vector2.Zero)
            //        direction = motion.Direction;
            }

            StableMove(direction);
        }

        private void StableMove(Vector2 direction)
        {
            if (!IsAllowMove(direction))
                direction = new Vector2(0, 0);

            if (motion.Direction == Vector2.Zero && direction == Vector2.Zero)
                return; // ถ้าหยุดอยู่แล้ว ไม่ต้องหยุดซ้ำ

            if (direction != motion.Direction)
                motion.ToPreciseTarget(); // ปรับตำแหน่งให้พอดีศูนย์กลาง (กรณี FPS ต่ำๆ)

            CreateMotion(player.Position, direction);
        }

        private void UnstableMoveOpposite(Vector2 direction)
        {
            CreateMotion(motion.TargetPosition, direction);
        }
        private void CreateMotion(Vector2 oldPosition, Vector2 direction)
        {
            var targetPosition = tileMap.TileCenter(oldPosition, direction);
            motion = new LinearMotion(player, speed: 150, targetPosition, direction);
        }

        //private void StepJumpMovement()
        //{
        //    var keyInfo = GlobalKeyboardInfo.Value;
        //    if (!keyInfo.IsAnyKeyPressed())
        //        return;

        //    var key = keyInfo.GetPressedKeys()[0];
        //    var direction = DirectionKey.DirectionOf(key);
        //    if (!IsAllowMove(direction))
        //        return;
        //    player.Position += direction * tileMap.TileSize;
        //}

        private bool IsAllowMove(Vector2 direction)
        {
            Vector2i index = tileMap.CalcIndex(player.Position, direction);
            return tileMap.IsInside(index) && IsAllowTile(index);
        }

        //private bool IsAllowTile(Vector2i index)
        //{
        //    if (ProhibitTiles == null)
        //        return true;

        //    int tileCode = tileMap.GetTileCode(index);

        //    // Raise the tile collision event
        //    OnTileCollision?.Invoke(index.X, index.Y, tileMap);

        //    return !ProhibitTiles.Contains(tileCode);
        //}
        private bool IsAllowTile(Vector2i index, bool isMapTransition = false)
        {
            if (ProhibitTiles == null || isMapTransition)
                return true;

            int tileCode = tileMap.GetTileCode(index);

            // Raise the tile collision event
            OnTileCollision?.Invoke(index.X, index.Y, tileMap);

            return !ProhibitTiles.Contains(tileCode);
        }
        public void ForcePosition(Vector2 newPosition)
        {
            // Bypass all movement and collision checks
            Position = newPosition;

            // Reset motion to ensure smooth movement after positioning
            motion = LinearMotion.Empty();
        }
    }
}
