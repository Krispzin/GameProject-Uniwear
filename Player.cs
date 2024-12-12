using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    //public class Player : Actor
    //{
    //    Text name, hpLabel;
    //    ProgressBar hpBar;
    //    public Player(Vector2 position)
    //    {
    //        var playerName = "playerName";
    //        var maxHealth = 20;
    //        var currentHealth = 20;
    //        var damage = 5;

    //        name = new Text("ChakraPetch-Bold.ttf", 20, Color.Black, playerName + "     ");
    //        name.Position = position;

    //        hpLabel = new Text("ChakraPetch-Bold.ttf", 20, Color.Black, "HP: ");

    //        hpBar = new ProgressBar(size: new Vector2(200, 20), max: maxHealth, Color.Black, Color.Green);
    //        hpBar.Value = currentHealth;

    //        Alignment.SetPosition(name, hpLabel, AlignDirection.Right);
    //        Alignment.SetPosition(hpLabel, hpBar, AlignDirection.Right);
    //        Add(name);
    //        Add(hpLabel);
    //        Add(hpBar);
    //    }
    //}

    public class Player : Actor
    {
        Text name, hpLabel;
        ProgressBar hpBar;
        private int currentHealth;
        private int maxHealth;

        public Player(Vector2 position)
        {
            var playerName = "playerName";
            maxHealth = 20;
            currentHealth = 20;

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

        // Method to apply damage
        public void ApplyDamage(int damage)
        {
            currentHealth -= damage;
            currentHealth = Math.Max(0, currentHealth); // Prevent health from going negative
            hpBar.Value = currentHealth;

            if (currentHealth <= 0)
            {
                // Handle player death (optional)
                Console.WriteLine("Player is dead!");
            }
        }
    }

}
