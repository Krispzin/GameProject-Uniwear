using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class LtMovingBar : Actor
    {
        public LtMovingBar(Vector2 position)
        {
            Add(new MovingBar(position, 0f));
            Add(new MovingBar(position, 0.3f));
            Add(new MovingBar(position, 0.6f));
        }

    }
}
