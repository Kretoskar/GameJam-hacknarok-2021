using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvNoise : MonoBehaviour
{
    [SerializeField] private float _startingFactor = 0;
    [SerializeField] private float _factorChangePerSecond = 1;

    private float _currentFactor;
    private Renderer _renderer;

    private void Awake()
    {
        _currentFactor = _startingFactor;
        _renderer = GetComponent<Renderer>();
    }
    
    private void Update()
    {
        _currentFactor += _factorChangePerSecond * Time.deltaTime;
        _renderer.sharedMaterial.SetFloat("_Factor1", _currentFactor);
    }
}
