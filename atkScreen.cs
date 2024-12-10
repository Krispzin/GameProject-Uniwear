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
        Placeholder placeholder = new Placeholder();
        Button atkBtn, actBtn, runBtn;
        Panel panel;
        public AtkScreen(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);
            panel.Position = new Vector2(30, 240);
            panel.Add(new HitBar(panel.RawSize / 2));
            panel.Add(new MovingBar(new Vector2(10, panel.RawSize.Y / 2)));

            var playerStat = new Player(new Vector2(30, 390));
            Add(playerStat);

            Add(panel);

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
            Add(placeholder);



        }
    }
}
