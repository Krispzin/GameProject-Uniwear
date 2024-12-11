using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class DialogPanel : Actor
    {
        Placeholder placeholder = new Placeholder();
        Panel panel;
        Text text;
        string[] str;
        public DialogPanel(Vector2 position)
        {
            Position = position;

            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, "ควย") { Position = new(5, 5) };
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
        private void DialogRunner()
        {
            var keyInfo = GlobalKeyboardInfo.Value;
            if (panel.ChildCount == 0)
            {
                panel.Add(text);
                text.AddAction(new TextAnimation(text, str[0], textSpeed: 45));
            }

            if (panel.ChildCount == 1)
            {
                if (keyInfo.IsKeyPressed(Keys.Space) && (currentIndex + 1) < str.Length)
                {
                    RunDialog(currentIndex + 1);
                    currentIndex++;
                }
            }
        }

        private void RunDialog(int currentIndex)
        {
            text.ClearAction();
            text.AddAction(new TextAnimation(text, str[currentIndex], textSpeed: 45));
        }
    }
}
