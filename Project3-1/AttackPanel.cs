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
        private Vector2 position;
        private bool isDone = false;
        private float lifeTime = 0;
        private float lifeTimeLimit;
        private enum Choices { non, lightATK, heavyATK }
        private Choices choice = Choices.non;
        Button ltBtn, hvBtn;
        Actor actor;

        public AttackPanel(Vector2 vector2, string choice)
        {
            //this.actor = actor;
            position = vector2;
            Position = position;

            panel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);

            /*
            ltBtn = new Button("ChakraPetch-Bold.ttf", 20, Color.Orange, "Light Attack", new Vector2(120, 30))
            {
                Position = new(10, 10),
                NormalColor = Color.Transparent,
                NormalColorLine = Color.Transparent,
                HighlightColor = Color.Transparent,
                HighlightColorLine = Color.DarkGray,
                PressedColor = Color.DarkGray,
                PressedColorLine = Color.Gray
            };

            hvBtn = new Button("ChakraPetch-Bold.ttf", 20, Color.Red, "Heavy Attack", new Vector2(120, 30))
            {
                Position = new(10, 50),
                NormalColor = Color.Transparent,
                NormalColorLine = Color.Transparent,
                HighlightColor = Color.Transparent,
                HighlightColorLine = Color.DarkGray,
                PressedColor = Color.DarkGray,
                PressedColorLine = Color.Gray
            };
            */

            placeholder.Add(panel);
            //placeholder.Add(ltBtn);
            //placeholder.Add(hvBtn);
            Add(placeholder);
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            if (choice == Choices.lightATK)
            {
                lifeTimeLimit = 2.5f;

                lifeTime += deltaTime;
                if (lifeTime >= lifeTimeLimit)
                {
                    lifeTime = 0;
                    choice = Choices.non;
                    this.Parent.Add(this.actor);
                    this.Detach();
                }
            }
            else if (choice == Choices.heavyATK)
            {
                lifeTimeLimit = 3.1f;

                lifeTime += deltaTime;
                if (lifeTime >= lifeTimeLimit)
                {
                    lifeTime = 0;
                    choice = Choices.non;
                    this.Parent.Add(this.actor);
                    this.Detach();
                }
            }
        }

        private void ltbtn(GenericButton button)
        {
            lightAtk();
            ChooseChoice(Choices.lightATK);
        }

        private void hvbtn(GenericButton button)
        {
            heavyAtk();
            ChooseChoice(Choices.heavyATK);
        }

        private void lightAtk()
        {
                ltBtn.Detach();
                hvBtn.Detach();
                placeholder.Add(new HitBar(new Vector2(panel.RawSize.X / 2, 5)));
                placeholder.Add(new MovingBar(new Vector2(10, 10), 0f));
                placeholder.Add(new MovingBar(new Vector2(10, 10), 0.4f));
                placeholder.Add(new MovingBar(new Vector2(10, 10), 0.6f));
        }

        private void heavyAtk()
        {
                ltBtn.Detach();
                hvBtn.Detach();
                placeholder.Add(new HitBar(new Vector2(panel.RawSize.X / 2, 5)));
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
