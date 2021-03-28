using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Card : MonoBehaviour
{
    [SerializeField] private float _moveAllCardsBy = .5f;
    [SerializeField] private float _moveAllCardsTime = .3f;
    [SerializeField] private float _moveSingleCardTime = .01f;
    [SerializeField] private int _sortingOrderOnHover = 100;
    [SerializeField] private float _minYPosToDrop = 5;
    [SerializeField] private GameObject _gfx;
    [SerializeField] private float _dropTime = 1;
    [SerializeField] private GameObject _description;

    private DoppedCards _droppedCard;
    private Camera _mainCam;
    private SpriteRenderer _spriteRenderer;
    
    private Vector3 _positionBeforeDrag;
    private Vector3 _screenPoint;
    private Vector3 _offset;
    private Vector3 _handUpPos;
    private Vector3 _handDownPos;
    
    private Transform _allCardsParent = null;
    private Hand _hand = null;

    private int _startingSortingOrder;
    private bool _isOver = false;

    public bool WasDropped = false;
    
    private void Start()
    {
        _mainCam = Camera.main;

        _droppedCard = FindObjectOfType<DoppedCards>();
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

        _description.SetActive(true);
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

        _description.SetActive(false);
        transform.DOLocalMove(transform.localPosition + new Vector3(0,-1,0), _moveSingleCardTime);
        _spriteRenderer.sortingOrder = _startingSortingOrder;
        
        _isOver = false;
        
        if(!_hand.IsUp) return;
        
        _allCardsParent.DOMove(_handDownPos, _moveAllCardsTime);
        
        _hand.IsUp = false;
    }
    
    void OnMouseDown()
    {
        _positionBeforeDrag = transform.position;
        _offset = gameObject.transform.position - _mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
        transform.position = curPosition;
    }
    
    void OnMouseUp()
    {
        if (transform.localPosition.y < _minYPosToDrop)
        {
            transform.position = _positionBeforeDrag;
        }
        else
        {
            Drop();
        }
    }

    private void Drop()
    {
        WasDropped = true;
        Transform tween = _droppedCard.DropCard(GetComponent<CardInfo>());
        transform.parent = tween.parent;
        transform.DOMove(tween.transform.position, _dropTime);
        transform.DOScale(tween.transform.localScale, _dropTime);
        transform.DORotate(tween.transform.eulerAngles, _dropTime);
    }
}
