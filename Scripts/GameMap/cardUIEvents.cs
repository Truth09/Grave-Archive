using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cardUIEvents : MonoBehaviour
{
    public TextMeshProUGUI currentHealth;
    public TextMeshProUGUI currentAttack;
    public TextMeshProUGUI playCost;
    public Image cardImage;


    public CardInstance cardInstance;
    public CardData cardData;
    public GameObject cardPrefab;

    public void SetCard(CardInstance card)
    {
        cardInstance = card;
        cardImage.sprite = card.cardSprite;

        currentHealth.text = card.currentHealth.ToString();
        currentAttack.text = card.currentAttack.ToString();
        playCost.text = card.playCost.ToString();
    }

    public void SetCardData(CardData card) 
    {
        cardData = card;

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
        Sacrifice.Instance.SelectedCard(cardData);
    }
}