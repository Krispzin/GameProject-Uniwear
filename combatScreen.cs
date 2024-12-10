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
        public CombatScreen(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, " ") { Position = new(5, 5) };
            str = ["ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd", "3 asdasdasdasdasd"];

            var panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);
            panel.Position = new Vector2(30, 240);

            panel.Add(text);

            var playerState = new Player(new Vector2(30, 390));
            Add(playerState);

            atkBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ATTACK", new Vector2(175, 40));
            atkBtn.Position = new Vector2(30, 420);
            placeholder.Add(atkBtn);


            actBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ACT", new Vector2(175, 40));
            actBtn.Position = new Vector2(ScreenSize.X / 2, 420);
            actBtn.Origin = new Vector2(actBtn.RawSize.X / 2, 0);
            placeholder.Add(actBtn);

            runBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "RUN", new Vector2(175, 40));
            runBtn.Position = new Vector2(610, 420);
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

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (text.Str == str[i])
                {
                    if (keyInfo.IsKeyPressed(Keys.Space))
                    {
                        {
                            this.AddAction(new TextAnimation(text, str[i + 1], textSpeed: 45));
                            break;
                        }
                    }
                }
            }

            atkBtn.ButtonClicked += atkEvent;
            actBtn.ButtonClicked += ActBtn_ButtonClicked;
        }

        private void ActBtn_ButtonClicked(GenericButton button)
        {
            exitNotifier(this, 0);
        }

        private void atkEvent(GenericButton button)
        {
            exitNotifier(this, 0);
        }
    }
}
