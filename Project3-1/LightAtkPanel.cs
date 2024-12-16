using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class LightAtkPanel : Actor
    {
        Placeholder placeholder;
        Panel panel;
        public bool finished = false;
        public LightAtkPanel(Vector2 position)
        {
            Position = position;

            panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);

            var lastBar = new MovingBar(new Vector2(10, 10), 0.6f);

            placeholder.Add(new HitBar(new Vector2(panel.RawSize.X / 2, 5)));
            placeholder.Add(new MovingBar(new Vector2(10, 10), 0f));
            placeholder.Add(new MovingBar(new Vector2(10, 10), 0.4f));
            placeholder.Add(lastBar);

            if (lastBar.finished)
                this.finished = true;
        }
    }
}
