using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class Game1 : Game2D
    {
        Actor combatScreen, atkScreen, actScreen;
        public Game1()
            : base(virtualScreenSize: new Vector2(640, 480),
                  preferredWindowSize: new Vector2(640, 480))
        {
            BackgroundColor = Color.White;
            IsFixedTimeStep = false;
            
        }

        protected override void LoadContent()
        {
            CollisionDetectionUnit.AddDetector(1, 2);

            combatScreen = new CombatScreen(ScreenSize, ExitNotifier);
            actScreen = new ActScreen(ScreenSize, ExitNotifier);
            All.Add(actScreen);
        }

        private void ExitNotifier(Actor actor, int code)
        {
            if (actor == null)
                return;

            if (actor == combatScreen)
            {
                combatScreen.Detach();
                combatScreen = null;
                //atkScreen = new AtkScreen(ScreenSize, ExitNotifier);
                actScreen = new ActScreen(ScreenSize, ExitNotifier);
                All.Add(atkScreen);
            }else   if (actor == atkScreen)
            {
                atkScreen.Detach();
                atkScreen = null;
                combatScreen = new CombatScreen(ScreenSize, ExitNotifier);
            }else if(actor == actScreen)
            {
                actScreen.Detach();
                actScreen = null;
                combatScreen = new CombatScreen(ScreenSize, ExitNotifier);
            }
        }

        protected override void Update(float deltaTime)
        {

        }
    }
}
