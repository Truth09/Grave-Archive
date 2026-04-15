using UnityEngine;

class Growth: Sigil
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
            var evolved = new CardInstance(mainCard.data.evolvesInto);
            if(owner == 0)
            {
                BattleManager.Instance.KillPlayerCard(boardIndex);
                BoardManager.Instance.PlayForPlayer(boardIndex, evolved);
                BoardManager.Instance.UpdateBoard();
            }
            else
            {
                BattleManager.Instance.KillEnemyCard(boardIndex);
                BoardManager.Instance.PlayForEnemy(boardIndex, evolved);
                BoardManager.Instance.UpdateBoard();
            }
        }
    }
}