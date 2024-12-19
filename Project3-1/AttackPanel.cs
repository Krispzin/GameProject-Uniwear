using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;
using static System.Net.WebRequestMethods;

namespace Project3_1
{
    public class AttackPanel : Actor
    {
        Placeholder placeholder = new Placeholder();
        Panel panel;
        MovingBar movingBar = new MovingBar(new Vector2(10, 10), 0f);
        HitBar hitBar = new HitBar(new Vector2(290, 5));
        private Vector2 position;
        public int hitMisses, hitTime;
        private int numBar = 0;
        public bool finished = false;
        Button ltBtn, hvBtn;
        Actor hitbar;

        public AttackPanel(Vector2 vector2)
        {
            hitMisses = 0;
            position = vector2;
            Position = position;

            hitbar = hitBar;

            panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);

            placeholder.Add(panel);
            Add(placeholder);
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            if (this.GetChild(0).ChildCount <= 2)
            {
                hitMisses = numBar - hitBar.hitTimes;
                hitTime = hitBar.hitTimes;
                this.finished = true;
                Debug.WriteLine(this.finished);
            }
        }

        private void ltbtn(GenericButton button)
        {
            lightAtk();
        }

        private void hvbtn(GenericButton button)
        {
            heavyAtk();
        }

        public void lightAtk()
        {
            placeholder.Add(hitbar);
            numBar = 3;
            placeholder.Add(new MovingBar(new Vector2(10, 10), 0f));
            placeholder.Add(new MovingBar(new Vector2(10, 10), 0.4f));
            placeholder.Add(new MovingBar(new Vector2(10, 10), 0.6f));
        }

        public void heavyAtk()
        {
            placeholder.Add(hitbar);
            numBar = 8;
            placeholder.Add(new MovingBar(new Vector2(10, 10), 0f));
            placeholder.Add(new MovingBar(new Vector2(10, 10), 0.4f));
            placeholder.Add(new MovingBar(new Vector2(10, 10), 0.6f));
            placeholder.Add(new MovingBar(new Vector2(10, 10), 0.8f));
            placeholder.Add(new MovingBar(new Vector2(10, 10), 1.2f));
            placeholder.Add(new MovingBar(new Vector2(10, 10), 1.6f));
            placeholder.Add(new MovingBar(new Vector2(10, 10), 1.8f));
            placeholder.Add(new MovingBar(new Vector2(10, 10), 2f));
        }
    }
}
