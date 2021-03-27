using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammeClick : MonoBehaviour
{
    [SerializeField] private string _eventName = "";
    
    private ProgrammeSpawner _spawner;

    private void Awake()
    {
        _spawner = FindObjectOfType<ProgrammeSpawner>();
    }

    public void Clicked()
    {
        _spawner.GetComponent<PlayMakerFSM>().SendEvent(_eventName);
    }
}
