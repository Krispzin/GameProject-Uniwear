using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ThanaNita.MonoGameTnt;
using System.Diagnostics;
using Project3_1;
using System.Collections.Generic;


namespace Project2
{
    public class Game1 : Game2D
    {
        Song MenuSong, DialogSong, TileSong, CombatSong;
        List<Song> songs;
        int currentSongIndex;
        Actor credit;
        Actor menuScreen;
        Actor inputScreen;
        DialogPanel dialogpanel;
        DialogScreen dialogScreen;
        CombatScreen combatScreen;
        Game13Tile game13;
        WinDialog winDialog;

        public Game1()
            : base(virtualScreenSize: new Vector2(640, 480),
                   preferredWindowSize: new Vector2(640, 480))
        {
            ClearColor = Color.DarkGray;
            BackgroundColor = Color.DarkGray;
            IsFixedTimeStep = false;

            songs = new List<Song>();
            currentSongIndex = 0;
        }
        protected override void LoadContent()
        {
            CollisionDetectionUnit.AddDetector(1, 2);

            menuScreen = new MenuScreen(ScreenSize, ExitNotifier);
            All.Add(menuScreen);
            //combatScreen = new CombatScreen(ScreenSize, ExitNotifier);
            //All.Add(combatScreen);

            songs.Add(MenuSong);
            songs.Add(DialogSong);
            songs.Add(TileSong);
            songs.Add(CombatSong);

            //ปรับ Loop
            MediaPlayer.IsRepeating = true;
            //ปรับเสียง
            MediaPlayer.Volume = 0.2f;
            //MediaPlayer.Play(MenuSong);
            Debug.WriteLine("menu");
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
                    //game13 = new Game13Tile(ScreenSize, Camera, ExitNotifier);// <<<< use this
                    dialogScreen = new DialogScreen(ScreenSize, ExitNotifier);
                    All.Add(dialogScreen);
                    //Add(game13);
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

            else if (actor == game13)
            {
                if (game13.cameraMan != null)
                    game13.cameraMan.AdjustCamera();

                if (code == 0)
                {
                    game13.guy.Position = new Vector2((ScreenSize.X / 2), (ScreenSize.Y / 2) + 15);
                    game13.Detach();
                    game13 = null;
                    combatScreen = new CombatScreen(ScreenSize, ExitNotifier);
                    All.Add(combatScreen);
                }
            }
            else if (actor == dialogScreen)
            {
                // เมื่อ DialogPanel จบ
                if (code == 1) // code ที่ใช้บอกว่า DialogPanel จบ
                {
                    dialogScreen.Detach();
                    dialogScreen = null;
                    game13 = new Game13Tile(ScreenSize, Camera, ExitNotifier); // สร้าง Game13Tile
                    All.Add(game13); // เพิ่ม Game13Tile เข้าในระบบ
                    Debug.WriteLine("DialogPanel finished. Starting Game13Tile.");
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
            else if (actor == combatScreen)
            {
                if (code == 0)
                {
                    combatScreen.Detach();
                    combatScreen = null;
                    winDialog = new WinDialog(ScreenSize, ExitNotifier);
                    All.Add(winDialog);
                }
                else if (code == 1)
                {
                    combatScreen.Detach();
                    combatScreen = null;
                    credit = new Credit(ScreenSize, ExitNotifier);
                    All.Add(credit);
                }
                else if (code == 2)
                {
                    combatScreen.Detach();
                    combatScreen = null;
                    credit = new Credit(ScreenSize, ExitNotifier);
                    All.Add(credit);
                }
            }
            else if (actor == winDialog)
            {
                if (code == 1)
                {
                    winDialog.Detach();
                    winDialog = null;
                    credit = new Credit(ScreenSize, ExitNotifier);
                    All.Add(credit);
                }
            }
        }
    }
}