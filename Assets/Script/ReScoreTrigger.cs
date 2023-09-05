using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReScoreTrigger : MonoBehaviour
{
    [SerializeField]
    private int deduction = 5;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Score.score = Score.score - deduction;
            Destroy(gameObject);
        }
    }
}
