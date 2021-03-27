using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class NewsController : MonoBehaviour
{
    [SerializeField] private string _mock;
    
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
        
        Debug.Log(_root.worldometers.food.died_of_hunger);
    }
}
