using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class ActionBtns : Actor
    {
        Placeholder placeholder = new Placeholder();
        Button atkButton, ltBtn, hvBtn, actButton, runButton;
        Actor panel, newPanel, myParent;
        AttackPanel attackPanel;
        CombatScreen combatScreen;

        public ActionBtns(Vector2 position, Vector2 screensize, Actor actor)
        {
            Position = position;

            panel = actor;

            newPanel = new Panel(new Vector2(580, 140), Color.White, Color.Black, 2);
            newPanel.Position = new Vector2(30, 240);

            atkButton = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ATTACK", new Vector2(175, 40)) { Position = new(30, 420) };
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

            actButton = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "ACT", new Vector2(175, 40));
            actButton.Position = new Vector2(screensize.X / 2, 420);
            actButton.Origin = new Vector2(actButton.RawSize.X / 2, 0);
            
            runButton = new Button("ChakraPetch-Bold.ttf", 30, Color.Black, "RUN", new Vector2(175, 40)) { Position = new(610, 420) };
            runButton.Origin = new Vector2(runButton.RawSize.X, 0);

            placeholder.Add(atkButton);
            placeholder.Add(actButton);
            placeholder.Add(runButton);

            Add(placeholder);
            btnActions();

        }

        private void btnActions()
        {
            atkButton.ButtonClicked += atkChoice;
            ltBtn.ButtonClicked += ltbtn;
            hvBtn.ButtonClicked += hvbtn;
        }

        private void atkChoice(GenericButton button)
        {
            Debug.WriteLine(panel);
            panel.Detach();
            placeholder.Add(newPanel);
            newPanel.Add(ltBtn);
            newPanel.Add(hvBtn);
            //placeholder.Add(new AttackPanel(new Vector2(30, 240), new DialogPanel(new Vector2(30, 240))));
        }

        private void ltbtn(GenericButton button)
        {
            newPanel.Detach();
        }

        private void hvbtn(GenericButton button)
        {
            newPanel.Detach();
        }
    }
}
