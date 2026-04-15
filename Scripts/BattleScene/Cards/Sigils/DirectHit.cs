using UnityEngine;

class DirectHit : Sigil
{
    public override void OnAttack(CardInstance mainCard, CardInstance opposingCard, int owner)
    {
        if(owner == 0)
        {
            BattleManager.Instance.enemyHealth -= mainCard.currentAttack;
        }
        else
        {
            BattleManager.Instance.playerHealth -= mainCard.currentAttack;
        }
    }
}