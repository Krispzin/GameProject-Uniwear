using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class PlayerStat
    {
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int HpMax { get; private set; }
        public int Strength { get; private set; }
        public List<string> Actions { get; set; }
        public PlayerStat(string name, int hpMax, int hp, int strength)
        {
            Name = name;
            HpMax = hpMax;
            Hp = hp;
            Strength = strength;
            Actions = new List<string>();
        }
    }
}
