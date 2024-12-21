using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;
using Microsoft.Xna.Framework;
using System.Reflection.Emit;

namespace Project3_1
{
    public class Enemy : SpriteActor
    {
        public string Name { get; private set; }
        public int Hp { get; set; }
        public int HpMax { get; private set; }
        public int Strength { get; private set; }
        ProgressBar HpBar;
        public Enemy(Vector2 position)
        {
            Name = "Spin";
            HpMax = 100;
            Hp = 100;
            Strength = 2;

            var texture = TextureCache.Get("Spin_Fight.png");
            SetTexture(texture);
            Origin = RawSize / 2;
            Position = position;

            HpBar = new ProgressBar(size: new Vector2(200, 20), max: HpMax, Color.Black, Color.Green);
            HpBar.Value = Hp;
            //HpBar.Origin = RawSize / 2;
            HpBar.Position = new Vector2((position.X / 2) + 50, (position.Y/2) + 120);
            
            Add(HpBar);
        }

        public void updateHp(int updatedHp)
        {
            //Add(HpBar);
            //while (HpBar.Value != updatedHp)
            //{
            //    HpBar.Value -= 1;
            //    //if (HpBar.Value == updatedHp)
            //    //    HpBar.Detach();
            //}
            HpBar.Value = updatedHp;
        }
    }
}
