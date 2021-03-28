﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class News : MonoBehaviour
{
    [SerializeField] private List<NewsInfo> _newsInfos;
    [SerializeField] private List<string> _plainNews = new List<string>();

    private List<NewsInfo> _pickedNewsInfos = new List<NewsInfo>();
    private List<string> _pickedPlainNews = new List<string>();
    
    public List<string> PlainNews => _plainNews;

    public List<NewsInfo> NewsInfos => _newsInfos;

    public void SetupNews()
    {
        GetNewsInfos();
        GetNewPlainNews();
    }

    private void GetNewsInfos()
    {
        _pickedNewsInfos.Clear();
        
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, _newsInfos.Count);
            _pickedNewsInfos.Add(_newsInfos[index]);
            _newsInfos.RemoveAt(index);
        }
    }
    
    public void GetNewPlainNews()
    {
        _pickedPlainNews.Clear();
        
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, _plainNews.Count);
            _pickedPlainNews.Add(_plainNews[index]);
            _plainNews.RemoveAt(index);
        }
    }

    public string Newses()
    {
        if(_pickedNewsInfos.Count == 0)
            SetupNews();
        
        string newses = "";
        
        for (int i = 0; i < 3; i++)
        {
            newses += _pickedNewsInfos[i].Description;
            newses += "        |        ";
            newses += _pickedPlainNews[i];
            newses += "        |        ";
        }

        return newses;
    }
}

[Serializable]
public class NewsInfo
{
    [SerializeField] private Category _category;
    [SerializeField] private Worldometer _worldometer;
    [SerializeField] private string _description;
    [SerializeField] private string _description2;
    [SerializeField] private long _count;

    public Category Category
    {
        get => _category;
        set => _category = value;
    }

    public Worldometer Worldometer
    {
        get => _worldometer;
        set => _worldometer = value;
    }

    public string Description => _description + " " + _count + " " + _description2;
    
    public long Count
    {
        get => _count;
        set => _count = value;
    }
}

public enum Category
{
    PoliticsProtestsFinances,
    EnvironmentClimateChange,
    HealthcarePandemic
}

public enum Worldometer
{
    OilBarrls,
    DiedOfHunger,
    MoneySpentOnObesity,
    MoneySpentOnWeightLoss,
    Education,
    Healthcare,
    Military,
    Suicides,
    CancerDeaths,
    Accidents,
    Abortions
}
