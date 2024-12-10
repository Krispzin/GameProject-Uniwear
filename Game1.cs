using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ThanaNita.MonoGameTnt;
using System.Collections.Generic;
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
            actBtn.ButtonClicked += ActBtn_ButtonClicked;
            placeholder.Add(actBtn);

            var runBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "RUN", new Vector2(175, 60));
            runBtn.Position = new Vector2(610, 400);
            runBtn.Origin = new Vector2(runBtn.RawSize.X, 0);
            placeholder.Add(runBtn);

            placeholder.Add(panel);
            

            All.Add(placeholder);
            
            All.Add(new MovingBar(All, new Vector2(30, 420)));
        }

        private Panel actionPanel; // Field to track the panel instance
        private List<Button> actionButtons; // To track the buttons added to the panel

        private void ActBtn_ButtonClicked(GenericButton button)
        {
            //var panel = new Panel(new Vector2(580, 150), Color.White, Color.Black, 2);
            //panel.Position = new Vector2(30, 240);
            //var actBtn1 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act1", new Vector2(175, 60));
            //actBtn1.Position = new Vector2(10, 10);
            //var actBtn2 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act2", new Vector2(175, 60));
            //actBtn2.Position = new Vector2(10, 25);
            //var actBtn3 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act3", new Vector2(175, 60));
            //actBtn3.Position = new Vector2(370,10);

            //Alignment.SetPosition(actBtn1, actBtn2, AlignDirection.Down);
            //Alignment.SetOrigin(actBtn3, Align.Right);

            //placeholder.Add(actBtn1);
            //placeholder.Add(actBtn2);
            //placeholder.Add(actBtn3);
            //panel.Add(actBtn1);
            //panel.Add(actBtn2); 
            //panel.Add(actBtn3);

            //placeholder.Add(panel);


            if (actionPanel == null) // If the panel doesn't exist, create it
            {
                // Create the panel
                actionPanel = new Panel(new Vector2(580, 150), Color.White, Color.Black, 2)
                {
                    Position = new Vector2(30, 240)
                };

                // Initialize the buttons
                var actBtn1 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act1", new Vector2(175, 60))
                {
                    Position = new Vector2(10, 10)
                };
                var actBtn2 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act2", new Vector2(175, 60))
                {
                    Position = new Vector2(10, 25)
                };
                var actBtn3 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act3", new Vector2(175, 60))
                {
                    Position = new Vector2(370, 10)
                };

                // Adjust alignment
                Alignment.SetPosition(actBtn1, actBtn2, AlignDirection.Down);
                Alignment.SetOrigin(actBtn3, Align.Right);

                // Add buttons to the panel
                actionPanel.Add(actBtn1);
                actionPanel.Add(actBtn2);
                actionPanel.Add(actBtn3);

                // Keep track of buttons
                actionButtons = new List<Button> { actBtn1, actBtn2, actBtn3 };

                // Add the panel to the placeholder
                placeholder.Add(actionPanel);
            }
            else // If the panel already exists, remove it
            {
                // Remove buttons from the placeholder
                foreach (var btn in actionButtons)
                {
                    placeholder.Remove(btn);
                }

                // Remove the panel from the placeholder
                placeholder.Remove(actionPanel);

                // Clear the references
                actionPanel = null;
                actionButtons = null;
            }


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
 