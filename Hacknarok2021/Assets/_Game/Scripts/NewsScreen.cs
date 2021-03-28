using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsScreen : MonoBehaviour
{
    [SerializeField] private float _changeTime = 2;
    [SerializeField] private float _xScale = 10;
    [SerializeField] private float _yScale = 6;
    
    private News _news;

    private SpriteRenderer _sr = null;
    private List<Sprite> _sprites = null;
    
    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _news = FindObjectOfType<News>();
        _sprites = _news.PickedSprites;

        StartCoroutine(CycleSprites());
    }

    private IEnumerator CycleSprites()
    {
        while (true)
        {
            for (int i = 0; i < _sprites.Count; i++)
            {
                _sr.sprite = _sprites[i];

                Debug.Log(_sprites[i].bounds.size.x);

                var bounds = _sprites[i].bounds;
                var factorY = _yScale / bounds.size.y;
                var factorX = _xScale / bounds.size.x;
                transform.localScale = new Vector3(factorX, factorY, 1);
                
                yield return new WaitForSeconds(_changeTime);
            }

            yield return null;
        }
    }
}
