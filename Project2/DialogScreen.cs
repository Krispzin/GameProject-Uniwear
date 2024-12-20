using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project3_1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class DialogPanel : Actor
    {
        ExitNotifier exitNotifier;
        TextAnimation textAnimation;
        Panel panel;
        Text text;
        string[] str;
        public bool finished = false;
        public DialogPanel(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            //ScreenSizen = screenSize;

            this.exitNotifier = exitNotifier;
            var bg = new BG(new Vector2(10, 60)); 

            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, "") { Position = new(5, 5) };
            str = ["Dialog lorem1", "Dialog lorem2", "Dialog lorem3"];

            panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);
            panel.Position = new Vector2(30, 300);
            Add(bg);
            Add(panel);

        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            DialogRunner();
        }

        private int currentIndex = 0;
        public void DialogRunner()
        {
            var keyInfo = GlobalKeyboardInfo.Value;
            if (panel.ChildCount == 0)
            {
                panel.Add(text);
                RunDialog();
            }

            if (panel.ChildCount == 1)
            {
                if (keyInfo.IsKeyPressed(Keys.Space) && (currentIndex) < str.Length)
                {
                    RunDialog();
                }
            }

            if (currentIndex >= str.Length && (textAnimation == null || textAnimation.IsFinished()))
            {
                finished = true;
                Debug.WriteLine(this.finished);
                ;
            }
        }

        private void RunDialog()
        {
            text.ClearAction();
            text.AddAction(textAnimation = new TextAnimation(text, str[currentIndex], textSpeed: 45));
            currentIndex++;
        }
    }
}