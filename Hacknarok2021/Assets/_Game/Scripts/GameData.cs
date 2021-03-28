using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "xczxc", fileName = "ads")]
public class GameData : ScriptableObject
{
    [SerializeField] private bool _wasSleeping = false;
    [SerializeField] private List<CardType> _cardsLeft = null;
    [SerializeField] private List<CardType> _availableCards = new List<CardType>();
    [SerializeField] private int _politicsChange = 0;
    [SerializeField] private int _enviroChange = 0;
    [SerializeField] private int _healthCareChange = 0;

    public int PoliticsChange
    {
        get => _politicsChange;
        set => _politicsChange = value;
    }

    public int EnviroChange
    {
        get => _enviroChange;
        set => _enviroChange = value;
    }

    public int HealthCareChange
    {
        get => _healthCareChange;
        set => _healthCareChange = value;
    }

    public List<CardType> CardsLeft => _cardsLeft;
    
    private void OnEnable()
    {
        _cardsLeft = Enum.GetValues(typeof(CardType)).Cast<CardType>().ToList();
    }
    
    public bool WasSleeping
    {
        get => _wasSleeping;
        set { _wasSleeping = value; }
    }

    public List<CardType> AvailableCards => _availableCards;

    public void AddAvailableCard(CardType cardType)
    {
        _cardsLeft.Remove(cardType);
        _availableCards.Add(cardType);
    }

    public void RemoveAvailableCard(CardType cardType)
    {
        _availableCards.Remove(cardType);
    }
}
