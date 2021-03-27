using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _maxMove = 9;
    
    private void Update()
    {
        float amount = Input.GetAxis("Horizontal");

        if (amount > 0)
        {
            if(transform.position.x < -_maxMove) return;
        }
        else
        {
            if(transform.position.x > _maxMove ) return;
        }

        transform.position = new Vector3(transform.position.x - (amount * _speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}
