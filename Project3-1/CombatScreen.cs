using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using ThanaNita.MonoGameTnt;
using static System.Net.Mime.MediaTypeNames;
using Text = ThanaNita.MonoGameTnt.Text;

namespace Project3_1
{
    public class CombatScreen : Actor
    {
        ExitNotifier exitNotifier;
        Game1 game1;
        ActionBtns actionbtns;
        DialogPanel dialogpanel;
        AttackPanel attackpanel;
        public enum State { Init, PPreTurn, PlayerAction, StatusUpdate, TurnEnd }
        public State state = State.Init;
        public Actor dialogPanel, actionBtns, attackPanel;
        Panel panel;
        Text text;
        public Placeholder placeholder = new Placeholder();
        Button atkBtn, actBtn, runBtn, ltBtn, htBtn;
        string[] str;
        public CombatScreen(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            dialogpanel = new DialogPanel(new Vector2(30, 240));
            dialogPanel = dialogpanel;
            //placeholder.Add(dialogPanel);

            //var playerHpBar = new PlayerHpBar(new Vector2(30, 390));
            //placeholder.Add(playerHpBar);
            actionbtns = new ActionBtns(new Vector2(0, 0), ScreenSize, dialogPanel);
            actionBtns = actionbtns;

            attackpanel = new AttackPanel(new Vector2(0, 0));
            attackPanel = attackpanel;

            //placeholder.Add(actionbtns);


            Add(placeholder);

        }

        private void ChangeState(State newState)
        {
            state = newState;
            if (state == State.StatusUpdate)
                attackPanel.Detach();
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            if (state == State.Init && placeholder.ChildCount == 0)
            {
                placeholder.Add(dialogPanel);
                placeholder.Add(actionbtns);
                Debug.WriteLine(state);
                Debug.WriteLine(dialogpanel.finished);
            }
            else if (state == State.PPreTurn)
            {
                actionbtns.btnActions();
            }
            else if (state == State.PlayerAction)
            {
                placeholder.Add(attackPanel);
                if (actionbtns.AtkType == ActionBtns.AtkTypes.lightAtk)
                {
                    attackpanel.lightAtk();
                    actionbtns.AtkType = ActionBtns.AtkTypes.Non;
                }
                else if (actionbtns.AtkType == ActionBtns.AtkTypes.heavyAtk)
                {
                    attackpanel.heavyAtk();
                    actionbtns.AtkType = ActionBtns.AtkTypes.Non;
                }
            }
            else if (state == State.StatusUpdate)
            {

            }


            if (dialogpanel.finished == true)
                ChangeState(State.PPreTurn);

            if (actionbtns.finished == true)
                ChangeState(State.PlayerAction);

            if (attackpanel.finished == true)
                ChangeState (State.StatusUpdate);

        }
    }
}
