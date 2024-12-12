using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class DetBar : RectangleActor
    {
        public CollisionObj detCollisionObj;
        HitBar hitBar;

        public DetBar(Vector2 position)
            : base(Color.Transparent, new Vector2(3, 125))
        {
            Position = position;

            detCollisionObj = CollisionObj.CreateWithRect(this, 1);
            detCollisionObj.OnCollide = OnCollide;
            detCollisionObj.DebugDraw = true;
            Add(detCollisionObj);
        }

        public void OnCollide(CollisionObj objB, CollideData collideData)
        {
            var movingBar = objB.Actor as MovingBar;
            movingBar?.Detach();
            hitBar.hitTimes++;
        }

    }
}
