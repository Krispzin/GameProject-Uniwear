using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Project3_1
{
    public class WinScreen : Actor
    {
        Placeholder placeholder = new Placeholder();
        SoundEffect victory = SoundEffect.FromFile("Victory.wav");
        Text text;
        public bool played = false;
        public WinScreen(Vector2 screensize)
        {
            placeholder.Color = new Color(Color, 0);

            var background = new SpriteActor();
            background.SetTexture(TextureCache.Get("Content/resource/img/BlackBar.png"));
            background.Origin = background.RawSize / 2;
            background.Position = screensize / 2;

            text = new Text("OptimusPrinceps.ttf", 50, Color.Beige, "YOU WIN!!");
            text.Origin = text.RawSize / 2;
            text.Position = screensize / 2;

            placeholder.Add(background);
            placeholder.Add(text);
            Add(placeholder);
            placeholder.AddAction(Actions.FadeIn(1f, placeholder));
        }

        public void playSound()
        {
            victory.Play(0.5f, 0, 0);
            played = true;
        }
    }
}
