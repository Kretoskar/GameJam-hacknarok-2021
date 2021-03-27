using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private float _moveAllCardsBy = .5f;
    [SerializeField] private float _moveAllCardsTime = .3f;
    [SerializeField] private float _moveSingleCardTime = .01f;
    [SerializeField] private int _sortingOrderOnHover = 100;
    [SerializeField] private GameObject _gfx;

    private SpriteRenderer _spriteRenderer;
    
    private Vector3 _handUpPos;
    private Vector3 _handDownPos;
    
    private Transform _allCardsParent = null;
    private Hand _hand = null;

    private int _startingSortingOrder;
    private bool _isOver = false;

    private void Start()
    {
        _spriteRenderer = _gfx.GetComponent<SpriteRenderer>();
        _startingSortingOrder = _spriteRenderer.sortingOrder;
        
        
        _allCardsParent = transform.parent;
        _hand = _allCardsParent.GetComponent<Hand>();

        _handDownPos = _hand.transform.position;
        _handUpPos = _handDownPos + new Vector3(0, _moveAllCardsBy, 0);
    }

    public void SetStartingSortingOrder(int order)
    {
        _spriteRenderer = _gfx.GetComponent<SpriteRenderer>();
        _spriteRenderer.sortingOrder = order;
        _startingSortingOrder = order;
    }
    
    void OnMouseOver()
    {
        if(_isOver) return;

        transform.DOLocalMove(transform.localPosition + new Vector3(0,1,0), _moveSingleCardTime);
        _spriteRenderer.sortingOrder = _sortingOrderOnHover;
        
        _isOver = true;
        
        if(_hand.IsUp)
            return;
            
        _allCardsParent.DOMove(_handUpPos, _moveAllCardsTime);

        _hand.IsUp = true;
    }

    void OnMouseExit()
    {
        if(!_isOver) return;

        transform.DOLocalMove(transform.localPosition + new Vector3(0,-1,0), _moveSingleCardTime);
        _spriteRenderer.sortingOrder = _startingSortingOrder;
        
        _isOver = false;
        
        if(!_hand.IsUp) return;
        
        _allCardsParent.DOMove(_handDownPos, _moveAllCardsTime);
        
        _hand.IsUp = false;
    }
}
