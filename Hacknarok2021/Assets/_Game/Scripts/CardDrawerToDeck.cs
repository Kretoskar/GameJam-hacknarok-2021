using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrawerToDeck : MonoBehaviour
{
    [SerializeField] private CardType _cardType;
    [SerializeField] private GameData _gameData;

    public CardType CardType => _cardType;
    
    
    private void OnMouseDown()
    {
        _gameData.AddAvailableCard(_cardType);
        FindObjectOfType<CardDrawerToDeckManager>().Drawn();
        Destroy(gameObject);
    }
}
