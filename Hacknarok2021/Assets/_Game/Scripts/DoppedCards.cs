using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoppedCards : MonoBehaviour
{
    [SerializeField] private List<Transform> _tweens;

    private int _currIndex = -1;

    private void Start()
    {
        _currIndex = -1;
    }
    
    public Transform DropCard()
    {
        _currIndex++;
        return _tweens[_currIndex];
    }
}
