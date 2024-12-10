using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;
using static System.Net.Mime.MediaTypeNames;
using Text = ThanaNita.MonoGameTnt.Text;

namespace Project2
{
    public class AtkScreen : Actor
    {
        ExitNotifier exitNotifier;
        public AtkScreen(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            var panel = new Panel(new Vector2(580, 150), Color.White, Color.Black, 2);
            panel.Position = new Vector2(30, 240);
            panel.Add(new HitBar(panel.RawSize / 2));
            panel.Add(new MovingBar(new Vector2(10, panel.RawSize.Y / 2)));

            Add(panel);

            //atkBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ATTACK", new Vector2(175, 60));
            //atkBtn.Position = new Vector2(30, 400);
            //placeholder.Add(atkBtn);


            //actBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ACT", new Vector2(175, 60));
            //actBtn.Position = new Vector2(ScreenSize.X / 2, 400);
            //actBtn.Origin = new Vector2(actBtn.RawSize.X / 2, 0);
            //placeholder.Add(actBtn);

            //runBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "RUN", new Vector2(175, 60));
            //runBtn.Position = new Vector2(610, 400);
            //runBtn.Origin = new Vector2(runBtn.RawSize.X, 0);
            //placeholder.Add(runBtn);
        }


    }
}
