using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card Game/Card")]
public class CardData : ScriptableObject
{
    public int cardID;
    public string cardName;

    public int health;
    public int attack;

    public CostType costType;
    public int playCost;                
    public int sacValue = 1;
    public int boneValue = 1;

    public SigilType[] sigils;

    public Sprite cardSprite;
    public string description;
    public CardData evolvesInto;
}

public enum SigilType
{
    None,
    DirectHit,                          // Attack enemy directly, ignoring blockers, Phantom and Phoenix. DONE
    Flee,                               // Flee from attack, Talos. DONE, kinda
    Connected,                          // Cards that have this sigil will share taken damage, Twins. DONE
    Hope,                               // Heals allies, +2HP, Outpost. DONE
    Rage,                               // Buff allies, +2DMG, Transmission line. DONE
    Demise,                             // Kill all cards in 3 turns, Komarov. DONE
    Trap,                               // Kills enemy card when killed, Bear Trap. DONE
    Lonely,                             // Dies if not taken damage in 3 turns, Lonesome George. DONE
    Suppress,                           // Suppresses enemy cards damage down to 1 for 1 turn, Victor. DONE, kinda
    Growth,                             // Change after X turns, Strange Egg. DONE
    Cornered,                           // Less HP = more DMG, Lumivern. DONE
    SlotMachine,                        // Random HP and DMG when played, Slot Machine. DONE
    Return,                             // Come back from death ONCE, +6HP and +6DMG, White Stag. DONE
    Gatherer,                           // +2 energy while on board, Shaman. DONE
    Reflection,                         // Reflect damage back to attacker, Marta. DONE
    TooBig,                             // Card blocks DirectHit. DONE
    Immortal,                           // Card comes back to hand. DONE, but didn't tested yet
    Summon,                             // Summons a specific card when played. IDK, maybe later cards.
    Omen,                               // Steal sigil
    BloodLust,                          // Attack = Blood
    BoneAppetite                        // Attack = Bones
}

public enum CostType
{
    None,
    Energy,
    Blood,
    Bones
}