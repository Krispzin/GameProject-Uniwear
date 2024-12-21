using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;
using Microsoft.Xna.Framework;
using System.Reflection.Emit;

namespace Project2
{
    public class PlayerStat : Actor
    {
        public string Name { get; private set; }
        public int Hp { get; set; }
        public int HpMax { get; private set; }
        public int Strength { get; private set; }
        Placeholder placeholder = new Placeholder();
        public ProgressBar HpBar;
        Text nameLabel, hpLabel;
        public PlayerStat(string name, int hpMax, int hp, int strength, Vector2 position)
        {
            Name = name;
            HpMax = hpMax;
            Hp = hp;
            Strength = strength;
            //Position = position;

            nameLabel = new Text("ChakraPetch-Bold.ttf", 20, Color.Black, Name);
            nameLabel.Position = position;

            hpLabel = new Text("ChakraPetch-Bold.ttf", 20, Color.Black, "HP:");
            hpLabel.Position = new Vector2(nameLabel.Position.X + nameLabel.RawSize.X + 10, nameLabel.Position.Y);

            HpBar = new ProgressBar(size: new Vector2(200, 20), max: HpMax, Color.Black, Color.Green);
            HpBar.Value = Hp;
            HpBar.Position = new Vector2(hpLabel.Position.X + hpLabel.RawSize.X + 5, hpLabel.Position.Y);

            placeholder.Add(nameLabel);
            placeholder.Add(hpLabel);
            placeholder.Add(HpBar);
            Add(placeholder);
        }

        public void updateHp(int updatedHp)
        {
            //while (HpBar.Value != updatedHp)
            //{
            //    HpBar.Value -= 1;
            //}
            this.HpBar.Value = updatedHp;
        } 
    }
}
