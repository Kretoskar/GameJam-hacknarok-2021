using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardInfo : MonoBehaviour
{
    [SerializeField] private bool _canBeUpsideDown = true;
    [SerializeField] private CardType _cardType = CardType.Death;
    [SerializeField] private string _description = "";
    [SerializeField] private string _upsideDownDescription = "";
    [SerializeField] private TextMeshPro _descriptionText;
    [SerializeField] private GameObject _gfx = null;

    private bool _upsideDown;
    private SpriteRenderer _renderer;
    
    public CardType CardType => _cardType;
    public string Description => _description;

    private void Start()
    {
        if (_canBeUpsideDown)
            _upsideDown = UnityEngine.Random.Range(0, 2) > .5f;
        else
            _upsideDown = false;
        
        _descriptionText.text = _upsideDown ? _upsideDownDescription : _description;
        
        if(_upsideDown)
            _gfx.transform.localScale = new Vector3(1,-1,1);
    }
}
