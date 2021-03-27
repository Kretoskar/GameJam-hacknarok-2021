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
    [SerializeField] private GameObject _gfx;

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

    private void Start()
    {
        _mainCam = Camera.main;

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

    void OnMouseDown()
    {
        _positionBeforeDrag = transform.position;
        _offset = gameObject.transform.position - _mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
    }

    void OnMouseUp()
    {
        transform.position = _positionBeforeDrag;
    }
 
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
        transform.position = curPosition;
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
