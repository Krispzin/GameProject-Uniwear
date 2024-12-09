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
        public MovingBar(Actor all, Vector2 ScreenSize)
            : base(Color.Black, new Vector2(8, 80))
        {
            Origin = RawSize / 2;
            Position = ScreenSize;

            AddAction(new Mover(this, new Vector2(300, 0)));

            //var collisionObj = CollisionObj.CreateWithRect(this, 1);
            //collisionObj.Position = OnCollide;
            //Add(collisionObj);
            //collisionObj.DebugDraw = true;
        }

        //public void OnCollide(CollisionObj objB, CollisionObj data)
        //{
        //    var hitBar = objB.Actor as hitBar;
        //    hitBar?.Detach();
        //}

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            if (Position.X < 600)
                this.Detach();
        }
    }
}
