using System;
using Game12;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ThanaNita.MonoGameTnt;
using System.Diagnostics;

namespace Project2
{
    public class Game1 : Game2D
    {
        Song song;
        Actor credit;
        Actor menuScreen;
        Actor inputScreen;
        DialogPanel dialogpanel;
        //Panel panel;
        Game13Tile game13;

        public Actor dialogPanel, actionBtns, attackPanel;
        public Game1()
            : base(virtualScreenSize: new Vector2(640, 480),
                   preferredWindowSize: new Vector2(640, 480))
        {
            BackgroundColor = Color.DarkGray;
            IsFixedTimeStep = false;

        }
        protected override void LoadContent()
        {
            menuScreen = new MenuScreen(ScreenSize, ExitNotifier);
            All.Add(menuScreen);

            //เปลี่ยนเพลงตรงนี้
            song = Song.FromUri(name: "Song01",
                new Uri("mytime.ogg", UriKind.Relative));
            
            //ปรับ Loop
            MediaPlayer.IsRepeating = true;
            //ปรับเสียง
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.Play(song);
            Debug.WriteLine("menu");
        }

        private void ExitNotifier(Actor actor, int code)
        {
            if (actor == null)
                return;

            if (actor == menuScreen)
            {
                playBgm();
                //Start button
                if (code == 0)
                {
                    menuScreen.Detach();
                    menuScreen = null;
                    dialogpanel = new DialogPanel(ScreenSize, ExitNotifier);
                    All.Add(dialogpanel);
                    //game13 = new Game13Tile();// <<<< use this
                    //game13.Run(); // and this

                }
                //Credit button
                else if (code == 1)
                {
                    menuScreen.Detach();
                    menuScreen = null;
                    credit = new Credit(ScreenSize, ExitNotifier);
                    All.Add(credit);
                    Debug.WriteLine("get to cd menu");
                }
                //Exit button
                else if (code == 2)
                {
                    this.Exit();
                }
            }
            else if (actor == dialogpanel)
            {
                // เมื่อ DialogPanel จบ
                if (code == 1) // code ที่ใช้บอกว่า DialogPanel จบ
                {
                    dialogpanel.Detach();
                    dialogpanel = null;
                    game13 = new Game13Tile(); // สร้าง Game13Tile
                    game13.Run(); // เพิ่ม Game13Tile เข้าในระบบ
                    Debug.WriteLine("DialogPanel finished. Starting Game13Tile.");
                }
            }

            else if (actor == inputScreen)
            {
                if (code == 1)
                {
                    inputScreen.Detach();
                    inputScreen = null;
                    menuScreen = new MenuScreen(ScreenSize, ExitNotifier);
                    All.Add(menuScreen);
                }

            }
            else if (actor == credit)
            {
                if (code == 1)
                {
                    Debug.WriteLine("check");
                    credit.Detach();
                    credit = null;
                    menuScreen = new MenuScreen(ScreenSize, ExitNotifier);
                    All.Add(menuScreen);
                }

            }

        }

        private void playBgm()
        {

        }

    }
}