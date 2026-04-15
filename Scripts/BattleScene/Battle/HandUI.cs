using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour
{
    public BattleManager battleManager;
    public Transform content;
    public GameObject cardPrefab;

    private List<GameObject> spawnedCards = new List<GameObject>();

    public void RefreshHand()
    {
        List<CardInstance> playerHand = battleManager.playerHand;

        // Clear old UI
        foreach (GameObject card in spawnedCards)
        {
            Destroy(card);
        }
        spawnedCards.Clear();

        // Spawn new UI cards
        for (int i = 0; i < playerHand.Count; i++)
        {
            GameObject obj = Instantiate(cardPrefab, content);

            cardUI cardUI = obj.GetComponent<cardUI>();
            cardUI.SetCard(playerHand[i]);

            spawnedCards.Add(obj);
        }
    }
}