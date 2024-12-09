using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class Game1 : Game2D
    {
        public Game1()
            : base(virtualScreenSize: new Vector2(640, 480),
                  preferredWindowSize: new Vector2(640, 480))
        {
            BackgroundColor = Color.White;
            IsFixedTimeStep = false;
        }

        Text text;
        Placeholder placeholder = new Placeholder();
        string[] str;
        protected override void LoadContent()
        {
            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, " ") { Position = new(5, 5) };
            str = ["ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd", "3 asdasdasdasdasd"];

            var panel = new Panel(new Vector2(580, 150), Color.White, Color.Black, 2);
            panel.Position = new Vector2(30, 240);
            
            //panel.Add(text);

            var atkBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ATTACK", new Vector2(175, 60));
            atkBtn.Position = new Vector2(30, 400);
            placeholder.Add(atkBtn);

            var actBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ACT", new Vector2(175, 60));
            actBtn.Position = new Vector2(ScreenSize.X / 2, 400);
            actBtn.Origin = new Vector2(actBtn.RawSize.X / 2, 0);
            placeholder.Add(actBtn);

            var runBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "RUN", new Vector2(175, 60));
            runBtn.Position = new Vector2(610, 400);
            runBtn.Origin = new Vector2(runBtn.RawSize.X, 0);
            placeholder.Add(runBtn);

            placeholder.Add(panel);
            

            All.Add(placeholder);
            
            All.Add(new MovingBar(All, new Vector2(30, 420)));
        }

        protected override void Update(float deltaTime)
        {

            var keyInfo = GlobalKeyboardInfo.Value;
            if (text.Str == " ")
            {
                text.AddAction(new TextAnimation(text, str[0], textSpeed: 45));
            }

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (text.Str == str[i])
                {
                    if (keyInfo.IsKeyPressed(Keys.Space))
                        text.AddAction(new TextAnimation(text, str[i+1], textSpeed: 45));
                }
            }
            
        }
    }
}
