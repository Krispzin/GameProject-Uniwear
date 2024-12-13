using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game12;
using Microsoft.Xna.Framework;
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
            text = new Text("ChakraPetch-Regular.ttf", 10, Color.White,
                            "นายจีรกิตติ์ สีทา 071 \nนายอธิกันต์ หมู่พยัค 087\n" +
                            "นายอาชวิน ฉัตรอนันทเวช 088 \nนายชญานิน บุตะเขียว 287 \n" +
                            "นายณพวุฒิ เยี่ยงชัยมงคล 290 \nนายแผ่นดิน กิตติธร 296");
            Add(text);

            btnb = new Button("ChakraPetch-Regular.ttf", 50, Color.Black, "Back", new Vector2(100, 80));

            btnb.Position = new Vector2(140, 220);

            Add(btnb);
        }

        private void back(GenericButton button)
        {
            exitNotifier(this, 1);
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            btnb.ButtonClicked += back;
        }
    }
}
