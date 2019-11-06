using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject[] spawnedItem;
    public float respawnTime = 2.0f;
    public Transform[] spawnPoint;
    public int counter = 0;
    public bool[] spawned = new bool[] { false, false, false, false, false };


    // Update is called once per frame
    private void Start()
    {
        
        while (counter <4)
        {
            spawnEnemy();
            counter++;
        }
    }
    void Update()
    {
        
    }
    private void spawnEnemy()
    {
        int c = UnityEngine.Random.Range(0, spawnPoint.Length);
        while (spawned[c]==true)
        {
            c = UnityEngine.Random.Range(0, spawnPoint.Length);
        }
        try
        {
            Instantiate(spawnedItem[counter], spawnPoint[c]);
            spawned[c] = true;          
        }
        catch (IndexOutOfRangeException ex)
        {
            Debug.Log(ex.Message);
            Debug.Log("SpawndItem [" + counter+"]" + " is out of range");
        }
    }
}
