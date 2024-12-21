using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;
using static System.Net.WebRequestMethods;

namespace Project3_1
{
    public class ActPanel : Actor
    {
        Placeholder placeholder = new Placeholder();
        Panel panel;
        private Text text;
        private string[] str;
        private Panel textPanel;
        private Vector2 position;
        Button actBtn1, actBtn2, actBtn3;
        ActionBtns actionBtns;
        public bool finished = false;

        public ActPanel(Vector2 vector2)
        {

            position = vector2;
            Position = position;

            panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);
            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, " ");
            str = new string[] { "ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd", "3 asdasdasdasdasd" };
            placeholder.Add(panel);
            Add(placeholder);
        }

        //private void actbtn1(GenericButton button)
        //{
        //    act1();
        //}

        //private void actbtn2(GenericButton button)
        //{
        //    act2();
        //}

        //private void actbtn3(GenericButton button)
        //{
        //    act3();
        //}

        public void act1()
        {
            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, " ");
            str = new string[] { "ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd", "3 asdasdasdasdasd" };
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
        
        public void act2()
        {
            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, " ");
            str = new string[] { "ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd", "3 asdasdasdasdasd" };
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

        public void act3()
        {
            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, " ");
            str = new string[] { "ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd", "3 asdasdasdasdasd" };
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
                        actionBtns.AddButtonsToPanel();
                    }

                }
            }
        }




        //private void act1(GenericButton button)
        //{

        //}
        //private void act2(GenericButton button) 
        //{ 
        
        //}

        //private void act3(GenericButton button) 
        //{ 
        
        //}






    }
}
