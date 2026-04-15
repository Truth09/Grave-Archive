using UnityEngine;

class TooBig: Sigil
{
    public override void OnGetHit(CardInstance mainCard, CardInstance opposingCard, int owner)
    {
        mainCard.currentHealth -= opposingCard.currentAttack;
    }
}