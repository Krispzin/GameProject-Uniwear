using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Diagnostics;
using ThanaNita.MonoGameTnt;

namespace Project3_1
{
    public class CombatScreen : Actor
    {
        ExitNotifier exitNotifier;
        PlayerStat playerStat;
        ActionBtns actionbtns;
        DialogPanel dialogpanel;
        AttackPanel attackpanel;
        RunPanel runpanel;
        ActScreen ActScreen;
        ActPanel ActPanel;
        Enemy enemy;
        GOverScreen gOverScreen;
        WinScreen winScreen;
        RunScreen runScreen;
        Song song;

        public enum State { Init, PPreTurn, PlayerAction, StatusUpdate, TurnEnd , ExitBattle }
        public State state = State.Init;
        public Actor dialogPanel, actionBtns, attackPanel ,actScreen , actPanel, runPanel;
        private int pHpNew;
        private int eHpNew;
        private int playerHits = 0;
        private int enemyHits = 0;
        private bool played = false;
        public Placeholder placeholder = new Placeholder();
        public CombatScreen(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            song = Song.FromUri(name: "Song01",
                    new Uri("Content/resource/song/Vordt of the Boreal Valley.ogg", UriKind.Relative));

            //ปรับ Loop
            MediaPlayer.IsRepeating = true;
            //ปรับเสียง
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.Play(song);

            enemy = new Enemy(new Vector2(320, 120));

            playerStat = new PlayerStat("ยู", 20, 20, 5, new Vector2(30, 390));

            dialogpanel = new DialogPanel(new Vector2(30, 240));
            dialogPanel = dialogpanel;

            actionbtns = new ActionBtns(new Vector2(0, 0), ScreenSize, dialogPanel);
            actionBtns = actionbtns;

            ActScreen = new ActScreen(new Vector2(0, 0));
            actScreen = ActScreen;

            ActPanel = new ActPanel(new Vector2(30, 240));
            actPanel = ActPanel;

            attackpanel = new AttackPanel(new Vector2(30, 240));
            attackPanel = attackpanel;

            runpanel = new RunPanel(new Vector2(30, 240));
            runPanel = runpanel;

            gOverScreen = new GOverScreen(ScreenSize);
            winScreen = new WinScreen(ScreenSize);
            runScreen = new RunScreen(ScreenSize);

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
                attackpanel.hitTime = 0;
                attackpanel.hitMisses = 0;
                enemyHits = 0;
                playerHits = 0;
                actionbtns.btnActions();
                Debug.WriteLine(state);

            }
            else if (state == State.PlayerAction)
            {
                var action = actionbtns.btnActions();
                if (action == ActionBtns.Actions.Attack)
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
                else if (action == ActionBtns.Actions.Act)
                {
                    placeholder.Add(actPanel);
                    Debug.WriteLine(state);
                    if (actionbtns.ActType == ActionBtns.ActTypes.Act1)
                    {
                        ActPanel.act1();
                        actionbtns.ActType = ActionBtns.ActTypes.Non;
                    }
                    else if (actionbtns.ActType == ActionBtns.ActTypes.Act2)
                    {
                        ActPanel.act2();
                        actionbtns.ActType = ActionBtns.ActTypes.Non;
                    }
                    else if (actionbtns.ActType == ActionBtns.ActTypes.Act3)
                    {
                        ActPanel.act3();
                        actionbtns.ActType = ActionBtns.ActTypes.Non;
                    }
                }
                else if (action == ActionBtns.Actions.Run)
                {
                    placeholder.Add(runPanel);
                    runScreen.playSound();
                    Debug.WriteLine(state);
                }
            }
            else if (state == State.StatusUpdate)
            {
                var updated = false;

                pHpNew = playerStat.Hp;
                eHpNew = enemy.Hp;
                playerHits = attackpanel.hitTime;
                enemyHits = attackpanel.hitMisses;

                attackPanel.Detach();

                if (!updated)
                {
                    pHpNew = playerStat.Hp - (enemy.Strength * enemyHits);
                    playerStat.Hp = pHpNew;
                    eHpNew = enemy.Hp - (playerStat.Strength * playerHits);
                    enemy.Hp = eHpNew;
                    playerStat.HpBar.Value = playerStat.Hp;
                    enemy.HpBar.Value = enemy.Hp;
                    playerStat.updateHp(playerStat.Hp);
                    enemy.updateHp(enemy.Hp);
                    updated = true;
                    Debug.WriteLine(enemyHits);
                }

                if (updated)
                {
                    if (playerStat.Hp <= 0 || enemy.Hp <= 0)
                    {
                        ChangeState(State.TurnEnd);
                        
                    } 
                    else
                    {
                        enemyHits = 0;
                        playerHits = 0;
                        ChangeState(State.PPreTurn);
                    }
                    updated = false;
                }

                Debug.WriteLine(state);

            }
            else if (state == State.TurnEnd)
            {
                if (!gOverScreen.played && !winScreen.played)
                {
                    if (playerStat.Hp <= 0)
                    {
                        gOverScreen.playSound();
                    }
                    else if (enemy.Hp <= 0)
                    {
                        winScreen.playSound();
                    }

                }

                if ((gOverScreen.played && !winScreen.played) || (winScreen.played && !gOverScreen.played))
                {
                    if (playerStat.Hp <= 0)
                    {
                        placeholder.Add(gOverScreen);
                        PressAnywhere();
                    }
                    else if (enemy.Hp <= 0)
                    {
                        placeholder.Add(winScreen);
                        PressAnywhere();
                    }
                }
            }
            else if (state == State.ExitBattle)
            {
                placeholder.Add(runScreen);
                PressAnywhere();
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
            if (ActPanel.finished == true)
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

        public void PressAnywhere()
        {
            var keyInfo = GlobalMouseInfo.Value;

            if (playerStat.Hp > 0 && state == State.TurnEnd) 
            {
                if (keyInfo.IsLeftButtonPressed())
                    placeholder.AddAction(new SequenceAction(Actions.FadeOut(1f, this), new RunAction(() => exitNotifier(this, 0))));
            }
            //else if (state == State.ExitBattle)
            //{
            //    if (keyInfo.IsLeftButtonPressed())
            //        placeholder.AddAction(new SequenceAction(Actions.FadeOut(1f, this), new RunAction(() => exitNotifier(this, 2))));
            //}
            else if (playerStat.Hp <= 0 || state == State.ExitBattle)
            {
                if (keyInfo.IsLeftButtonPressed())
                    placeholder.AddAction(new SequenceAction(Actions.FadeOut(1f, this), new RunAction(() => exitNotifier(this, 1))));
            }
        }
    }
}
