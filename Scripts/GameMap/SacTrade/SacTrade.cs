using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SacTrade : MonoBehaviour
{
    [Header("Player Deck")]
    public PlayerDeckData playerDeckData;

    [Header ("All Cards")]
    public PlayerDeckData allCards;

    [Header ("Shit")]
    public Image altarImage;
    public Button confirm;

    public Transform content;
    public GameObject cardPrefab;

    private List<GameObject> placedCard = new List<GameObject>();
    public CardData altarCard;

    public CardData selectedCard;

    public static SacTrade Instance;
    public void Awake() {
        Instance = this;
        RefreshDeck();
    }

    public void RefreshDeck() 
    {
        foreach (GameObject card in placedCard)
        {
            Destroy(card);
        }

        // Spawn new UI cards
        for (int i = 0; i < playerDeckData.cards.Count; i++)
        {
            GameObject obj = Instantiate(cardPrefab, content);

            cardUIEvents cardUI = obj.GetComponent<cardUIEvents>();

            cardUI.SetCardData(playerDeckData.cards[i]);

            placedCard.Add(obj);
        }
    }

    public void SelectedCard(CardData card) 
    {
        selectedCard = card;
    }

    public void PlaceCard()
    {
        if(selectedCard == null) return;

        altarCard = selectedCard;

        altarImage.sprite = altarCard.cardSprite;
        RefreshDeck();

        selectedCard = null;
    }

    public void SacrificeCard()
    {
        if(altarCard == null) return;

        playerDeckData.cards.Remove(altarCard);
        altarCard = null;
        RefreshDeck();
        
        BeGone();
    }

    public void BeGone() {
        
    }
}