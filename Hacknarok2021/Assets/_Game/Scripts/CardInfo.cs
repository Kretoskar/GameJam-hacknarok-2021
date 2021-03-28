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

    [Header("Up stats")] 
    [SerializeField] private int _upPolitics = 0;
    [SerializeField] private int _upEnviro = 0;
    [SerializeField] private int _upHealthcare = 0;
    
    [Header("Down stats")]
    [SerializeField] private int _downPolitics = 0;
    [SerializeField] private int _downEnviro = 0;
    [SerializeField] private int _downHealthcare = 0;
    
    private bool _upsideDown;
    private SpriteRenderer _renderer;
    
    public CardType CardType => _cardType;
    public string Description => _description;

    public int Politics => _upsideDown ? _downPolitics : _upPolitics;

    public int Enviro => _upsideDown ? _downEnviro : _upEnviro;

    public int Healthcare => _upsideDown ? _downHealthcare : _upHealthcare;

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
