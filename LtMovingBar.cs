using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    //public class LtMovingBar : Actor
    //{
    //    public LtMovingBar(Vector2 position)
    //    {
    //        Add(new MovingBar(position, 0f));
    //        Add(new MovingBar(position, 0.3f));
    //        Add(new MovingBar(position, 0.6f));
    //    }

    //}
    public class LtMovingBar : Actor
    {
        private Player player;
        private int damage;

        public LtMovingBar(Vector2 position, Player player, int damage)
        {
            this.player = player;
            this.damage = damage;

            Add(new MovingBar(position, 0f, player, damage));
            Add(new MovingBar(position, 0.3f, player, damage));
            Add(new MovingBar(position, 0.6f, player, damage));
        }
    }
}
