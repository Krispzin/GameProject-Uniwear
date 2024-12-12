using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game12;
using Microsoft.Xna.Framework;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class InputScreen : Actor
    {
        Button button1;
        Text text;
        ExitNotifier exitNotifier;
        public InputScreen(Vector2 screenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;
            text = new Text("Poppins-Medium.ttf", 100, Color.White,
                            "User Interface: test");
           Add(text);

            button1 = new Button("Poppins-Medium.ttf", 50, Color.Black, "Back", new Vector2(100, 80));

            button1.Position = new Vector2(140, 220);

            Add(button1);
        }
        private void back (GenericButton button) 
        {
            exitNotifier(this, 1);
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            button1.ButtonClicked += back;
        }
    }
}
