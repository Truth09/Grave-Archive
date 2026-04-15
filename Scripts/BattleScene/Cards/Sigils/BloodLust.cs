using UnityEngine;

class BloodLust : Sigil
{
    public override void OnPlay(CardInstance mainCard, int owner) {
        if(owner == 0) {
            mainCard.currentAttack = BattleManager.Instance.playerBlood;
        }
        else {
            mainCard.currentAttack = EnemyAI.Instance.enemyBlood;
        }
    }

    public override void OnTurnStart(CardInstance mainCard, int boardIndex, int owner) {
        if(owner == 0) {
            mainCard.currentAttack = BattleManager.Instance.playerBlood;
        }
        else {
            mainCard.currentAttack = EnemyAI.Instance.enemyBlood;
        }
    }
}
