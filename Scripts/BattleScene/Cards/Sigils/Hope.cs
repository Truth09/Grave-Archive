using UnityEngine;

class Hope : Sigil
{
    public override void OnTurnStart(CardInstance mainCard, int boardIndex, int owner)
    {
        if(owner == 0)
        {
            for(int i=0; i<5; i++)
            {
                if(BattleManager.Instance.playerBoard[i] == null) continue;
                if(BattleManager.Instance.playerBoard[i].currentHealth + 2 < BattleManager.Instance.playerBoard[i].data.health)
                {
                    BattleManager.Instance.playerBoard[i].currentHealth += 2;
                }
            }
        }
        else
        {
            for(int i=0; i<5; i++)
            {
                if(BattleManager.Instance.enemyBoard[i] == null) continue;
                if(BattleManager.Instance.enemyBoard[i].currentHealth + 2 < BattleManager.Instance.enemyBoard[i].data.health)
                {
                    BattleManager.Instance.enemyBoard[i].currentHealth += 2;
                }
            }
        }
    }
}
