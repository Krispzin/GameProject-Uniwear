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
    //public class ActPanel : Actor
    //{
    //    private Placeholder placeholder = new Placeholder();
    //    private Panel panel;
    //    private Vector2 position;
    //    TextAnimation textAnimation;
    //    private Text text;
    //    private string[] str1,str2,str3 ,str;
    //    private Panel textPanel;
    //    Button actBtn1, actBtn2, actBtn3;
    //    public bool finished = false;

    //    public ActPanel(Vector2 vector2)
    //    {
    //        position = vector2;
    //        Position = position;
    //        text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, " ");

    //        panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);

    //        placeholder.Add(panel);
    //        Add(placeholder);

    //    }

    //    public override void Act(float deltaTime)
    //    {
    //        base.Act(deltaTime);
    //        var keyInfo = GlobalKeyboardInfo.Value;

    //    }
    //    private int currentIndex = 0;
    //    public void DialogRunner()
    //    {
    //        var keyInfo = GlobalKeyboardInfo.Value;
    //        if (panel.ChildCount == 0)
    //        {
    //            panel.Add(text);
    //            RunDialog();
    //        }

    //        if (panel.ChildCount == 1)
    //        {
    //            if (keyInfo.IsKeyPressed(Keys.Space) && (currentIndex) < str.Length)
    //            {
    //                RunDialog();
    //            }
    //        }

    //        if (currentIndex >= str.Length && (textAnimation == null || textAnimation.IsFinished()))
    //        {
    //            finished = true;
    //            Debug.WriteLine(this.finished);
    //            ;
    //        }
    //    }

    //    private void RunDialog()
    //    {
    //        text.ClearAction();
    //        text.AddAction(textAnimation = new TextAnimation(text, str[currentIndex], textSpeed: 45));
    //        currentIndex++;
    //    }
    //    private void actbtn1(GenericButton button) 
    //    {
    //        TextAction1();
    //    }
    //    private void actbtn2(GenericButton button) 
    //    { 
    //        TextAction2();
    //    }
    //    private void actbtn3(GenericButton button)
    //    {
    //        TextAction3();
    //    }

    //    public void TextAction1()
    //    {

    //        str1 = new string[] { "ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "3 asdasdasdasdasd" };



    //    }
    //    public void TextAction2()
    //    {

    //        str2 = new string[] { "2 asdasdasdasdasd", "3 asdasdasdasdasd" };



    //    }

    //    public void TextAction3()
    //    {

    //        str3 = new string[] { "ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd"};
    //    }
    //}


    public class ActPanel : Actor
    {
        private Placeholder placeholder = new Placeholder();
        private Panel panel;
        private Text text;
        private TextAnimation textAnimation;
        private string[] str1, str2, str3, str;
        private int currentIndex = 0;
        public bool finished { get; private set; } = false;

        public ActPanel(Vector2 position)
        {
            Position = position;

            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, "");
            panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);
            panel.Add(text);

            placeholder.Add(panel);
            Add(placeholder);

            // Initialize text options
            str1 = new string[] { "ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "3 asdasdasdasdasd" };
            str2 = new string[] { "2 asdasdasdasdasd", "3 asdasdasdasdasd" };
            str3 = new string[] { "ทดสอบระบบ สระแม่งติดมั้ยวะ? คุ", "2 asdasdasdasdasd" };


            placeholder.Add(panel);
            Add(placeholder);
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            DialogRunner();
        }
        public void DialogRunner()
        {
            var keyInfo = GlobalKeyboardInfo.Value;
            if (panel.ChildCount == 0)
            {
                panel.Add(text);
                RunDialog(str);
            }

            if (panel.ChildCount == 1)
            {
                if (keyInfo.IsKeyPressed(Keys.Space) && (currentIndex) < str.Length)
                {
                    RunDialog(str);
                }

            }

            if (currentIndex >= str.Length && (textAnimation == null || textAnimation.IsFinished()))
            {
                finished = true;
                Debug.WriteLine(this.finished);
            }
        }

        private void RunDialog(string[] selectedStr)
        {
            str = selectedStr;
            text.ClearAction(); // Clear any previous animations
            text.AddAction(textAnimation = new TextAnimation(text, str[currentIndex], textSpeed: 45));
            currentIndex++;
        }
        

        // Methods to handle button inputs
        public void TextAction1()
        {
            RunDialog(str1); // Set str to str1 and start dialog
        }

        public void TextAction2()
        {
            RunDialog(str2); // Set str to str2 and start dialog
        }

        public void TextAction3()
        {
            RunDialog(str3); // Set str to str3 and start dialog
        }
    }
}
