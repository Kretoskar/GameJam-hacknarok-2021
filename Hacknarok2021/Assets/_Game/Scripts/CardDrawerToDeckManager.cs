using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class CardDrawerToDeckManager : MonoBehaviour
{
    [SerializeField] private List<CardDrawerToDeck> _allCardDrawersToDeck = null;
    [SerializeField] private GameData _gameData = null;
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private List<Transform> _cardTweens = null;
    [SerializeField] private float _drawSingleCardTime = .5f;

    private List<CardDrawerToDeck> _cardsToSpawn;
    private int _draws = 0;

    private void Start()
    {
        GetRandomCards();
        SpawnCards();
    }

    private void SpawnCards()
    {
        StartCoroutine(SpawnCoroutine());
    }
    
    private IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject spawnedCard = Instantiate(_cardsToSpawn[i].gameObject, _spawnPoint);

            spawnedCard.transform.DOMove(_cardTweens[i].transform.position, _drawSingleCardTime);
            spawnedCard.transform.DOScale(_cardTweens[i].transform.localScale, _drawSingleCardTime);
            spawnedCard.transform.DORotate(_cardTweens[i].transform.eulerAngles, _drawSingleCardTime);

            yield return new WaitForSeconds(_drawSingleCardTime);
        }
    }

    private void GetRandomCards()
    {
        _cardsToSpawn = new List<CardDrawerToDeck>();

        for (int i = 0; i < 4; i++)
        {
            CardType type = _gameData.CardsLeft[UnityEngine.Random.Range(0, _gameData.CardsLeft.Count)];
            _cardsToSpawn.Add(_allCardDrawersToDeck.First(cd => cd.CardType == type));
        }
    }
    
    public void Drawn()
    {
        _draws++;
        
        if(_draws >= 2)
            Debug.Log("enough");
    }
}
