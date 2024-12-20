using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;
using static System.Net.Mime.MediaTypeNames;

namespace Project3_1
{
    public class ActionBtns : Actor
    {
        Placeholder placeholder = new Placeholder();
        Button atkButton, actButton, runButton;
        Button ltBtn, hvBtn;
        Button actBtn1, actBtn2, actBtn3;
        Actor panel, newPanel, myParent;
        AttackPanel attackPanel;
        CombatScreen combatScreen;
        ActScreen actScreen;
        ActPanel actPanel;
        private Panel textPanel;
        RunPanel runPanel;
        public enum AtkTypes { Non, lightAtk, heavyAtk }
        public enum ActTypes { Non , Act1, Act2, Act3}
        public ActTypes ActType = ActTypes.Non;
        public AtkTypes AtkType = AtkTypes.Non;
        public bool finished = false;

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
            //btnActions();

        }

        public void AddButtonsToPanel()
        {
            actBtn1 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act1", new Vector2(175, 60))
            {
                Position = new Vector2(10, 10)
            };

            actBtn2 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act2", new Vector2(175, 60))
            {
                Position = new Vector2(10, 25)
            };

            actBtn3 = new Button("ChakraPetch-Bold.ttf", 15, Color.Black, "*Act3", new Vector2(175, 60))
            {
                Position = new Vector2(370, 10)
            };

            actBtn1.ButtonClicked += actbtn1;
            actBtn2.ButtonClicked += actbtn2;
            actBtn3.ButtonClicked += actbtn3;

            Alignment.SetPosition(actBtn1, actBtn2, AlignDirection.Down);
            Alignment.SetOrigin(actBtn3, Align.Right);

            placeholder.Add(actBtn1);
            placeholder.Add(actBtn2);
            placeholder.Add(actBtn3);
            panel.Add(actBtn1);
            panel.Add(actBtn2);
            panel.Add(actBtn3);
            
            Add(panel);
        }

        public void btnActions()
        {
            atkButton.ButtonClicked += atkChoice;
            ltBtn.ButtonClicked += ltbtn;
            hvBtn.ButtonClicked += hvbtn;

            runButton.ButtonClicked += runChoice;

            actButton.ButtonClicked += actChoice;
            
        }

        public void DelbtnActions()
        {
            atkButton.ButtonClicked -= atkChoice;
            ltBtn.ButtonClicked -= ltbtn;
            hvBtn.ButtonClicked -= hvbtn;
        }

        private void runChoice(GenericButton button)
        {
            panel.Detach();
            placeholder.Add(new RunPanel(new Vector2(30, 240)));

        }

        private void actChoice(GenericButton button)
        {
            panel.Detach();
            AddButtonsToPanel();
            
            
            //ถ้าไม่ได้ให้ใช้ไอ้นี้

            //placeholder.Add(new ActScreen(new Vector2(30, 240)));

        }

        private void actbtn1(GenericButton button)
        {
            newPanel.Detach();
            ActType = ActTypes.Act1;

        }

        private void actbtn2(GenericButton button)
        {
            newPanel.Detach();
            ActType = ActTypes.Act2;


        }
        private void actbtn3(GenericButton button)
        {
            newPanel.Detach();
            ActType = ActTypes.Act3;
        }

        private void atkChoice(GenericButton button)
        {
            panel.Detach();
            placeholder.Add(newPanel);
            newPanel.Add(ltBtn);
            newPanel.Add(hvBtn);
        }

        private void ltbtn(GenericButton button)
        {
            newPanel.Detach();
            AtkType = AtkTypes.lightAtk;
            finished = true;
        }

        private void hvbtn(GenericButton button)
        {
            newPanel.Detach();
            AtkType = AtkTypes.heavyAtk;
            finished = true;
        }
    }
}
