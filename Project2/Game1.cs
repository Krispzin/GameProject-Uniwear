using Game12;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class Game1 : Game2D
    {
        Actor menuScreen;
        Actor inputScreen;
            public Game1()
                : base(virtualScreenSize: new Vector2(640, 480),
                       preferredWindowSize: new Vector2(640, 480))
        {
            BackgroundColor = Color.DarkGray;
            IsFixedTimeStep = false;
        }
        protected override void LoadContent()
        {
            menuScreen = new MenuScreen(ScreenSize, ExitNotifier);
            All.Add(menuScreen);


        }

        private void ExitNotifier(Actor actor, int code)
        {
            if (actor == null)
                return;

            if (actor == menuScreen)
            {
                menuScreen.Detach();
                menuScreen = null;
                inputScreen = new InputScreen(ScreenSize, ExitNotifier);
                All.Add(inputScreen);
            }

            //if (actor == InputScreen)
            //{
            //    InputScreen.Detach();
            //    InputScreen = null;
            //    InputScreen = new MenuScreen(ScreenSize, ExitNotifier);
            //    All.Add(MenuScreen);
            //}

            else if (actor == inputScreen)
            {
                if (code == 1)
                {
                    inputScreen.Detach();
                    inputScreen = null;
                    menuScreen = new MenuScreen(ScreenSize, ExitNotifier);
                    All.Add(menuScreen);
                }
                
            }

        }
    }
}
