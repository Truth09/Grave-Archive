public static class SigilFactory
{
    public static Sigil Create(SigilType type)
    {
        switch (type)
        {
            case SigilType.SlotMachine:         // Slot Machine
                return new SlotMachine();
            case SigilType.Trap:                // Trap
                return new Trap();
            case SigilType.Growth:              // Growth
                return new Growth();
            case SigilType.Lonely:              // Lonely
                return new Lonely();
            case SigilType.TooBig:              // Too Big
                return new TooBig();
            case SigilType.Gatherer:            // Gatherer
                return new Gatherer();
            case SigilType.Demise:              // Demise
                return new Demise();
            case SigilType.Connected:           // Connected
                return new Connected();
            case SigilType.Hope:                // Hope
                return new Hope();
            case SigilType.Rage:                // Rage
                return new Rage();
            case SigilType.Reflection:          // Reflection
                return new Reflection();
            case SigilType.Return:              // Return
                return new Return();
            case SigilType.Immortal:            // Immortal
                return new Immortal();
            case SigilType.Cornered:            // Cornered
                return new Cornered();
            case SigilType.DirectHit:           // Direct Hit
                return new DirectHit();
            case SigilType.Suppress:            // Suppress
                return new Suppress();
            case SigilType.Flee:                // Flee
                return new Flee();
            case SigilType.Omen:                // Omen
                return new Omen();
            case SigilType.BloodLust:           // Blood Lust
                return new BloodLust();
            case SigilType.BoneAppetite:        // Bone Appetite
                return new BoneAppetite();
            

            // add more sigils here
            // case SigilType.XXX:
            //     return new XXX();

            default:
                return null;
        }
    }
}