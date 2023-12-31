using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items;
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
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnDelay;
            for (int i = 0; i < items.Length; i++)
            {
                randomX = UnityEngine.Random.Range(-5, 5);
                whereToSpawn = new Vector3(randomX, transform.position.y, -5);
                GameObject Items = Instantiate(items[i], whereToSpawn, items[i].transform.rotation);
                Destroy(Items, 15f);
            }
        }
    }
}
