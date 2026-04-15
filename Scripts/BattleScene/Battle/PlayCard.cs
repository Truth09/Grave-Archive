using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayCard : MonoBehaviour
{
    public BattleManager battleManager;
    public CardInstance selectedCard;
    public SigilManager sigilManager;
    public ValuesManager valuesManager;
    public BoardManager boardManager;
    public cardUI cardUI;
    public GameObject cardPrefab;

    public static PlayCard Instance;
    public void Awake()
    {
        Instance = this;
    }

    public void SelectCard(CardInstance card)
    {
        selectedCard = card;
    }
    public void SelectedPrefab(GameObject card)
    {
        cardPrefab = card;
    }

    public void PlayCardOn(int boardIndex)
    {
        if (selectedCard == null || battleManager.playerBoard[boardIndex] != null) return;
        
        if(selectedCard.costType == CostType.Energy && !(battleManager.currentEnergy < selectedCard.playCost)) return;
        if(selectedCard.costType == CostType.Blood && !(battleManager.playerBlood < selectedCard.playCost)) return;
        if(selectedCard.costType == CostType.Bones && !(battleManager.playerBones < selectedCard.playCost)) return;


        CardInstance card = selectedCard;
        GameObject obj = cardPrefab;

        obj.GetComponent<Image>().sprite = card.cardSprite;
        cardUI.UpdateStats(card);

        boardManager.PlayForPlayer(boardIndex, card);

        battleManager.playerBoard[boardIndex] = card;
        cardUI.UpdateStats(card);
        battleManager.playerHand.Remove(card);

        if(selectedCard.costType == CostType.Energy && !(battleManager.currentEnergy < selectedCard.playCost)) battleManager.currentEnergy -= card.playCost;
        if(selectedCard.costType == CostType.Blood && !(battleManager.playerBlood < selectedCard.playCost)) battleManager.playerBlood -= card.playCost;
        if(selectedCard.costType == CostType.Bones && !(battleManager.playerBones < selectedCard.playCost)) battleManager.playerBones -= card.playCost;
        
        foreach(CardInstance c in battleManager.playerBoard)
        {
            if(c == null || c == card) continue;

            foreach(Sigil sigil in c.sigils)
            {
                sigil.OnOtherCardPlay(card, 0);
            }
        }

        battleManager.handUI.RefreshHand();
        boardManager.UpdateBoard();
        valuesManager.UpdateStats();

        selectedCard = null;
    }

    public void PlayCardSlot0()
    {
        PlayCardOn(0);
    }

    public void PlayCardSlot1()
    {
        PlayCardOn(1);
    }

    public void PlayCardSlot2()
    {
        PlayCardOn(2);
    }

    public void PlayCardSlot3()
    {     
        PlayCardOn(3);
    }

    public void PlayCardSlot4()
    {
        PlayCardOn(4);
    }
}