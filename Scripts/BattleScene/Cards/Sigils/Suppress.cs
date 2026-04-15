using UnityEngine;

class Suppress : Sigil
{
    public override void OnPlay(CardInstance mainCard, int owner)
    {
        if(owner == 0)
        {
            foreach(CardInstance enemyCard in BattleManager.Instance.enemyBoard)
            {
                if(enemyCard == null) continue;
                enemyCard.currentAttack = 1;
            }
        }
        else
        {
            foreach(CardInstance playerCard in BattleManager.Instance.playerBoard)
            {
                if(playerCard == null) continue;
                playerCard.currentAttack = 1;
            }
        }
    }

    public override void OnTurnStart (CardInstance mainCard, int boardIndex, int owner)
    {
        if(owner == 0)
        {
            foreach(CardInstance enemyCard in BattleManager.Instance.enemyBoard)
            {
                if(enemyCard == null) continue;
                enemyCard.currentAttack = enemyCard.data.attack;
            }
        }
        else
        {
            foreach(CardInstance playerCard in BattleManager.Instance.playerBoard)
            {
                if(playerCard == null) continue;
                playerCard.currentAttack = playerCard.data.attack;
            }
        }
    }
}