using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardManager : MonoBehaviour
{
    public BattleManager battleManager;
    public cardUI cardUI;
    public CardInstance cardInstance;
    public SigilManager sigilManager;

    [Header ("Board slots")]
    public Transform[] playerSlots = new Transform[5];
    public GameObject[] playerCards = new GameObject[5];

    public Transform[] enemySlots = new Transform[5];
    public GameObject[] enemyCards = new GameObject[5];

    public GameObject cardPrefab;


    [Header("Empty Slot Sprite")]
    // kto prochitaet tot lox

    public static BoardManager Instance;
    public void Awake()
    {
        Instance = this;
    }

    public void PlayCardThere(int boardIndex, GameObject obj)
    {
        GameObject spawned = Instantiate(obj, playerSlots[boardIndex]);
        playerCards[boardIndex] = spawned;
    }

    public void PlayForPlayer(int boardIndex, CardInstance card)
    {
        battleManager.playerBoard[boardIndex] = card;

        GameObject spawned = Instantiate(cardPrefab, playerSlots[boardIndex]);
        playerCards[boardIndex] = spawned;
        sigilManager.OnPlay(card, 0);

        cardUI ui = spawned.GetComponent<cardUI>();
        ui.SetCard(card);
    }
    public void PlayForEnemy(int boardIndex, CardInstance card)
    {
        battleManager.enemyBoard[boardIndex] = card;

        GameObject spawned = Instantiate(cardPrefab, enemySlots[boardIndex]);
        enemyCards[boardIndex] = spawned;
        sigilManager.OnPlay(card, 1);

        cardUI ui = spawned.GetComponent<cardUI>();
        ui.SetCard(card);
    }

    public void Rest(int turnsSince, CardInstance Stillness) {        
        battleManager.enemyBoard[turnsSince] = null;
        battleManager.enemyBoard[4-turnsSince] = null;

        if(enemyCards[turnsSince] != null) Destroy(enemyCards[turnsSince]);
        if(enemyCards[4-turnsSince] != null) Destroy(enemyCards[4-turnsSince]);

        GameObject spawned1 = Instantiate(cardPrefab, enemySlots[turnsSince]);
        GameObject spawned2 = Instantiate(cardPrefab, enemySlots[4-turnsSince]);
        enemyCards[turnsSince] = spawned1;
        enemyCards[4-turnsSince] = spawned2;

        battleManager.enemyBoard[turnsSince] = Stillness;
        battleManager.enemyBoard[4-turnsSince] = Stillness;

        cardUI ui1 = spawned1.GetComponent<cardUI>();
        cardUI ui2 = spawned2.GetComponent<cardUI>();
        ui1.SetCard(Stillness);
        ui2.SetCard(Stillness);
    }
    
    public void UpdateBoard()
    {
        for (int i = 0; i < 5; i++)
        {
            // Player
            if (battleManager.playerBoard[i] == null)
            {
                if (playerCards[i] != null)
                {
                    Destroy(playerCards[i]);
                    playerCards[i] = null;
                }
            }
            else
            {
                if (playerCards[i] != null)
                {
                    cardUI ui = playerCards[i].GetComponent<cardUI>();
                    ui.UpdateStats(battleManager.playerBoard[i]);
                }
            }

            // Enemy
            if (battleManager.enemyBoard[i] == null)
            {
                if (enemyCards[i] != null)
                {
                    Destroy(enemyCards[i]);
                    enemyCards[i] = null;
                }
            }
            else
            {
                if (enemyCards[i] != null)
                {
                    cardUI ui = enemyCards[i].GetComponent<cardUI>();
                    ui.UpdateStats(battleManager.enemyBoard[i]);
                }
            }
        }
    }
}