using UnityEngine;

class Gatherer : Sigil
{
    public override void OnTurnStart(CardInstance mainCard, int boardIndex, int owner)
    {
        if(owner == 0 && BattleManager.Instance.currentEnergy < BattleManager.Instance.maxEnergy) // player
        {
            BattleManager.Instance.currentEnergy++;
        }
        else if(EnemyAI.Instance.enemyEnergy < EnemyAI.Instance.maxEnemyEnergy)
        {
            EnemyAI.Instance.enemyEnergy++;
        }
    }
}
