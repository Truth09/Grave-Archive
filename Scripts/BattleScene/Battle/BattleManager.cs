using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    [Header("Player Deck")]
    public PlayerDeckData playerDeckData;

    [Header("Deck & Hand")]
    public List<CardData> playerDeck;
    public List<CardInstance> playerHand;


    [Header("Boards (5 lanes)")]
    public CardInstance[] playerBoard = new CardInstance[5];
    public CardInstance[] enemyBoard = new CardInstance[5];


    [Header("HPs")]
    public int playerHealth = 30;
    public int enemyHealth;

    [Header("Energy")]
    public int currentEnergy = 3;
    public int maxEnergy = 10;
    public int energyPerTurn = 2;
    public int playerBones = 0;
    public int playerBlood = 0;

    [Header("Husk Card")]
    public CardData TheFool;                    // Card given by Husk Dispenser
    [Header("Husk amount")]
    public int huskAmount = 20;


    [Header("Script References")]
    public BoardManager boardManager;           // For updating the board visuals
    public HandUI handUI;                       // For updating the hand visuals
    public ValuesManager valuesManager;         // For updating HP and energy display
    public cardUI cardUI;                       // The thing to idk, visualize the cards both in hand and on board. Oh, also buttons.
    public EnemyAI enemyAI;                     // Enemy AI. Its random right now, and it only plays 1 card per turn, but it works for now.
    public SigilManager sigilManager;           // Sigil Manager. Idk why I named it processor.
    public CardInstance cardInstance;           // Instead of cloning the template, I will use this and im free to alter it as I wish.

    public CardData theWorld;
    public CardInstance Stillness;
    public int turnsSince = 0;

    public PlayerMode currentMode = PlayerMode.none;

    private CardData selectedCard;
    public bool receivedCard = false;           // Flag to check if player received a card this turn


    public static BattleManager Instance;
    private void Awake()
    {
        Instance = this;
        Stillness  = new CardInstance(theWorld);
    }


    void Start()
    {
        UnityEngine.Random.InitState(System.Environment.TickCount);
        playerDeck = new List<CardData>(playerDeckData.cards);
        playerHand = new List<CardInstance>();

        Shuffle(playerDeck);

        enemyHealth = enemyAI.enemyHP;
        StartBattle();
    }

    void StartBattle()
    {
        DrawStartingHand();
        boardManager.UpdateBoard();
        valuesManager.UpdateStats();

        enemyAI.EnemyStartingHand();
    }
    public static void Shuffle(List<CardData> deck)
    {
        for (int i = deck.Count - 1; i > 0; i--)
        {
            int rand = UnityEngine.Random.Range(0, i + 1);
            (deck[i], deck[rand]) = (deck[rand], deck[i]);
        }
    }


    void DrawStartingHand()
    {
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        if (playerDeck.Count == 0) return;

        int lastIndex = playerDeck.Count - 1;
        CardData data = playerDeck[lastIndex];
        playerDeck.RemoveAt(lastIndex);

        CardInstance card = new CardInstance(data);

        playerHand.Add(card);

        handUI.RefreshHand();
    }

    public void AddToHand(CardInstance card, int owner)
    {
        if(owner == 0)
        {
            playerHand.Add(card);
            handUI.RefreshHand();
        }
        else
        {
            enemyAI.enemyHand.Add(card);
        }
    }

    public int GetCardIndex(CardInstance card, int owner)
    {
        if(card == null) return -1;

        if(owner == 0)
        {
            return Array.IndexOf(playerBoard, card);
        }
        else
        {
            return Array.IndexOf(enemyBoard, card);
        }
    }
    

    public void PlayerAttackPhase()
    {
        for (int i = 0; i < 5; i++)
        {
            CardInstance playerCard = playerBoard[i];
            CardInstance enemyCard = enemyBoard[i];



            if (playerCard == null) continue; // No card to attack with
            if (enemyCard == null)
            {
                enemyHealth -= playerCard.currentAttack; // Attack enemy directly
                continue;
            }
            else if(playerCard.HasSigil(playerCard, SigilType.DirectHit) && !enemyCard.HasSigil(enemyCard, SigilType.TooBig))
            {
                enemyHealth -= playerCard.currentAttack;
            }
            else    // Deal damage to card
            {
                sigilManager.OnAttack(playerCard, enemyCard, 0);    // playerCard is attacking enemyCard

                bool cancelledAttack = sigilManager.OnBeforeHit(enemyCard, playerCard, 0);

                if(!cancelledAttack)
                {
                    enemyCard.currentHealth -= playerCard.currentAttack;

                    sigilManager.OnGetHit(enemyCard, playerCard, 0);    // enemyCard is getting attacked by playerCard
                }
                else
                {
                    enemyHealth -= playerCard.currentAttack;
                }

                if (enemyCard.currentHealth <= 0)
                    KillEnemyCard(i); // Card dies
            }



            if (enemyHealth <= 0)
            {
                SceneManager.LoadScene("GameMap");
            }
            else if (playerHealth <= 0)
            {
                SceneManager.LoadScene("GameMap");
            } 
        }
    }

    public void EnemyAttackPhase()
    {
        for (int i = 0; i < 5; i++)
        {
            CardInstance playerCard = playerBoard[i];
            CardInstance enemyCard = enemyBoard[i];

            if (enemyCard == null) continue; // No card to attack with
            if (playerCard == null)
            {
                playerHealth -= enemyCard.currentAttack; // Attack player directly
                continue;
            }
            else if(enemyCard.HasSigil(enemyCard, SigilType.DirectHit) && !playerCard.HasSigil(playerCard, SigilType.TooBig))
            {
                playerHealth -= enemyCard.currentAttack;
            }
            else    // Deal damage to card
            {
                sigilManager.OnAttack(enemyCard, playerCard, 0);    // playerCard is attacking enemyCard

                bool cancelledAttack = sigilManager.OnBeforeHit(playerCard, enemyCard, 0);

                if(!cancelledAttack)
                {
                    playerCard.currentHealth -= enemyCard.currentAttack;

                    sigilManager.OnGetHit(playerCard, enemyCard, 0);    // enemyCard is getting attacked by playerCard
                }
                else
                {
                    playerHealth -= enemyCard.currentAttack;
                }

                if (playerCard.currentHealth <= 0)
                    KillPlayerCard(i); // Card dies
            }





            if (enemyHealth <= 0)
            {
                SceneManager.LoadScene("GameMap");
            }
            else if (playerHealth <= 0)
            {
                SceneManager.LoadScene("GameMap");
            } 
        }
    }

    public void OnHuskDispenserClicked()    // Adds a Husk card to the player's hand
    {
        if (huskAmount <= 0 || receivedCard) return;    // No more husks available and player hasn't received a card this turn
        receivedCard = true;
        CardInstance theFool = new CardInstance(this.TheFool);
        playerHand.Add(theFool);
        huskAmount--;
        handUI.RefreshHand();
    }
    public void OnRandomCardDispenserClicked()    // I have to make separate function for this shit, because UNity is dumb piece of shit
    {
        if (playerDeck.Count == 0 || receivedCard) return;
        receivedCard = true;
        DrawCard();
    }
    

    public void KillPlayerCard(int boardIndex)
    {
        if(playerBoard[boardIndex] == null) return;

        sigilManager.OnDeath(playerBoard[boardIndex], boardIndex, 0);

        playerBoard[boardIndex] = null;
        playerBones++;
        boardManager.UpdateBoard();
        handUI.RefreshHand();
    }
    public void KillEnemyCard(int boardIndex)
    {
        if(enemyBoard[boardIndex] == null) return;
        
        sigilManager.OnDeath(enemyBoard[boardIndex], boardIndex, 1);

        enemyBoard[boardIndex] = null;
        boardManager.UpdateBoard();
        handUI.RefreshHand();
    }


    public void EndTurn()
    {
        currentMode = PlayerMode.none;

        if(playerDeck.Count == 0 && huskAmount == 0 && turnsSince < 5) {
            boardManager.Rest(turnsSince, Stillness);
            boardManager.Rest(4-turnsSince, Stillness);

            turnsSince++;
        }

        for (int i = 0; i < 5; i++)
        {
            if (playerBoard[i] != null) {
                sigilManager.OnTurnStart(playerBoard[i], i, 0);
            }
            if (enemyBoard[i] != null) {
                sigilManager.OnTurnStart(enemyBoard[i], i, 1);
            }
        }

        receivedCard = false;   // Reset card received flag for next turn
        
        if (currentEnergy < maxEnergy)
            currentEnergy += energyPerTurn;
        if (enemyAI.enemyEnergy < enemyAI.maxEnemyEnergy)
            enemyAI.enemyEnergy += energyPerTurn;


        PlayerAttackPhase();

        enemyAI.EnemyPlay();

        //EnemyAttackPhase();

        valuesManager.UpdateStats();
        boardManager.UpdateBoard();
    }


    public void DaggerMode()
    {
        if(currentMode == PlayerMode.none)
        {
            currentMode = PlayerMode.Dagger;
        }
        else if(currentMode == PlayerMode.Dagger)
        {
            currentMode = PlayerMode.none;
        }
    }   
}


public enum PlayerMode
{
    none,
    Dagger
}