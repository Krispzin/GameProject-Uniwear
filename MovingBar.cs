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
        public MovingBar(Vector2 position)
            : base(Color.Black, new Vector2(5, 120))
        {
            Origin = RawSize / 2;
            Position = position;
            AddAction(new Mover(this, new Vector2(300,0)));

            var collisionObj = CollisionObj.CreateWithRect(this, 2);
            Add(collisionObj);

        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            if (Position.X > 570)
                this.Detach();
        }
    }
}
