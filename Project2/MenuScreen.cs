
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using ThanaNita.MonoGameTnt;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;


namespace Game12
{
   

    public class MenuScreen : Actor
    {
        private Button btnstar, btncd, btnexit;
        ExitNotifier exitNotifier;
        public MenuScreen(Vector2 screenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            btnstar = new Button("ChakraPetch-Regular.ttf", 50, Color.Black, "Start", new Vector2(150, 80));

            btnstar.Position = new Vector2(250, 100);

            Add(btnstar);


            btncd = new Button("ChakraPetch-Regular.ttf", 50, Color.Black, "Credit", new Vector2(150, 80));

            btncd.Position = new Vector2(250, 200);

            Add(btncd);

            btnexit = new Button("ChakraPetch-Regular.ttf", 50, Color.Black, "Exit", new Vector2(150, 80));

            btnexit.Position = new Vector2(250, 300);

            Add(btnexit);
            btnAction();
        }
        

        private void next(GenericButton button)
        {
            exitNotifier(this, 0);
        }

        private void credit(GenericButton button)
        {
            exitNotifier(this, 1);
        }

        private void exit(GenericButton button)
        {
            exitNotifier(this, 2);
        }

        // function ให้ปุ่มทำงาน (ย้ายจาก Act เพราะมันทำงานซ้ำจน Lag)
        private void btnAction()
        {
            btnstar.ButtonClicked += next;
            btncd.ButtonClicked += credit;
            btnexit.ButtonClicked += exit;
        }
    }
}

        
        
    
