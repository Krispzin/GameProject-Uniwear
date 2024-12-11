using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class ActionBtns : Actor
    {
        Placeholder placeholder = new Placeholder();
        Button atkButton, actButton, runButton;
        Actor panel;
        public ActionBtns(Vector2 position, Vector2 screensize, Actor actor)
        {
            Position = position;

            panel = actor;

            atkButton = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ATTACK", new Vector2(175, 40)) { Position = new(30, 420) };

            actButton = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ACT", new Vector2(175, 40));
            actButton.Position = new Vector2(screensize.X / 2, 420);
            actButton.Origin = new Vector2(actButton.RawSize.X / 2, 0);
            
            runButton = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "RUN", new Vector2(175, 40)) { Position = new(610, 420) };
            runButton.Origin = new Vector2(runButton.RawSize.X, 0);

            placeholder.Add(atkButton);
            placeholder.Add(actButton);
            placeholder.Add(runButton);
            
            Add(placeholder);
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            atkButton.ButtonClicked += atkChoice;
        }

        private void atkChoice(GenericButton button)
        {
            panel.Detach();
            placeholder.Add(new AttackPanel(new Vector2(30, 240)));
        }
    }
}
