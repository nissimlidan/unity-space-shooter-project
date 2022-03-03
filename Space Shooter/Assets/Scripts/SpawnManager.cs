using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _ememyPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            UnityEngine.Vector3 posToSpawn = new UnityEngine.Vector3(UnityEngine.Random.Range(-8f, 8f), 7, 0); 
            Instantiate(_ememyPrefab, posToSpawn,UnityEngine.Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
