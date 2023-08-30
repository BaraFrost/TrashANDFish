using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    [SerializeField]
    private GameObject player;
    private void Start()
    {
        score = 5;
    }
    void Update()
    {
       
       scoreText.text = "CSORE = " + score;
       if(score == 0)
        {
            Destroy(player);
        }
    }
}
