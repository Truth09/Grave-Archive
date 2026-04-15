using UnityEngine;

public class Reflection : Sigil
{
    public override void OnGetHit(CardInstance mainCard, CardInstance opposingCard, int owner)
    {
        opposingCard.currentHealth -= opposingCard.currentAttack;
    }
}