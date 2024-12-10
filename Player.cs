using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class Player : Actor
    {
        Text name, hpLabel;
        ProgressBar hpBar;
        public Player(Vector2 position)
        {
            var playerName = "playerName";
            var maxHealth = 20;
            var currentHealth = 20;
            var damage = 5;

            name = new Text("ChakraPetch-Bold.ttf", 20, Color.Black, playerName + "     ");
            name.Position = position;

            hpLabel = new Text("ChakraPetch-Bold.ttf", 20, Color.Black, "HP: ");

            hpBar = new ProgressBar(size: new Vector2(200, 20), max: maxHealth, Color.Black, Color.Green);
            hpBar.Value = currentHealth;

            Alignment.SetPosition(name, hpLabel, AlignDirection.Right);
            Alignment.SetPosition(hpLabel, hpBar, AlignDirection.Right);
            Add(name);
            Add(hpLabel);
            Add(hpBar);
        }
    }
}
