using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game12;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class Credit : Actor
    {
        ExitNotifier exitNotifier;
        Text text;
        private Button btnb;
        public Credit(Vector2 screenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            text = new Text("ChakraPetch-Regular.ttf", 35, Color.White,
                            "นายจีรกิตติ์ สีทา 071 \nนายอธิกันต์ หมู่พยัค 087\n" +
                            "นายอาชวิน ฉัตรอนันทเวช 088 \nนายชญานิน บุตะเขียว 287 \n" +
                            "นายณพวุฒิ เยี่ยงชัยมงคล 290 \nนายแผ่นดิน กิตติธร 296");
            text.Position = new Vector2(screenSize.X / 2 - 150, 100);
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

        private void back(GenericButton button)
        {
            exitNotifier(this, 1);
        }


        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            btnb.ButtonClicked += back;

            //foreach (var actor in Children)
            //{
            //    if (actor is ImageButton imageButton)
            //    {
            //        imageButton.ButtonClicked += back;
            //    }
            //}
        }


    }
}
