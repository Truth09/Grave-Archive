using UnityEngine;

class Return : Sigil
{
    public override void OnDeath(CardInstance mainCard, int boardIndex, int owner)
    {
        CardInstance copy = new CardInstance(mainCard.data);
        copy.currentHealth = 10;
        copy.currentAttack = 10;
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
}