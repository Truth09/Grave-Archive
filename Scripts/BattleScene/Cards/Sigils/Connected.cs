using UnityEngine;

class Connected: Sigil
{
    public override void OnPlay(CardInstance mainCard, int owner)
    {
        CardInstance copy = mainCard;
        copy.playCost = 0;
        copy.sigils.Clear();
        
        if(owner == 0)
        {
            BattleManager.Instance.playerHand.Add(copy);
        }
        else
        {
            EnemyAI.Instance.enemyHand.Add(copy);
        }
    }

    public override void OnGetHit(CardInstance mainCard, CardInstance opposingCard, int owner)
    {
        if(owner == 0)
        {
            for(int i=0;i<5;i++)
            {
                if(BattleManager.Instance.playerBoard[i]== mainCard)    BattleManager.Instance.playerBoard[i].currentHealth -= opposingCard.currentAttack;
            }
        }
        else
        {
            for(int i=0;i<5;i++)
            {
                if(BattleManager.Instance.enemyBoard[i]== mainCard)    BattleManager.Instance.playerBoard[i].currentHealth -= opposingCard.currentAttack;
            }
        }
    }
}