using System;
using Game12;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ThanaNita.MonoGameTnt;

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

            song = Song.FromUri(name: "Song01",
                new Uri("Pikuniku Dancing - Extended Version [TubeRipper.cc].ogg", UriKind.Relative));
            MediaPlayer.Play(song);
            //  Uncomment the following line will also loop the song
            MediaPlayer.IsRepeating = true;
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }
        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            // 0.0f is silent, 1.0f is full volume
            MediaPlayer.Volume -= 0.0f;
            MediaPlayer.Play(song);
        }
        private void ExitNotifier(Actor actor, int code)
        {
            if (actor == null)
                return;

            if (actor == menuScreen)
            {
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
        }
    }

