using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    [SerializeField]
    private GameObject player;
    private void Start()
    {
        score = 0;
    }
    void Update()
    {

        scoreText.text = "SCORE = " + score;
        if (score < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Destroy(player);
        }
    }
}

