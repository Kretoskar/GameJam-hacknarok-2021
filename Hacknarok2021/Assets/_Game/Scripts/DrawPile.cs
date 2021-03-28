using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DrawPile : MonoBehaviour
{
    [SerializeField] private List<Card> _availableCards = null;
    [SerializeField] private List<Transform> _cardTweens = null;
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private Transform _cardParent = null;
    [SerializeField] private float _drawSingleCardTime = .5f;
    [SerializeField] private GameData _gameData = null;
     
    private int _cardsOnHandCount = 6;
    private List<Card> _cardsOnHand;

    private void Awake()
    {
        _cardsOnHand = new List<Card>();
    }
    
    public void Draw()
    {
        GetRandomCards();
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < _cardsOnHandCount; i++)
        {
            GameObject spawnedCard = Instantiate(_cardsOnHand[i].gameObject, _spawnPoint);
            
            _gameData.AddAvailableCard(spawnedCard.GetComponent<CardInfo>().CardType);
            
            spawnedCard.transform.DOMove(_cardTweens[i].transform.position, _drawSingleCardTime);
            spawnedCard.transform.DOScale(_cardTweens[i].transform.localScale, _drawSingleCardTime);
            spawnedCard.transform.DORotate(_cardTweens[i].transform.eulerAngles, _drawSingleCardTime);
            
            spawnedCard.GetComponent<Card>().SetStartingSortingOrder(i);
            spawnedCard.transform.position = new Vector3(spawnedCard.transform.position.x, spawnedCard.transform.position.y, i);
            
            yield return new WaitForSeconds(_drawSingleCardTime);
        }
    }

    private void GetRandomCards()
    {
        for (int i = 0; i < _cardsOnHandCount; i++)
        {
            int rand = UnityEngine.Random.Range(0, _availableCards.Count);
            _cardsOnHand.Add(_availableCards[rand]);
            _availableCards.RemoveAt(rand);
        }
    }
}
