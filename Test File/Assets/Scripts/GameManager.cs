using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public int horizontalScreenSize;
    public int verticalScreenSize;

    public GameObject enemyPrefab;

    public TextMeshProUGUI scoreText;
    public int score;
    public TextMeshProUGUI duckText;
    public int ducksLost;
    public GameObject gameOverText;
    public bool gamePaused;
    public TextMeshProUGUI pauseText;

    private UIManager uiManager;

    public bool gameOver;

    public int bullets;
    public int duckTotal;
    public int ducksGoal;
    public int duckCount;

    public bool roundOver;
    public bool roundLoss;

    public bool duckTwo;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Manager").GetComponent<UIManager>();
        gameOver = false;
        roundLoss = false;
        horizontalScreenSize = 5;
        verticalScreenSize = 5;
        score = 0;
        ducksLost = 0;
        ducksGoal = 10;
        duckTotal = 0;
        duckCount = 0;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (ducksLost >= 3)
        {
            Time.timeScale = 0;
            CancelInvoke();
            GameOver();
        }

        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("click");
        }
        if (Input.GetKeyDown(KeyCode.Space) && gamePaused == false && gameOver == false)
        {
            Time.timeScale = 0;
            pauseText.gameObject.SetActive(true);
            gamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && gamePaused == true)
        {
            Time.timeScale = 1;
            pauseText.gameObject.SetActive(false);
            gamePaused = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && gamePaused == true)
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && gamePaused == false && gameOver == false)
        {
            bullets = bullets - 1;
            Debug.Log("shot fired, " + bullets + " shot(s) left");
        }

        if (duckTotal == 10)
        {
            SceneManager.LoadScene("Win Screen");
        }

        if (duckCount <= 0)
        {
            Round();
        }
    }

    public void OnMouseDown()
    {
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
    public void Round()
    {
        roundLoss = false;
        bullets = 4;
        if (bullets != 3)
        {
            bullets = 3;
        }
        BulletReload();
        CreateDuck();
        if (duckTwo == true)
        {
            CreateDuck();
        }
        Debug.Log("spawned! " + duckTotal + " many ducks spawned");

    }

    public void BulletReload()
    {
        Debug.Log("bullets before reload = " + bullets);
        bullets = 3;
        Debug.Log("bullets after reload = " + bullets);

        uiManager.BulletReload();

        Debug.Log("shots reloaded, " + bullets + " shot(s) left");

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
    void GameOver()
    {
        gameOver = true;
        SceneManager.LoadScene("Win Screen 1");

    }

    void CreateDuck()
    {
        Instantiate(enemyPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), -verticalScreenSize + 2, 0), Quaternion.Euler(0, 0, 0));
        duckCount = duckCount + 1;
        duckTotal = duckTotal + 1;
        if (bullets != 3)
        {
            bullets = 3;
        }

    }
}
