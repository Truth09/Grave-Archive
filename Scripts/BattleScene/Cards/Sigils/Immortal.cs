using UnityEngine;

public class Immortal: Sigil
{
    public override void OnDeath(CardInstance mainCard, int boardIndex, int owner)
    {
        if(owner == 0)
        {
            BattleManager.Instance.playerHand.Add(mainCard);
        }
        else
        {
            EnemyAI.Instance.enemyHand.Add(mainCard);
        }
    }
}