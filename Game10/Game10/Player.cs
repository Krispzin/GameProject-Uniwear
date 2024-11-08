using Microsoft.Xna.Framework;
using ThanaNita.MonoGameTnt;

namespace Game10
{
    public class Player : SpriteActor
    {
        AnimationStates states;
        public Player()
        {
            var texture = TextureCache.Get("walk.png");
            var idle = TextureCache.Get("idle.png");
            SetTextureRegion(new TextureRegion(texture, new RectF(0, 0, 64,128)));
            SetTextureRegion(new TextureRegion(idle, new RectF(0, 0, 64, 128)));
            Origin = new Vector2(32, 100);
            Scale = new Vector2(2, 2);

            var regions2d = RegionCutter.Cut(texture, 64, 128);
            var selector = new RegionSelector(regions2d);


            var regions2di = RegionCutter.Cut(idle, 64, 128);
            var selectori = new RegionSelector(regions2di);

            var stay = new Animation(this, 1.0f, selectori.Select(start: 0, count: 8));
            var left = new Animation(this, 0.5f, selector.Select(start: 10, count: 10));
            var right = new Animation(this, 0.5f, selector.Select(start: 20, count: 10));
            var up = new Animation(this, 0.5f, selector.Select(start: 30, count: 10));
            var down = new Animation(this, 0.5f, selector.Select(start: 0, count: 10));
            states = new AnimationStates([stay, left, right, up, down]);
            AddAction(states);
        }

        public override void Act(float deltaTime)
        {
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
    }
}
