using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using ThanaNita.MonoGameTnt;
using static System.Net.Mime.MediaTypeNames;
using Text = ThanaNita.MonoGameTnt.Text;

namespace Project3_1
{
    public class CombatScreen : Actor
    {
        ExitNotifier exitNotifier;
        Game1 game1;
        private enum State { Init, PPreTurn, PlayerAction, EnemyReaction, StatusUpdate, EPreTurn, EnemyAction, PlayerReaction, TurnEnd }
        private State state = State.Init;
        private bool dialogDone, atkClicked, chooseAtk = false;
        Panel panel;
        Text text;
        Placeholder placeholder = new Placeholder();
        Button atkBtn, actBtn, runBtn, ltBtn, htBtn;
        string[] str;
        public CombatScreen(Vector2 ScreenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            var dialogPanel = new DialogPanel(new Vector2(30, 240));
            placeholder.Add(dialogPanel);

            //var playerHpBar = new PlayerHpBar(new Vector2(30, 390));
            //placeholder.Add(playerHpBar);
            var actionbtns = new ActionBtns(new Vector2(0, 0), ScreenSize, dialogPanel);
            placeholder.Add(actionbtns);


            Add(placeholder);
        }

    }
}
