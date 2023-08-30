using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Score.score--;
            Destroy(gameObject);
        }
    }
}
