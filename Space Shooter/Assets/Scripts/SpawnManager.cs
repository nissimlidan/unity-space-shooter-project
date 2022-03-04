using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _ememyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;
    

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
        while(_stopSpawning == false)
        {
            UnityEngine.Vector3 posToSpawn = new UnityEngine.Vector3(UnityEngine.Random.Range(-8f, 8f), 7, 0); 
            GameObject newEnemy =  Instantiate(_ememyPrefab, posToSpawn,UnityEngine.Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }
}
