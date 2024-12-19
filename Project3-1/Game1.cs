using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class Game1 : Game2D
    {
        Actor combatScreen;
        PlayerStat playerstat;
        public Game1()
            : base(virtualScreenSize: new Vector2(640, 480),
                   preferredWindowSize: new Vector2(640, 480))
        {
            BackgroundColor = Color.DarkGray;
            IsFixedTimeStep = true;
        }

        protected override void LoadContent()
        {
            //playerstat = new PlayerStat("playerName", 20, 20, 5);
            CollisionDetectionUnit.AddDetector(1, 2);

            combatScreen = new CombatScreen(ScreenSize, ExitNotifier);
            All.Add(combatScreen);
        }
        private void ExitNotifier(Actor actor, int code)
        {
            if (actor == null)
                return;
        }

    }
}
