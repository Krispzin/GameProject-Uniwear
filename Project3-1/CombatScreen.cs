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
        ActionBtns actionBtns;
        DialogPanel dialogpanel = new DialogPanel(new Vector2(30, 240));
        public enum State { Init, PPreTurn, PlayerAction, EnemyReaction, StatusUpdate, EPreTurn, EnemyAction, PlayerReaction, TurnEnd }
        public State state = State.Init;
        public Actor dialogPanel, actionbtns, attackPanel;
        Panel panel;
        Text text;
        public Placeholder placeholder = new Placeholder();
        Button atkBtn, actBtn, runBtn, ltBtn, htBtn;
        string[] str;
        public CombatScreen(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            dialogPanel = dialogpanel;
            //placeholder.Add(dialogPanel);

            //var playerHpBar = new PlayerHpBar(new Vector2(30, 390));
            //placeholder.Add(playerHpBar);
            actionbtns = new ActionBtns(new Vector2(0, 0), ScreenSize, dialogPanel);
            //placeholder.Add(actionbtns);


            Add(placeholder);

        }

        private void ChangeState(State newState)
        {
            state = newState;
            //if (state == State.Init) {
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
                if (dialogpanel.finished)
                    state = State.PPreTurn;
                
                //Debug.WriteLine(actionbtns.GetChild(0).GetChild(0));
                //if (actionbtns.GetChild(0).GetChild(0).)
            }
            else if (state == State.PPreTurn)
            {
                //Debug.WriteLine(state);
                //actionBtns.Act(deltaTime);
                //Debug.WriteLine(actionbtns.GetChild(1));
                //if (actionbtns.)
            }
            else if (state == State.PlayerAction)
            {
                attackPanel = new AttackPanel(new Vector2(0, 0));
                placeholder.Add(attackPanel);
            }
        }

    }
}
