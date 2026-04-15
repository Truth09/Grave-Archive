using UnityEngine;

class BoneAppetite : Sigil
{
    public override void OnPlay(CardInstance mainCard, int owner) {
        if(owner == 0) {
            mainCard.currentAttack = BattleManager.Instance.playerBones;
        }
        else {
            mainCard.currentAttack = EnemyAI.Instance.enemyBones;
        }
    }

    public override void OnTurnStart(CardInstance mainCard, int boardIndex, int owner) {
        if(owner == 0) {
            mainCard.currentAttack = BattleManager.Instance.playerBones;
        }
        else {
            mainCard.currentAttack = EnemyAI.Instance.enemyBones;
        }
    }
}