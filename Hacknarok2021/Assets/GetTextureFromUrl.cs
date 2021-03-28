using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetTextureFromUrl : MonoBehaviour
{
    public Texture img;
    private Sprite sprite;
    private SpriteRenderer sr;
    public string url = "https://tarotscraper.herokuapp.com/static/17.png";
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(DownloadImage(url));
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
            sprite = Sprite.Create((Texture2D)img, new Rect(0, 0, 1000, img.height), Vector2.zero);
        }
            
    }
}