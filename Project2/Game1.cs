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
            MediaPlayer.Volume = 0.5f;
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
                    inputScreen = new InputScreen(ScreenSize, ExitNotifier);
                    All.Add(inputScreen);
                }
                //Credit button
                else if (code == 1)
                {
                    menuScreen.Detach();
                    menuScreen = null;
                    credit = new Credit(ScreenSize, ExitNotifier);
                    All.Add(credit);
                }
                //Exit button
                else if (code == 2)
                {
                    this.Exit();
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