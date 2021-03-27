using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _programme;
    [SerializeField] private Transform _parent;

    private GameObject _spawnedProgramme;
    
    public void Spawn()
    {
        _spawnedProgramme = Instantiate(_programme, _parent);
    }

    public void Destroy()
    {
        Destroy(_spawnedProgramme);
        _spawnedProgramme = null;
    }
}
