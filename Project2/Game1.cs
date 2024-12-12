using Game12;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class Game1 : Game2D
    {
        Actor MenuScreen;
        Actor inputN;
            public Game1()
                : base(virtualScreenSize: new Vector2(640, 480),
                       preferredWindowSize: new Vector2(640, 480))
        {
            BackgroundColor = Color.DarkGray;
            IsFixedTimeStep = false;
        }
        protected override void LoadContent()
        {
            MenuScreen = new MenuScreen(ScreenSize, ExitNotifier);
            All.Add(MenuScreen);
        }

        private void ExitNotifier(Actor actor, int code)
        {
            if (actor == null)
                return;

            if (actor == MenuScreen)
            {
                MenuScreen.Detach();
                MenuScreen = null;
                inputN = new inputN(ExitNotifier);
                All.Add(inputN);
            }
            else if (actor == inputN)
            {
                inputN.Detach();
                inputN = null;
                inputN = new MenuScreen(ScreenSize, ExitNotifier);
                All.Add(MenuScreen);
            }

        }
    }
}
