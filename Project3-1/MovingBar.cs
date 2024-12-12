using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class MovingBar : RectangleActor
    {
        public MovingBar(Vector2 position, float delay)
            : base(Color.Black, new Vector2(5, 120))
        {
            Position = position;
            //AddAction(new SequenceAction(Actions.Delay(delay),
            //                             new Mover(this,new Vector2(400,0))));
            AddAction(new Mover(this, new Vector2(400, 0)));

            var collisionObj = CollisionObj.CreateWithRect(this, 2);
            Add(collisionObj);

        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            //if (Position.X > 570)
            //    this.Detach();
        }
    }
}
