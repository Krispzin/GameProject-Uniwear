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
        private Placeholder placeholder = new Placeholder();
        private Panel panel;
        private Vector2 position;
        private Text text;
        private string[] str1,str2,str3;
        private Panel textPanel;
        Button actBtn1, actBtn2, actBtn3;
        public bool finished = false;

        public ActPanel(Vector2 vector2)
        {
            position = vector2;
            Position = position;
            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, " ");

            panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);

            placeholder.Add(panel);
            Add(placeholder);

        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            var keyInfo = GlobalKeyboardInfo.Value;
            
        }
        private void actbtn1(GenericButton button) 
        {
            TextAction1();
        }
        private void actbtn2(GenericButton button) 
        { 
            TextAction2();
        }
        private void actbtn3(GenericButton button)
        {
            TextAction3();
        }

        public void TextAction1()
        {
            str1 = new string[] { "ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "3 asdasdasdasdasd" };
            


        }
        public void TextAction2()
        {

            str2 = new string[] { "2 asdasdasdasdasd", "3 asdasdasdasdasd" };
            


        }
        
        public void TextAction3()
        {
            
            str3 = new string[] { "ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd"};
        }
    }
}
