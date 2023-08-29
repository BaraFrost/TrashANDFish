using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items;
    [SerializeField]
    private List<Transform> spawnPoints;

    void Start()
    {
        spawnPoints= new List<Transform>(spawnPoints);
        SpawnBalls();
    }

    void SpawnBalls()
    {
        for ( int i = 0; i < items.Length; i++ ) 
        {
           var spawn = Random.Range(0, spawnPoints.Count);
           Instantiate(items[i], spawnPoints[spawn].transform.position, Quaternion.identity);
           spawnPoints.RemoveAt(spawn);
           
            
        }
    }

    
    
}
