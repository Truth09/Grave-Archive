using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gift : MonoBehaviour
{
    [Header ("All Cards")]
    public PlayerDeckData allCards;

    [Header("Player Deck")]
    public PlayerDeckData playerDeckData;

    [Header ("Shit")]
    public Image card0;
    public Image card1;
    public Image card2;

    public void Awake() {
        Shuffle(allCards);

        card0.sprite = allCards.cards[0].cardSprite;
        card1.sprite = allCards.cards[1].cardSprite;
        card2.sprite = allCards.cards[2].cardSprite;
    }

    public static void Shuffle(PlayerDeckData deck)
    {
        for (int i = deck.cards.Count - 1; i > 0; i--)
        {
            int rand = UnityEngine.Random.Range(0, i + 1);
            (deck.cards[i], deck.cards[rand]) = (deck.cards[rand], deck.cards[i]);
        }
    }

    public void option0() {
        playerDeckData.cards.Add(allCards.cards[0]);
        SceneManager.LoadScene("GameMap");
    }
    public void option1() {
        playerDeckData.cards.Add(allCards.cards[1]);
        SceneManager.LoadScene("GameMap");
    }
    public void option2() {
        playerDeckData.cards.Add(allCards.cards[2]);
        SceneManager.LoadScene("GameMap");
    }
}