using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class WinDialog : Actor
    {
        ExitNotifier exitNotifier;
        TextAnimation textAnimation;
        Panel panel;
        Text text;
        SpriteActor cutScene;
        Song song;
        string[] str;
        string[] scenes;
        public bool finished = false;
        public WinDialog(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            scenes = ["Content/resource/img/Victory1.png", "Content/resource/img/Victory2.png"];

            this.exitNotifier = exitNotifier;

            song = Song.FromUri(name: "Song01", new Uri("Your Best Friend.ogg", UriKind.Relative));

            //ปรับ Loop
            MediaPlayer.IsRepeating = true;
            //ปรับเสียง
            MediaPlayer.Volume = 0.2f;
            MediaPlayer.Play(song);

            cutScene = new SpriteActor();
            cutScene.Origin = cutScene.RawSize / 2;
            
            cutScene.SetTexture(TextureCache.Get(scenes[0]));

            text = new Text("ChakraPetch-Regular.ttf", 25, Color.Black, "") { Position = new(5, 5) };
            str = ["'ในที่สุด กางเกงในของเราก็กลับคืนมาแล้ว!!!'", "จากนั้นคุณก็ใส่กางเกงในของคุณกลับคืนมา", "ชีวิตของคุณกลับมามีสีสันอีกครั้ง", "--จบ Demo--"];

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
        private int index = 0;

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
                    if (currentIndex == 2)
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
                        MediaPlayer.Stop();
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
            AddAction(new SequenceAction(Actions.FadeOut(0.5f, cutScene), new RunAction(() => cutScene.SetTexture(TextureCache.Get(scenes[index]))), Actions.FadeIn(0.5f, cutScene)));
            index++;
        }
    }
}
