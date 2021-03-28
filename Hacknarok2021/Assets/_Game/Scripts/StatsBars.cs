using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBars : MonoBehaviour
{
    [SerializeField] private GameData _gameData = null;
    [SerializeField] private Image _politicsImg;
    [SerializeField] private Image _enviroImg;
    [SerializeField] private Image _healthcareImg;
    
    private void Start()
    {
        _politicsImg.fillAmount = (float)(_gameData.PoliticsChange + 1000) / 2000;
        _enviroImg.fillAmount = (float)(_gameData.EnviroChange + 1000) / 2000;
        _healthcareImg.fillAmount = (float)(_gameData.HealthCareChange + 1000) / 2000;
    }
}
