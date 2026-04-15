using UnityEngine;

class Flee : Sigil
{
    public override bool OnBeforeHit(CardInstance mainCard, CardInstance opposingCard, int owner)       // mainCard = target, opposingCard = attacker
    {
        int index = BattleManager.Instance.GetCardIndex(mainCard, owner);

        if(index == -1) return false;

        if(owner == 0)
        {
            if(BattleManager.Instance.playerBoard[index+1]  == null)
            {
                BattleManager.Instance.playerBoard[index+1] = mainCard;
                BattleManager.Instance.playerBoard[index] = null;
                return true;
            }
            else if(BattleManager.Instance.playerBoard[index-1] == null)
            {
                BattleManager.Instance.playerBoard[index-1] = mainCard;
                BattleManager.Instance.playerBoard[index] = null;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if(BattleManager.Instance.enemyBoard[index+1] == null)
            {
                BattleManager.Instance.enemyBoard[index+1] = mainCard;
                BattleManager.Instance.enemyBoard[index] = null;
                return true;
            }
            else if(BattleManager.Instance.enemyBoard[index-1] == null)
            {
                BattleManager.Instance.enemyBoard[index-1] = mainCard;
                BattleManager.Instance.enemyBoard[index] = null;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}