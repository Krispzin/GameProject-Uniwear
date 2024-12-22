
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project3_1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class DialogScreen : Actor
    {
        ExitNotifier exitNotifier;
        TextAnimation textAnimation;
        Panel panel;
        Text text;
        SpriteActor cutScene;

        string[] str;
        string[] scenes;
        public bool finished = false;
        public DialogScreen(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            //ScreenSizen = screenSize;
            scenes = ["Content/resource/img/bgUni.png", "Content/resource/img/pantie.png", "Content/resource/img/elevator.png"];

            this.exitNotifier = exitNotifier;

            cutScene = new SpriteActor();
            cutScene.SetTexture(TextureCache.Get(scenes[0]));

            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, "") { Position = new(5, 5) };
            str = ["ณ มหาลัยแห่งหนึ่ง คุณกำลังจะกลับบ้านหลังจากที่คุณเรียนมาทั้งวัน", "แต่กลับลืมของสำคัญของคุณไว้บนตึก เลยต้องกลับขึ้นไปเอาของนั้นคืน", "ของสำคัญสิ่งนั้นคือ 'กางเกงใน' ของคุณ", "ถ้าคุณขาดมันไป ชีวิตของคุณคงจะไม่เป็นสุขอย่างแน่แท้", "คุณจึงเดินกลับไปหน้าลิฟต์เพื่อไปทวงของสำคัญของคุณคืน"];

            panel = new Panel(new Vector2(580, 100), Color.White, Color.Black, 2);
            panel.Position = new Vector2(30, 370);
            Add(cutScene);
            Add(panel);

        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            DialogRunner();
        }

        private int currentIndex = 0;
        private int index = 1;

        public void DialogRunner()
        {
            var keyInfo = GlobalKeyboardInfo.Value;

            if (panel.ChildCount == 0)
            {
                panel.Add(text);
                RunDialog();
            }

            if (panel.ChildCount == 1)
            {
                if (keyInfo.IsKeyPressed(Keys.Space) && currentIndex < str.Length)
                {
                    RunDialog();
                    if (currentIndex == 3)
                    {
                        SetNextScene();
                    }
                    else if (currentIndex == 5)
                    {
                        SetNextScene();
                    }
                }
                else if (currentIndex >= str.Length && (textAnimation == null || textAnimation.IsFinished()))
                {
                    finished = true;
                    Debug.WriteLine("Dialog finished");

                    // กด Space หลังจากจบข้อความทั้งหมด
                    if (keyInfo.IsKeyPressed(Keys.Space))
                    {
                        exitNotifier(this, 1); // ใช้โค้ด 1 เพื่อระบุว่า DialogScreen จบ
                        //Debug.WriteLine();
                    }
                }
            }
        }

        private void RunDialog()
        {
            text.ClearAction();
            text.AddAction(textAnimation = new TextAnimation(text, str[currentIndex], textSpeed: 45));
            currentIndex++;
        }

        private void SetNextScene()
        {
            cutScene.SetTexture(TextureCache.Get(scenes[index]));
            index++;
        }
    }
}
