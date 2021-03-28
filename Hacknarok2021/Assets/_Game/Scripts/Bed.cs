using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    [SerializeField] private News _news = null;
    [SerializeField] private DoppedCards _droppedCards = null;
    [SerializeField] private GameData _gameData = null;

    public void Clicked()
    {
        if(_droppedCards.DroppedCards.Count < 4) return;

        _gameData.WasSleeping = true;
        
        int politics = 0;
        int enviro = 0;
        int healthcare = 0;

        foreach (var droppedCard in _droppedCards.DroppedCards)
        {
            politics += droppedCard.Politics;
            enviro += droppedCard.Enviro;
            healthcare += droppedCard.Healthcare;
        }
        
        _news.ChangeValues(politics, enviro, healthcare);

        StartCoroutine(LoadNextSceneCoroutine());
    }

    private IEnumerator LoadNextSceneCoroutine()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
