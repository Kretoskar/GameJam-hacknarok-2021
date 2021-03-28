using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class Request : MonoBehaviour
{
    public string url;
    TextMeshPro tm;
    void Start()
    {
        url = "https://tarotscraper.herokuapp.com/";
        tm = GetComponent<TextMeshPro>();
        StartCoroutine(WebRequest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WebRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if(request.isNetworkError || request.isHttpError)
        {
            Debug.Log("Spierdoliło się");
        }

        else
        {
            tm.text = request.downloadHandler.text;
        }
    }
}
