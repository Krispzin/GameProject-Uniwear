using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;
using static System.Net.Mime.MediaTypeNames;
using Text = ThanaNita.MonoGameTnt.Text;

namespace Project2
{
    public class CombatScreen : Actor
    {
        ExitNotifier exitNotifier;
        Text text;
        Placeholder placeholder = new Placeholder();
        Button atkBtn, actBtn, runBtn;
        string[] str;
        bool dialogDone = false;
        public CombatScreen(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, " ") { Position = new(5, 5) };
            str = ["ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd", "3 asdasdasdasdasd"];

            var panel = new Panel(new Vector2(580, 150), Color.White, Color.Black, 2);
            panel.Position = new Vector2(30, 240);

            panel.Add(text);

            atkBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ATTACK", new Vector2(175, 60));
            atkBtn.Position = new Vector2(30, 400);
            placeholder.Add(atkBtn);


            actBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ACT", new Vector2(175, 60));
            actBtn.Position = new Vector2(ScreenSize.X / 2, 400);
            actBtn.Origin = new Vector2(actBtn.RawSize.X / 2, 0);
            placeholder.Add(actBtn);

            runBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "RUN", new Vector2(175, 60));
            runBtn.Position = new Vector2(610, 400);
            runBtn.Origin = new Vector2(runBtn.RawSize.X, 0);
            placeholder.Add(runBtn);

            placeholder.Add(panel);
            Add(placeholder);   
            text.AddAction(new TextAnimation(text, str[0], textSpeed: 45));

        }



        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            var keyInfo = GlobalKeyboardInfo.Value;
            if (!dialogDone)
            {
                for (int i = 0; i < str.Length - 1; i++)
                {
                    if (text.Str == str[i])
                    {
                        if (keyInfo.IsKeyPressed(Keys.Space))
                        {
                            if (i == str.Length)
                            {
                                dialogDone = true;
                            }
                            else
                            {
                                this.AddAction(new TextAnimation(text, str[i + 1], textSpeed: 45));
                                break;
                            }
                        }
                    }
                }
            }

            atkBtn.ButtonClicked += atkEvent;

            if (dialogDone == true)
            {
                exitNotifier(this, 0);
            }

        }

        private void atkEvent(GenericButton button)
        {
            dialogDone = true;
        }
    }
}
