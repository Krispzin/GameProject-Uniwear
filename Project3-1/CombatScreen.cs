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
        ActPanel actpanel;
        RunPanel runpanel;
        ActScreen actScreen;
        public enum State { Init, PPreTurn ,RunRunRun , PlayerAction, ActState, StatusUpdate, TurnEnd ,ExitBattle}
        public State state = State.Init;
        public Actor dialogPanel, actionBtns, actPanel, attackPanel,actBtns , runPanel;
        Panel panel;
        Text text;
        public Placeholder placeholder = new Placeholder();
        Button atkBtn, actBtn, runBtn, ltBtn, htBtn ;
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

            actpanel = new ActPanel(new Vector2(0, 0));
            actPanel = actpanel; 

            runpanel = new RunPanel(new Vector2(30, 240));
            runPanel = runpanel;

            actScreen = new ActScreen(new Vector2(0, 0));
            //placeholder.Add(actionbtns);


            Add(placeholder);

        }

        private void ChangeState(State newState)
        {
            state = newState;
            if (state == State.StatusUpdate)
                if(state == State.PlayerAction)
                    attackPanel.Detach();
                else if (state == State.RunRunRun)
                    runPanel.Detach();
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
            else if(state == State.ActState)
            {
                placeholder.Add(actPanel);
                if(actionbtns.actChoose == ActionBtns.ActChoose.act1)
                {
                    actpanel.TextAction1();
                    actionbtns.actChoose = ActionBtns.ActChoose.Non;
                }
                if(actionbtns.actChoose == ActionBtns.ActChoose.act2)
                {
                    actpanel.TextAction2();
                    actionbtns.actChoose = ActionBtns.ActChoose.Non;
                }
                if(actionbtns.actChoose == ActionBtns.ActChoose.act3)
                {
                    actpanel.TextAction3();
                    actionbtns.actChoose = ActionBtns.ActChoose.Non;
                }


            }
            else if(state == State.RunRunRun )
            {
                placeholder.Add(runPanel);
                Debug.WriteLine(state);
                Debug.WriteLine(runpanel.finished);
            }
            else if (state == State.StatusUpdate)
            {

            }
            else if(state == State.PPreTurn)
            {

            }
            else if(state == State.ExitBattle)
            {
                //back to game 
                Debug.WriteLine(state);
            }


            if (dialogpanel.finished == true)
                ChangeState(State.PPreTurn);

            if (actionbtns.finished == true)
                ChangeState(State.PlayerAction);

            if (attackpanel.finished == true)
                ChangeState (State.StatusUpdate);
            if (actpanel.finished == true)
                ChangeState(State.StatusUpdate);
            if (runpanel.finished == true)
                ChangeState (State.ExitBattle);


        }
    }
}
