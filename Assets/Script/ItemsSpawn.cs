using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject items;
    private float randomX;
    Vector3 whereToSpawn;
    [SerializeField]
    private float spawnDelay;
    float nextSpawn = 0.0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Time.time > nextSpawn) 
        {
            nextSpawn = Time.time + spawnDelay;
            randomX = Random.Range(-5, 5);
            whereToSpawn = new Vector3(randomX, transform.position.y, -5);
            GameObject Items = Instantiate(items, whereToSpawn, Quaternion.identity);
            Destroy(Items, 15f);


        }
    }
}
