using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoppedCards : MonoBehaviour
{
    [SerializeField] private List<Transform> _tweens;

    public List<CardInfo> DroppedCards => _droppedCards;

    private List<CardInfo> _droppedCards;
    private int _currIndex = -1;

    private void Start()
    {
        _currIndex = -1;
        _droppedCards = new List<CardInfo>();
    }
    
    public Transform DropCard(CardInfo card)
    {
        _droppedCards.Add(card);
        _currIndex++;
        return _tweens[_currIndex];
    }
}
