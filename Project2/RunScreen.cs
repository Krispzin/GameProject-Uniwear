using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;
using Microsoft.Xna.Framework;

namespace Project3_1
{
    public class RunScreen : Actor
    {
        ExitNotifier exitNotifier;
        Placeholder placeholder = new Placeholder();
        Text text;
        public RunScreen(Vector2 screensize)
        {
            placeholder.Color = new Color(Color, 0);

            var background = new SpriteActor();
            background.SetTexture(TextureCache.Get("Content/resource/img/BlackBar.png"));
            background.Origin = background.RawSize / 2;
            background.Position = screensize / 2;

            text = new Text("OptimusPrinceps.ttf", 45, Color.DarkRed, "WHY ARE YOU RUNNING!?");
            text.Origin = text.RawSize / 2;
            text.Position = screensize / 2;

            placeholder.Add(background);
            placeholder.Add(text);
            Add(placeholder);
            placeholder.AddAction(Actions.FadeIn(1f, placeholder));
        }
    }
}
