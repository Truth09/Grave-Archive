using UnityEngine;

class Omen : Sigil
{
    public override void OnGetHit(CardInstance mainCard, CardInstance opposingCard, int owner) {
        if(owner == 0) {
            int index = BattleManager.Instance.GetCardIndex(opposingCard, 1);
            BattleManager.Instance.enemyBoard[index].sigils.Clear();
        }
        else {
            int index = BattleManager.Instance.GetCardIndex(opposingCard, 0);
            BattleManager.Instance.playerBoard[index].sigils.Clear();
        }
    }
}