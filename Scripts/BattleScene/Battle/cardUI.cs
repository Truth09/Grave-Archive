using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cardUI : MonoBehaviour
{
    public TextMeshProUGUI currentHealth;
    public TextMeshProUGUI currentAttack;

    public TextMeshProUGUI playCost;
    public TextMeshProUGUI bloodCost;
    public TextMeshProUGUI boneCost;

    public Image cardImage;

    public CostType costType;

    public PlayCard playCard;
    public CardInstance cardInstance;
    public GameObject cardPrefab;

    public void SetCard(CardInstance card)
    {
        cardInstance = card;
        costType = card.costType;
        cardImage.sprite = card.cardSprite;

        currentHealth.text = card.currentHealth.ToString();
        currentAttack.text = card.currentAttack.ToString();

        playCost.text = "";
        bloodCost.text = "";
        boneCost.text = "";

        if(costType == CostType.Energy) playCost.text = card.playCost.ToString();
        if(costType == CostType.Blood) bloodCost.text = card.playCost.ToString();
        if(costType == CostType.Bones) boneCost.text = card.playCost.ToString();
    }

    public void SetCardData(CardData card) 
    {
        cardImage.sprite = card.cardSprite;

        currentHealth.text = card.health.ToString();
        currentAttack.text = card.attack.ToString();
        playCost.text = card.playCost.ToString();
    }

    public void UpdateStats(CardInstance card)
    {
        if (card == null)
        {
            currentHealth.text = "69";
            currentAttack.text = "69";
            return;
        }
        currentAttack.text = card.currentAttack.ToString();
        currentHealth.text = card.currentHealth.ToString();
        playCost.text = card.playCost.ToString();
    }


    public void SelectedCard()
    {
        PlayCard.Instance.SelectCard(cardInstance);
    }
    public void SelectedPrefab()
    {
        PlayCard.Instance.SelectedPrefab(cardPrefab);
    }

    public void Sacrifice()
    {
        if(BattleManager.Instance.currentMode == PlayerMode.Dagger) 
        {
            int index = BattleManager.Instance.GetCardIndex(cardInstance, 0);
            BattleManager.Instance.KillPlayerCard(index);
            BattleManager.Instance.playerBlood += cardInstance.sacValue;
        }
    }
}