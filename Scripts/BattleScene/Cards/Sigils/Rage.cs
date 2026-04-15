using UnityEngine;

class Rage : Sigil
{
    public override void OnTurnStart(CardInstance mainCard, int boardIndex, int owner)
    {
        if(owner == 0)
        {
            for(int i=0; i<5; i++)
            {
                if(BattleManager.Instance.playerBoard[i] == null || BattleManager.Instance.playerBoard[i] == mainCard) continue;
                BattleManager.Instance.playerBoard[i].currentAttack = BattleManager.Instance.playerBoard[i].currentAttack + 2;
            }
        }
        else
        {
            for(int i=0; i<5; i++)
            {
                if(BattleManager.Instance.enemyBoard[i] == null || BattleManager.Instance.enemyBoard[i] == mainCard) continue;
                BattleManager.Instance.enemyBoard[i].currentAttack = BattleManager.Instance.enemyBoard[i].currentAttack + 2;
            }
        }
    }

    public override void OnDeath(CardInstance mainCard, int boardIndex, int owner)
    {
        if(owner == 0)
        {
            for(int i=0; i<5; i++)
            {
                if(BattleManager.Instance.playerBoard[i] == null) continue;
                BattleManager.Instance.playerBoard[i].currentAttack = BattleManager.Instance.playerBoard[i].data.attack;
            }
        }
        else
        {
            for(int i=0; i<5; i++)
            {
                if(BattleManager.Instance.enemyBoard[i] == null) continue;
                BattleManager.Instance.enemyBoard[i].currentAttack = BattleManager.Instance.enemyBoard[i].data.attack;
            }
        }
    }

    public override void OnOtherCardPlay(CardInstance playedCard, int owner)
    {
        if(owner == 0)
        {
            playedCard.currentAttack += 2;
        }
        else
        {
            playedCard.currentAttack += 2;
        }
    }
}
