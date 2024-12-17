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
        private Button btnb;
        Text text;
        ExitNotifier exitNotifier;
        public InputScreen(Vector2 screenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;
            text = new Text("ChakraPetch-Regular.ttf", 100, Color.White,
                            "User Interface: test");
           Add(text);

            btnb = new Button("ChakraPetch-Regular.ttf", 20, Color.Black, "Back", new Vector2(100, 50));
            btnb.Position = new Vector2(0, 0);
            Add(btnb);


            //    var region = new TextureRegion(TextureCache.Get("ui.jpg"), new RectF(700, 700, 80, 45));
            //    var imageButton = new ImageButton(region);
            //    imageButton.Position = new Vector2(10, 10);
            //    imageButton.SetButtonText("ChakraPetch-Regular.ttf", 15, Color.Green, "Back");
            //    Add(imageButton);
            //    //Add(btnb);
        }
        private void back (GenericButton button) 
        {
            exitNotifier(this,1);
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            btnb.ButtonClicked += back;
        }
    }
}
