
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using ThanaNita.MonoGameTnt;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using static System.Net.Mime.MediaTypeNames;
using Text = ThanaNita.MonoGameTnt.Text;


namespace Project2
{
   

    public class MenuScreen : Actor
    {
        Song song;
        private Button btnstar, btncd, btnexit;
        ExitNotifier exitNotifier;
        public MenuScreen(Vector2 screenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            var bg = new SpriteActor();
            bg.SetTexture(TextureCache.Get("Content/resource/img/Menu.png"));
            Add(bg);

            //เปลี่ยนเพลงตรงนี้
            song = Song.FromUri(name: "Song01",
                new Uri("mytime.ogg", UriKind.Relative));

            //ปรับ Loop
            MediaPlayer.IsRepeating = true;
            //ปรับเสียง
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.Play(song);

            var text = new SpriteActor();
            text.SetTexture(TextureCache.Get("Content/resource/img/CoverUnieaer.png"));
            text.Origin = text.RawSize / 2;
            text.Position = screenSize / 2;
            Add(text);

            btnstar = new Button("Jacquard12-Regular.ttf", 50, Color.Black, "Start", new Vector2(150, 50));

            btnstar.Position = new Vector2(30, 400);

            Add(btnstar);


            btncd = new Button("Jacquard12-Regular.ttf", 50, Color.Black, "Credit", new Vector2(150, 50));
            btncd.Origin = new Vector2(btncd.RawSize.X / 2, 0);
            btncd.Position = new Vector2(screenSize.X / 2, 400);

            Add(btncd);

            btnexit = new Button("Jacquard12-Regular.ttf", 50, Color.Black, "Exit", new Vector2(150, 50));
            btnexit.Origin = new Vector2(btncd.RawSize.X, 0);
            btnexit.Position = new Vector2(610, 400);

            Add(btnexit);
            btnAction();
        }
        

        private void next(GenericButton button)
        {
            exitNotifier(this, 0);
            //MediaPlayer.Stop();
        }

        private void credit(GenericButton button)
        {
            exitNotifier(this, 1);
            //MediaPlayer.Stop();
        }

        private void exit(GenericButton button)
        {
            exitNotifier(this, 2);
            //MediaPlayer.Stop();
        }

        // function ให้ปุ่มทำงาน (ย้ายจาก Act เพราะมันทำงานซ้ำจน Lag)
        private void btnAction()
        {
            btnstar.ButtonClicked += next;
            btncd.ButtonClicked += credit;
            btnexit.ButtonClicked += exit;
        }
    }
}

        
        
    
