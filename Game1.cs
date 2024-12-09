using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class Game1 : Game2D
    {
        Actor combatScreen, atkScreen;
        public Game1()
            : base(virtualScreenSize: new Vector2(640, 480),
                  preferredWindowSize: new Vector2(640, 480))
        {
            BackgroundColor = Color.White;
            IsFixedTimeStep = false;
        }

        protected override void LoadContent()
        {
            combatScreen = new CombatScreen(ScreenSize, ExitNotifier);
            All.Add(combatScreen);
        }

        private void ExitNotifier(Actor actor, int code)
        {
            if (actor == null)
                return;

            if (actor == combatScreen)
            {
                combatScreen.Detach();
                combatScreen = null;
                atkScreen = new AtkScreen(ExitNotifier);
                All.Add(atkScreen);
            }
        }

        protected override void Update(float deltaTime)
        {

        }
    }
}
