using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class CardInstance
{
    public CardData data;

    [Header("Stats")]
    public int currentHealth;
    public int currentAttack;

    public int playCost;                        // Energy
    public CostType costType;
    public int sacValue;
    public int boneValue;

    public List<Sigil> sigils;
    public Sprite cardSprite;

    public int turnsSince;

    public bool CantBeBypassed = false;

    public CardInstance(CardData data)
    {
        this.data = data;

        sigils = new List<Sigil>();
        foreach (SigilType type in data.sigils)
        {
            sigils.Add(SigilFactory.Create(type));
        }

        currentHealth = data.health;
        currentAttack = data.attack;

        costType = data.costType;
        playCost = data.playCost;
        sacValue = data.sacValue;
        boneValue = data.boneValue;
        

        cardSprite = data.cardSprite;
        if(data.sigils.Contains(SigilType.TooBig)) CantBeBypassed = true;

        turnsSince = 0;
    }

    public bool HasSigil(CardInstance card, SigilType sigil)
    {
        return card.data.sigils.Contains(sigil);
    }
}