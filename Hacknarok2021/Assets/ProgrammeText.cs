using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgrammeText : MonoBehaviour
{
    private void Start()
    {
        TextMeshPro tmp = GetComponent<TextMeshPro>();
        tmp.text = FindObjectOfType<News>().Newses();
    }
}
