public abstract class Sigil     // int owner: player = 0, enemy = 1
{
    public virtual void OnPlay(CardInstance mainCard, int owner) {}
    public virtual void OnTurnStart(CardInstance mainCard, int boardIndex, int owner) {}
    public virtual void OnAttack(CardInstance mainCard, CardInstance opposingCard, int owner) {}    // mainCard = attacker, opposingCard = getting attacked
    public virtual void OnGetHit(CardInstance mainCard, CardInstance opposingCard, int owner) {}    // mainCard = getting attacked, opposingCard = attacker
    public virtual void OnDeath(CardInstance mainCard, int boardIndex, int owner) {}

    public virtual void OnOtherCardPlay(CardInstance playedCard, int owner) {}
    public virtual bool OnBeforeHit(CardInstance mainCard, CardInstance opposingCard, int owner)    // mainCard = getting attacked, opposingCrad = attacker
    {
        return false;
    }
}