using System.Collections.Generic;
using UnityEngine;

public class EnemyAI: MonoBehaviour
{
    [Header("References")]
    public BattleManager battleManager;
    public CardInstance cardInstance;
    public SigilManager sigilManager;
    public BoardManager boardManager;

    [Header("Enemy Stats")]
    public PlayerDeckData enemyDeckData;
    public int enemyHP = 30;
    public int enemyEnergy = 3;
    public int maxEnemyEnergy = 10;
    public int enemyBlood = 0;
    public int enemyBones = 0;

    public int enemyHuskAmount = 20;

    [Header("Enemy Deck & Hand")]
    public List<CardData> enemyDeck;
    public List<CardInstance> enemyHand;
    public CardData TheFool;
    public bool hasDrawnCard = false;


    public static EnemyAI Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        enemyDeck = new List<CardData>(enemyDeckData.cards);
        enemyHand = new List<CardInstance>();
        Shuffle(enemyDeck);
        EnemyStartingHand();
    }

    public void EnemyStartingHand()     // Enemy gets 5 cards
    {
        for (int i = 0; i < 5; i++)
        {
            GetCard();
        }
    }

    public static void Shuffle(List<CardData> deck)
    {
        for (int i = deck.Count - 1; i > 0; i--)
        {
            int rand = UnityEngine.Random.Range(0, i + 1);
            (deck[i], deck[rand]) = (deck[rand], deck[i]);
        }
    }

    public void EnemyPlay()
    {
        if (!hasDrawnCard)
        {
            int rand = Random.Range(0,2);
 
            if(rand == 0 && enemyDeck.Count != 0) GetCard();    // rolled for 0, try to draw from deck
            else GetHusk();                                     // Couldn't draw from deck, try husk deck

            if(rand == 2 && enemyHuskAmount > 0) GetHusk();     // rolled 1, try to draw from husk deck
            else GetCard();                                     // couldn't draw drom husk deck, try deck

        }
        
        List<CardInstance> playableCards = new List<CardInstance>();

        for (int i = 0; i < enemyHand.Count; i++)
        {
            if (enemyHand[i] != null && enemyHand[i].playCost <= enemyEnergy)
            {
                playableCards.Add(enemyHand[i]);
            }
        }

        if (playableCards.Count == 0)
        {
            hasDrawnCard = false;
            return;
        }

        CardInstance card = playableCards[Random.Range(0, playableCards.Count)];

        if(card == null) return;

        bool emptySlotFound = false;
        for (int i =0; i < 4; i++)
        {
            if (battleManager.enemyBoard[i] == null)
            {
                emptySlotFound = true;
                break;
            }
        }

        if (!emptySlotFound)
        {
            hasDrawnCard = false;
            return;
        }

        int randSlot = Random.Range(0, battleManager.enemyBoard.Length);
        while (battleManager.enemyBoard[randSlot] != null)
        {            
            randSlot = Random.Range(0, battleManager.enemyBoard.Length);
        }

        sigilManager.OnPlay(card, 1);

        boardManager.PlayForEnemy(randSlot, card);
        
        enemyEnergy -= card.playCost;
        enemyHand.Remove(card);

        if(playableCards.Count > 0 && enemyEnergy > 0) EnemyPlay();

        battleManager.boardManager.UpdateBoard();
        battleManager.valuesManager.UpdateStats();
    }



    public void GetHusk()
    {
        if(enemyHuskAmount <= 0) return;

        enemyHand.Add(new CardInstance(TheFool));
        enemyHuskAmount --;

        hasDrawnCard = true;
    }
    public void GetCard()
    {
        if (enemyDeck.Count == 0) return;

        int lastIndex = enemyDeck.Count - 1;
        CardData data = enemyDeck[lastIndex];
        enemyDeck.RemoveAt(lastIndex);

        CardInstance card = new CardInstance(data);

        enemyHand.Add(card);

        hasDrawnCard = true;
    }
}
