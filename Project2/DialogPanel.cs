using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        Placeholder placeholder = new Placeholder();
        TextAnimation textAnimation;
        Panel panel;
        Text text;
        string[] str;
        public bool finished = false;
        public DialogPanel(Vector2 position)
        {
            Position = position;
            
            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, "") { Position = new(5, 5) };
            str = ["ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd", "3 asdasdasdasdasd"];

            panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);

            placeholder.Add(panel);
            Add(placeholder);
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
;           }
        }

        private void RunDialog()
        {
            text.ClearAction();
            text.AddAction(textAnimation = new TextAnimation(text, str[currentIndex], textSpeed: 45));
            currentIndex++;
        }
    }
}
