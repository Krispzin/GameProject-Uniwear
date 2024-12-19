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
        PlayerStat playerStat;
        Game1 game1;
        ActionBtns actionbtns;
        DialogPanel dialogpanel;
        AttackPanel attackpanel;
        RunPanel runpanel;
        ActScreen ActScreen;
        Enemy enemy;
        public enum State { Init, PPreTurn, PlayerAction, StatusUpdate, TurnEnd , ExitBattle }
        public State state = State.Init;
        public Actor dialogPanel, actionBtns, attackPanel ,actScreen, runPanel;
        private int pHpNew;
        private int eHpNew;
        private int playerHits = 0;
        private int enemyHits = 0;
        private bool hpUpdated = false; 
        Panel panel;
        Text text;
        public Placeholder placeholder = new Placeholder();
        Button atkBtn, actBtn, runBtn, ltBtn, htBtn;
        string[] str;
        public CombatScreen(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            enemy = new Enemy(new Vector2(320, 120));

            playerStat = new PlayerStat("ยู", 20, 20, 5, new Vector2(30, 390));

            dialogpanel = new DialogPanel(new Vector2(30, 240));
            dialogPanel = dialogpanel;

            actionbtns = new ActionBtns(new Vector2(0, 0), ScreenSize, dialogPanel);
            actionBtns = actionbtns;

            ActScreen = new ActScreen(new Vector2(0, 0));
            actScreen = ActScreen;

            attackpanel = new AttackPanel(new Vector2(30, 240));
            attackPanel = attackpanel;

            runpanel = new RunPanel(new Vector2(30, 240));
            runPanel = runpanel;

            //placeholder.Add(actionbtns);

            ChangeState(State.Init);
            Add(placeholder);
        }

        private void ChangeState(State newState)
        {
            state = newState;
            if (state == State.Init)
            {
                InitSetup();
                Debug.WriteLine(state);
            }
            else if (state == State.PPreTurn)
            {
                actionbtns.btnActions();
                Debug.WriteLine(state);
            }

            else if (state == State.PlayerAction)
            {
                placeholder.Add(attackPanel);
                Debug.WriteLine(state);
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
                playerHits = attackpanel.hitTime;
                enemyHits = attackpanel.hitMisses;
                attackpanel.hitTime = 0;
                attackpanel.hitMisses = 0;

                attackPanel.Detach();
                playerStat.Hp -= enemy.Strength * enemyHits;
                enemyHits = 0;
                pHpNew = playerStat.Hp;
                enemy.Hp -= playerStat.Strength * playerHits;
                playerStat.Hp = 0;
                eHpNew = enemy.Hp;
                playerStat.updateHp(pHpNew);
                enemy.updateHp(eHpNew);
                Debug.WriteLine(state);
            }
            else if (state == State.TurnEnd)
            {
                if (playerStat.Hp <= 0)
                {

                }
                else if (enemy.Hp <= 0)
                {

                }
                    
            }
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            if (dialogpanel.finished == true)
            {
                ChangeState(State.PPreTurn);
                dialogpanel.finished = false;
            }
            


            if (actionbtns.finished == true)
            {
                ChangeState(State.PlayerAction);
                actionbtns.finished = false;
            }

            if (attackpanel.finished == true)
            {
                //playerHits = attackpanel.hitTime;
                //enemyHits = attackpanel.hitMisses;
                //attackpanel.hitTime = 0;
                //attackpanel.hitMisses = 0;
                ChangeState(State.StatusUpdate);
                attackpanel.finished = false;
            }

            if (playerStat.Hp <= 0 || enemy.Hp <= 0)
            {
                ChangeState(State.TurnEnd);
            }

            if (runpanel.finished == true)
            {
                ChangeState(State.ExitBattle);
                //ออกเกม
            }
        }

        private void InitSetup()
        {
            placeholder.Add(new BG(new Vector2(320, 120)));
            placeholder.Add(enemy);
            placeholder.Add(playerStat);
            placeholder.Add(dialogPanel);
            placeholder.Add(actionbtns);
        }
    }
}
