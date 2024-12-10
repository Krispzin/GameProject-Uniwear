using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class HitBar : RectangleActor
    {
        public CollisionObj collisionObj;
        public HitBar(Vector2 ScreenSize)
            : base(Color.LightGray, new Vector2(3, 125))
        {
            Origin = RawSize / 2;
            Position = ScreenSize;

            collisionObj = CollisionObj.CreateWithRect(this, RawRect.CreateAdjusted(4f, 1f),1);
            collisionObj.OnCollide = OnCollide;
            collisionObj.DebugDraw = true;
            //Add(collisionObj);
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            var keyInfo = GlobalMouseInfo.Value;

            if (keyInfo.IsRightButtonPressed())
            {
                Add(collisionObj);
            }
            else
            {
                Remove(collisionObj);
            }
        }

        public void OnCollide(CollisionObj objB, CollideData collideData)
        {
            var movingBar = objB.Actor as MovingBar;
            movingBar?.Detach();
        }
    }
}
