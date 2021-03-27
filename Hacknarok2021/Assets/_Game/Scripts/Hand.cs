using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private bool _isUp = false;

    public bool IsUp
    {
        get => _isUp;
        set => _isUp = value;
    }
}
