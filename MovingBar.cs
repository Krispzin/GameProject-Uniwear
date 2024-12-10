using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class MovingBar : RectangleActor
    {
        private float delayTime = 0;
        private float delayFix = 0;
        public MovingBar(Vector2 position, float delay)
            : base(Color.Black, new Vector2(5, 120))
        {
            delayTime = delay;
            Origin = RawSize / 2;
            Position = position;
            AddAction(new SequenceAction(Actions.Delay(delay),
                                         new Mover(this,new Vector2(400,0))));

            var collisionObj = CollisionObj.CreateWithRect(this, 2);
            Add(collisionObj);

        }

        public override void Act(float deltaTime)
        {
            delayTime += deltaTime;

            base.Act(deltaTime);
            if (Position.X > 570)
                this.Detach();
        }
    }
}
