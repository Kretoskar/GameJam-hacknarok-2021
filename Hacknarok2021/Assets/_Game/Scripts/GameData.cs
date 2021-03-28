using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "xczxc", fileName = "ads")]
public class GameData : ScriptableObject
{
    [SerializeField] private bool _wasSleeping = false;
    [SerializeField] private List<Card> _allCardsPrefabs = null;
    [SerializeField] private List<CardType> _availableCards = new List<CardType>();

    public bool WasSleeping
    {
        get => _wasSleeping;
        set { _wasSleeping = value; }
    }

    public List<Card> AllCardsPrefabs => _allCardsPrefabs;

    public List<CardType> AvailableCards => _availableCards;

    public void AddAvailableCard(CardType cardType)
    {
        _availableCards.Add(cardType);
    }

    public void RemoveAvailableCard(CardType cardType)
    {
        _availableCards.Remove(cardType);
    }
}
