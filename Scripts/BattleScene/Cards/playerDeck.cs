using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDeck", menuName = "Card Game/Player Deck")]
public class PlayerDeckData : ScriptableObject
{
    public List<CardData> cards = new List<CardData>();
}