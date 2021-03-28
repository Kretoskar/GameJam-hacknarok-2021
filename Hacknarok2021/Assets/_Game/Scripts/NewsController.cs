using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class NewsController : MonoBehaviour
{
    [SerializeField] private string _mock;
    [SerializeField] private News _news;
    public Texture img;
    public Sprite sprite;
    public List<Sprite> spriteList;

    private Root _root;
    
    private void Start()
    {
        StartCoroutine(ReadNewsCoroutine());
    }
    
    private IEnumerator ReadNewsCoroutine()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://tarotscraper.herokuapp.com/");

        yield return request.SendWebRequest();

        string response;
        
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            response = _mock;
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            response = request.downloadHandler.text;
        }
        
        _root = JsonConvert.DeserializeObject<Root>(response);
        SetValues();
        
        Debug.Log(_root.image_urls.Count);
        
        foreach(var url in _root.image_urls)
        {
            StartCoroutine(DownloadImage(url));
        }
        
       
    }

    private void SetValues()
    {
        _news.NewsInfos.First(n => n.Worldometer == Worldometer.Accidents).Count = long.Parse(_root.worldometers.health.accidents.Replace("," , ""));
        _news.NewsInfos.First(n => n.Worldometer == Worldometer.Abortions).Count = long.Parse(_root.worldometers.health.abortions.Replace("," , ""));
        _news.NewsInfos.First(n => n.Worldometer == Worldometer.Education).Count = long.Parse(_root.worldometers.government_and_economics.education.Replace("," , ""));
        _news.NewsInfos.First(n => n.Worldometer == Worldometer.Healthcare).Count = long.Parse(_root.worldometers.government_and_economics.healthcare.Replace("," , ""));
        _news.NewsInfos.First(n => n.Worldometer == Worldometer.Military).Count = long.Parse(_root.worldometers.government_and_economics.military.Replace("," , ""));
        _news.NewsInfos.First(n => n.Worldometer == Worldometer.Suicides).Count = long.Parse(_root.worldometers.health.suicides.Replace("," , ""));
        _news.NewsInfos.First(n => n.Worldometer == Worldometer.CancerDeaths).Count = long.Parse(_root.worldometers.health.cancer_deaths.Replace("," , ""));
        _news.NewsInfos.First(n => n.Worldometer == Worldometer.OilBarrls).Count = long.Parse(_root.worldometers.energy.oil_barrels.Replace("," , ""));
        _news.NewsInfos.First(n => n.Worldometer == Worldometer.DiedOfHunger).Count = long.Parse(_root.worldometers.food.died_of_hunger.Replace("," , ""));
        _news.NewsInfos.First(n => n.Worldometer == Worldometer.MoneySpentOnObesity).Count = long.Parse(_root.worldometers.food.money_spent_on_obesity.Replace("," , ""));
        _news.NewsInfos.First(n => n.Worldometer == Worldometer.MoneySpentOnWeightLoss).Count = long.Parse(_root.worldometers.food.money_spent_on_weight_loss.Replace("," , ""));
        
        foreach (var s in _root.news_api)
        {
            _news.PlainNews.Add(s);   
        }
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            img = ((DownloadHandlerTexture)request.downloadHandler).texture;
            sprite = Sprite.Create((Texture2D)img, new Rect(0, 0, img.width, img.height), Vector2.zero);
            _news.NewsSprites.Add(sprite);
            spriteList.Add(sprite);
        }
    }
}
