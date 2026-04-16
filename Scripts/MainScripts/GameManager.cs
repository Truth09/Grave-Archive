using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header ("Player deck")]
    public PlayerDeckData playerDeckData;

    [Header ("Player money")]
    public int playerMoney;



    public static GameManager Instance;
    public void Awake()
    {
        Instance = this;
    }



    public void LoadMap()
    {
        SceneManager.LoadScene("GameMap");
    }     // The Map

    public void LoadBattle()
    {
        SceneManager.LoadScene("BattleScene");
    }     // Battle

    public void RandomCard()
    {
        SceneManager.LoadScene("Gift");
    }     // Choose a card between X amount of card

    public void DeleteCard()
    {
        SceneManager.LoadScene("Sacrifice");
    }     // Delete a card from the deck

    public void Trade()
    {
        SceneManager.LoadScene("SacTrade");
    }     // Sacrifice your card to the cultists, and get other card of your choice

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }     // Switch to main menu, also save the current position on the map
}
