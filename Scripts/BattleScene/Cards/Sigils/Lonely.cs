using UnityEngine;

class Lonely: Sigil
{
    public override void OnPlay(CardInstance mainCard, int owner)
    {
        mainCard.turnsSince = 0;
    }

    public override void OnTurnStart(CardInstance mainCard, int boardIndex, int owner)
    {
        mainCard.turnsSince++;

        if (mainCard.turnsSince == 3)
        {
            if(owner == 0)
            {
                BattleManager.Instance.KillPlayerCard(boardIndex);
            }
            else
            {
                BattleManager.Instance.KillEnemyCard(boardIndex);
            }
        }
    }
}