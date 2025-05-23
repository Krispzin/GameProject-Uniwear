﻿using Microsoft.Xna.Framework;
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
        Mover mover;
        private float delay;
        private float delayFix;
        private bool isMoved = false;
        public MovingBar(Vector2 position, float delayTime)
            : base(Color.Black, new Vector2(5, 120))
        {

            mover = new Mover(this, new Vector2(400, 0));
            Position = position;

            delayFix = delayTime;
            //AddAction(new SequenceAction(Actions.Delay(delay),
            //                             new Mover(this,new Vector2(400,0))));
            //AddAction(new Mover(this, new Vector2(400, 0)));

            var collisionObj = CollisionObj.CreateWithRect(this, 2);
            Add(collisionObj);

        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            if (Position.X > 570)
            {
                isMoved = false;
                this.Detach();
            }


            if (!isMoved)
            {
                delay += deltaTime;
                if (delay >= delayFix)
                {
                    AddAction(mover);
                    delay -= deltaTime;
                    isMoved = true;
                }
            }
        }
    }
}
