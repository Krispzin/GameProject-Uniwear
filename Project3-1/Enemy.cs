using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;
using Microsoft.Xna.Framework;

namespace Project3_1
{
    public class Enemy : SpriteActor
    {
        public Enemy(Vector2 position)
        {
            var texture = TextureCache.Get("Spin_Fight.png");
            SetTexture(texture);
            Origin = RawSize / 2;
            Position = position;
        }
    }
}
