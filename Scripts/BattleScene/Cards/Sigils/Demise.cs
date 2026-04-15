using UnityEngine;

class Demise: Sigil
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
                BattleManager.Instance.KillPlayerCard(BattleManager.Instance.GetCardIndex(mainCard, 0));
                for(int i = 0; i < 5; i++)
                {
                    BattleManager.Instance.KillEnemyCard(i);
                }
            }
            else
            {
                BattleManager.Instance.KillEnemyCard(BattleManager.Instance.GetCardIndex(mainCard, 1));
                for(int i = 0; i < 5; i++)
                {
                    BattleManager.Instance.KillPlayerCard(i);
                }
            }
        }
    }
}