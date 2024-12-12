
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using ThanaNita.MonoGameTnt;

namespace Game12
{
   

    public class MenuScreen : Actor
    {
        private Button btnstar, btncd, btnexit;
        ExitNotifier exitNotifier;
        public MenuScreen(Vector2 screenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            btnstar = new Button("Poppins-Medium.ttf", 50, Color.Black, "Start", new Vector2(100, 80));

            btnstar.Position = new Vector2(140, 220);

            Add(btnstar);


            btncd = new Button("Poppins-Medium.ttf", 50, Color.Black, "Credit", new Vector2(100, 80));

            btncd.Position = new Vector2(260, 220);

            Add(btncd);

            btnexit = new Button("Poppins-Medium.ttf", 50, Color.Black, "Exit", new Vector2(100, 80));

            btnexit.Position = new Vector2(380, 220);

            Add(btnexit);

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
        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            btnstar.ButtonClicked += next;
            btncd.ButtonClicked += credit;
            btnexit.ButtonClicked += exit;
        }

    }
}

        
        
    
