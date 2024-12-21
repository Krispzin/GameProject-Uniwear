using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class BG : SpriteActor
    {
        public BG(Vector2 position)
        {
            var texture = TextureCache.Get("Content/resource/img/Spinmap2.jpeg");
            SetTexture(texture);
            Origin = RawSize / 2;
            Position = position;
        }
    }
}
