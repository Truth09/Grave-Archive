using UnityEngine;

class Cornered : Sigil
{
    public override void OnGetHit(CardInstance mainCard, CardInstance opposingCard, int owner)
    {
        mainCard.currentAttack = (mainCard.data.health + 1) - mainCard.currentHealth;
        BoardManager.Instance.UpdateBoard();
    }

    public override void OnTurnStart(CardInstance mainCard, int boardIndex, int owner)
    {
        mainCard.currentAttack = (mainCard.data.health + 1) - mainCard.currentHealth;
        BoardManager.Instance.UpdateBoard();
    }
}