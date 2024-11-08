//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Linq;
//using ThanaNita.MonoGameTnt;

//namespace Game10
//{
//    public class Game101 : Game2D
//    {
//        TextureRegion[] tiles;
//        TileMap tileMap;
//        Player player;
        
//        protected override void LoadContent()
//        {
//            var tileSize = new Vector2(128, 128);
//            BackgroundColor = Color.White;
//            player = new Player() { Position = tileSize / 2 };

//            PrepareTileSet();
//            var tileArray = new int[6, 6]{
//                {2,2,3,3,2,2},
//                {3,1,1,3,24,25},
//                {2,2,1,2,36,35},
//                {2,1,1,120,121,122 },
//                {2,1,1,134,135,136 },
//                {2,2,1,148,149,150 }
//            };
//            tileMap = new TileMap(tileSize, tileArray, CreateTile);

//            var visual = new Actor() { Position = new Vector2(200, 200) };
//            visual.Add(tileMap);
//            visual.Add(player);
//            All.Add(visual);
//        }

//        private void PrepareTileSet()
//        {
//            var texture = TextureCache.Get("TileSet.png");
//            var tiles2d = RegionCutter.Cut(texture, new Vector2(32, 32), countX: 14,countY: 25 );
//            tiles = RegionSelector.SelectAll(tiles2d);

//        }
        
//        private Actor CreateTile(int tileCode)
//        {
//            var sprite = new SpriteActor(tiles[tileCode]);
//            sprite.Origin = sprite.RawSize / 2;
//            sprite.Scale = new Vector2(4, 4);
//            return sprite;

//        }
//        KeyQueue keyQueue = new KeyQueue();
//        LinearMotion motion = LinearMotion.Empty();

//        protected override void Update(float deltaTime)
//        {
//            var keyinfo = GlobalKeyboardInfo.Value;
//            keyQueue.EnqueueAll(keyinfo.GetPressedKeys());
            
//            motion.Act(deltaTime);
//            SmoothMovement();
            
//            //StepJumpMovement();

//        }

//        private void SmoothMovement()
//        {
//            if (!motion.IsFinished())
//            {
//                var command1 = keyQueue.PeekCommand();
//                if (command1.IsOpposite(motion.Direction))
//                    UnstableMoveOpposite(keyQueue.GetCommand().Direction);
                
//                return;
//            }
//            var command = keyQueue.GetCommand();
//            var direction = Vector2.Zero; //new Vector2(();
//            if (command.HasCommand())
//            {
//                direction = command.Direction;
//            }
//             else
//             {
//                 direction = DirectionKey.Direction4; // 2.8 key down ค้างไว้ได้

//                 if(direction == Vector2.Zero)
//                 {
//                     direction = motion.Direction;
//                 }

//             }


//            //CreateMotion(player.Position, direction);
//            StableMove(direction);
//        }

//        private void UnstableMoveOpposite(Vector2 direction)
//        {
//            CreateMotion(motion.TargetPosition, direction);
//        }

//        private void StableMove(Vector2 direction)
//        {
//            if (!IsAllowMove(direction))
//            {
//                direction = Vector2.Zero;
//            }
//            if(motion.Direction == Vector2.Zero && direction == Vector2.Zero)
//            {
//                return;
//            }
//            CreateMotion(player.Position, direction);
//        }

//        private void StepJumpMovement()
//        {
//            var keyInfo = GlobalKeyboardInfo.Value;
//            if (!keyInfo.IsAnyKeyPressed()) {
//                return;
            
//            }
//            var key = keyInfo.GetPressedKeys()[0];
//            var direction = DirectionKey.DirectionOf(key);
//            if (!IsAllowMove(direction))
//            {
//                return;
//            }

//            player.Position += direction * tileMap.TileSize;


           
//        }

//        private void CreateMotion(Vector2 oldPosition, Vector2 direction)
//        {
//            var targetPosition = tileMap.TileCenter(oldPosition, direction);
//            motion = new LinearMotion(player, speed: 300, targetPosition, direction);

//        }
//        private bool IsAllowMove(Vector2 direction)
//        {
//            Vector2i index = tileMap.CalcIndex(player.Position, direction);
//            return tileMap.IsInside(index) && IsAllowTile(index);
//        }
//        private bool IsAllowTile(Vector2i index)
//        {
//            var tileCode = tileMap.GetTileCode(index);
//            var notAllowedTiles = new int[] { 2, 3 };
//            return !notAllowedTiles.Contains(tileCode);
//        }
//    }
//}