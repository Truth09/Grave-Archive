using UnityEngine;

class Trap: Sigil
{
    public override void OnDeath(CardInstance card, int boardIndex, int owner)
    {
        if (owner == 0)
        {
            BattleManager.Instance.KillEnemyCard(boardIndex);
        }
        else
        {
            BattleManager.Instance.KillPlayerCard(boardIndex);
        }
    }
}