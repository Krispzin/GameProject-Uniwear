using Game12;
using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;
using ThanaNita.MonoGameTnt;
using Microsoft.Xna.Framework.Input;

namespace Project2
{
    public class TextInput : Actor 
    {
        Text text;
        ExitNotifier exitNotifier;
        public TextInput(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            



        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            var keyInfo = GlobalKeyboardInfo.Value;
            if (keyInfo.IsKeyPressed(Keys.Enter))
            {

            }


        }







    }
}
