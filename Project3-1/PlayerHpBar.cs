using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class PlayerHpBar : Actor
    {
        ProgressBar hpBarPlayer;
        PlayerStat player;
        public PlayerHpBar(Vector2 position, int HpMax)
        {
            hpBarPlayer = new ProgressBar(new Vector2(20, 120), HpMax, Color.Green, Color.Black);
            hpBarPlayer.Value = player.Hp;
            hpBarPlayer.Position = position;
        }
    }
}
