using UnityEngine;
using System.Collections.Generic;

public class SigilManager: MonoBehaviour
{    
    public void OnPlay(CardInstance mainCard, int owner)
    {
        foreach (Sigil sigil in new List<Sigil>(mainCard.sigils))
        {
            sigil.OnPlay(mainCard, owner);
        }
    }

    public void OnTurnStart(CardInstance mainCard, int boardIndex, int owner)
    {
        foreach (Sigil sigil in mainCard.sigils)
        {
            sigil.OnTurnStart(mainCard, boardIndex, owner);
        }
    }

    public void OnAttack(CardInstance mainCard, CardInstance opposingCard, int owner)
    {
        
    }
    public void OnGetHit(CardInstance mainCard, CardInstance opposingCard, int owner)
    {
        foreach (Sigil sigil in mainCard.sigils)
        {
            sigil.OnGetHit(mainCard, opposingCard, owner);
        }
    }

    public void OnDeath(CardInstance mainCard, int boardIndex, int owner)
    {
        foreach (Sigil sigil in mainCard.sigils)
        {
            sigil.OnDeath(mainCard, boardIndex, owner);
        }
    }

    public bool OnBeforeHit(CardInstance mainCard, CardInstance opposingCard, int owner)
    {
        foreach (Sigil sigil in mainCard.sigils)
        {
            sigil.OnBeforeHit(mainCard, opposingCard, owner);
        }
        return false;
    }
}