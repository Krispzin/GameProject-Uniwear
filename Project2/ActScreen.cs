using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;
using static System.Net.Mime.MediaTypeNames;
using Text = ThanaNita.MonoGameTnt.Text;

namespace Project3_1
{
    public class ActScreen : Actor
    {
        private ExitNotifier exitNotifier;
        private Placeholder placeholder = new Placeholder();
        private Button atkBtn, actBtn, runBtn;
        private Panel panel;
        private Text text;
        private string[] str;
        private Panel textPanel; // Panel to hold text when "Act1" is clicked

        public ActScreen(Vector2 ScreenSize)
        {
            //this.exitNotifier = exitNotifier;

            // Initialize text and str array
            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, " ");
            str = new string[] { "ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd", "3 asdasdasdasdasd" };

            // Initialize UI components
            InitializeUI(ScreenSize);
        }

        private void InitializeUI(Vector2 ScreenSize)
        {
            panel = new Panel(new Vector2(580, 150), Color.White, Color.Black, 2);
            panel.Position = new Vector2(30, 240);
            AddButtonsToPanel();

            atkBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ATTACK", new Vector2(175, 40));
            atkBtn.Position = new Vector2(30, 420);
            placeholder.Add(atkBtn);

            actBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ACT", new Vector2(175, 40));
            actBtn.Position = new Vector2(ScreenSize.X / 2, 420);
            actBtn.Origin = new Vector2(actBtn.RawSize.X / 2, 0);
            //actBtn.ButtonClicked += ActBtn_ButtonClicked;
            placeholder.Add(actBtn);

            runBtn = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "RUN", new Vector2(175, 40));
            runBtn.Position = new Vector2(610, 420);
            runBtn.Origin = new Vector2(runBtn.RawSize.X, 0);
            placeholder.Add(runBtn);

            Add(placeholder);
        }

        private void AddButtonsToPanel()
        {
            var actBtn1 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act1", new Vector2(175, 60))
            {
                Position = new Vector2(10, 10)
            };
            actBtn1.ButtonClicked += ActBtn1_Clicked;

            var actBtn2 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act2", new Vector2(175, 60))
            {
                Position = new Vector2(10, 25)
            };

            var actBtn3 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act3", new Vector2(175, 60))
            {
                Position = new Vector2(370, 10)
            };

            Alignment.SetPosition(actBtn1, actBtn2, AlignDirection.Down);
            Alignment.SetOrigin(actBtn3, Align.Right);

            placeholder.Add(actBtn1);
            placeholder.Add(actBtn2);
            placeholder.Add(actBtn3);
            panel.Add(actBtn1);
            panel.Add(actBtn2);
            panel.Add(actBtn3);

            Add(panel);
        }

        private void ActBtn1_Clicked(GenericButton button)
        {
            if (textPanel == null) // Create the panel if it doesn't exist
            {
                textPanel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2)
                {
                    Position = new Vector2(30, 240)
                };

                textPanel.Add(text); // Add text to the panel
                Add(textPanel); // Add the panel to the actor
                text.AddAction(new TextAnimation(text, str[0], textSpeed: 45));
            }
            else // Remove the panel if it already exists
            {
                Remove(textPanel);
                textPanel = null;
            }
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            var keyInfo = GlobalKeyboardInfo.Value;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (text.Str == str[i])
                {
                    if (keyInfo.IsKeyPressed(Keys.Space))
                    {
                        {
                            this.AddAction(new TextAnimation(text, str[i + 1], textSpeed: 45));
                            break;
                        }
                    }
                }
                else if (text.Str != str[i])
                {
                    if (keyInfo.IsKeyPressed(Keys.Space))
                    {
                        AddButtonsToPanel();
                    }

                }
            }
        }
    }
}