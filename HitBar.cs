using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class HitBar : RectangleActor
    { 
        public CollisionObj hitCollisionObj;
        public int hitTimes;
        SoundEffect hitSound;
        SpriteActor hitTreshhold;
        public HitBar(Vector2 ScreenSize)
            : base(Color.LightGray, new Vector2(3, 125))
        {
            hitTreshhold = new SpriteActor();
            hitTreshhold.SetTexture(TextureCache.Get("Content/resource/img/barTreshold.png"));
            hitSound = SoundEffect.FromFile("Content/resource/song/Deflect.wav");

            Position = ScreenSize;

            hitTimes = 0;

            hitCollisionObj = CollisionObj.CreateWithRect(this, RawRect.CreateAdjusted(6.66f, 1f),1);
            hitCollisionObj.OnCollide = OnCollide;
            hitCollisionObj.DebugDraw = true;
            //Add(collisionObj);
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            var keyInfo = GlobalMouseInfo.Value;

            if (keyInfo.IsRightButtonPressed())
            {
                Add(hitCollisionObj);
                Add(hitTreshhold);
            }
            else
            {
                Remove(hitCollisionObj);
                Remove(hitTreshhold);
            }
        }

        public void OnCollide(CollisionObj objB, CollideData collideData)
        {
            var movingBar = objB.Actor as MovingBar;
            movingBar?.Detach();
            hitSound.Play();
            hitTimes++;
            Debug.WriteLine(hitTimes.ToString());
        }
    }
}
