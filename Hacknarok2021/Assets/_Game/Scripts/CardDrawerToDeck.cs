using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardDrawerToDeck : MonoBehaviour
{
    [SerializeField] private CardType _cardType;
    [SerializeField] private GameData _gameData;
    [SerializeField] private float _drawSingleCardTime = .5f;

    public CardType CardType => _cardType;
    
    
    private void OnMouseDown()
    {
        _gameData.AddAvailableCard(_cardType);
        FindObjectOfType<CardDrawerToDeckManager>().Drawn();
        
        transform.DOMove(transform.position - new Vector3(0,10,0), _drawSingleCardTime);
    }
}
