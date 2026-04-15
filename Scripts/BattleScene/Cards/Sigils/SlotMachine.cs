using UnityEngine;

class SlotMachine: Sigil        // Sigil is extension here -> class SlotMahince extends Sigil
{
    public override void OnPlay(CardInstance card, int owner)
    {
        int rHealth = Random.Range(1, 15);
        int rAttack = Random.Range(1, 15);

        card.currentHealth = rHealth;
        card.currentAttack = rAttack;
    }
}