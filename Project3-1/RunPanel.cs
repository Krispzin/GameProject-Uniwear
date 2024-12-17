using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class RunPanel : Actor
    {
        Placeholder placeholder = new Placeholder();
        TextAnimation textAnimation;
        Panel panel;
        Text text;
        string[] str;
        public bool finished = false;

        public RunPanel(Vector2 position)
        {
            Position = position;
            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, "") { Position = new(5, 5) };
            str = ["เห้ย นิสิตจะไปไหน"];


            panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);
            panel.Add(text);


            placeholder.Add(panel);
            Add(placeholder);
        }

        private int currentIndex = 0;

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            DialogRunner();
        }

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
            }
        }

        private void RunDialog()
        {
            text.ClearAction(); // Clear any previous animations
            text.AddAction(textAnimation = new TextAnimation(text, str[currentIndex], textSpeed: 45));
            currentIndex++;
        }
        private void ExitApp()
        {
            Debug.WriteLine("Exit the Game");

        }

    }
}
