using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float horizontalScreenSize;
    public float verticalScreenSize;

    public GameObject enemyPrefab;

    public TextMeshProUGUI scoreText;
    public int score;
    public TextMeshProUGUI duckText;
    public int ducksLost;
    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 5f;
        verticalScreenSize = 5f;
        score = 0;
        ducksLost = 0;

        InvokeRepeating("CreateDuck", 0, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateDuck()
    {
        Instantiate(enemyPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), -verticalScreenSize + 1, 0), Quaternion.Euler(0, 0, 0));
    }

    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        ChangeScoreText(score);


    }
    public void ChangeScoreText(int score)
    {
        scoreText.text = "Ducks shot: " + score;
    }

    public void FlyAway(int duckFly)
    {
        ducksLost = ducksLost + duckFly;
        ChangeDuckText(ducksLost);


    }
    public void ChangeDuckText(int score)
    {
        duckText.text = "Ducks missed: " + score;
    }
}
