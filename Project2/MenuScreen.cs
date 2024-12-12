
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using ThanaNita.MonoGameTnt;

namespace Game12
{
  

        public class MenuScreen : Actor
        {
            ExitNotifier exitNotifier;
        public MenuScreen(Vector2 screenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            var button1 = new Button("Poppins-Medium.ttf", 50, Color.Black, "Click Me", new Vector2(300, 100));

            button1.Position = new Vector2(screenSize.X / 2 - button1.RawSize.X / 2, screenSize.Y / 2 - button1.RawSize.Y / 2);

            Add(button1);
            /*

                var button2 = new Button("Poppins-Medium.ttf", 50, Color.Black, "kuy", new Vector2(300, 100));

                button2.Position = new Vector2(screenSize.X / 2 - button2.RawSize.X / 2, screenSize.Y / 2 - button2.RawSize.Y / 2);

                Add(button2);
            }
            */
        }
            private Actor selection = null;
            private Vector2 click;
            public override void Act(float deltaTime)
            {
                base.Act(deltaTime);

                var mouseInfo = GlobalMouseInfo.Value;
                var keyInfo = GlobalKeyboardInfo.Value;

                if (mouseInfo.IsLeftButtonPressed())
                    AddAction(new SequenceAction(
                                    Actions.FadeOut(0.2f, this),
                                    new RunAction(() => exitNotifier(this, 0))
                        ));

            }
        }
    }

        
        
    
