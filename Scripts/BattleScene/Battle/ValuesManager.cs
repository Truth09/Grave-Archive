using UnityEngine;
using TMPro;

public class ValuesManager : MonoBehaviour
{
    public TextMeshProUGUI playerHp;
    public TextMeshProUGUI playerPower;
    public TextMeshProUGUI enemyHp;

    public BattleManager battleManager;


    public static ValuesManager Instance;
    public void Awake()
    {
        Instance = this;
    }

    
    public void UpdateStats()
    {
        playerHp.text = "HP: " + battleManager.playerHealth;
        playerPower.text = "Power: " + battleManager.currentEnergy;
        enemyHp.text = "Enemy HP: " + battleManager.enemyHealth;
    }
}