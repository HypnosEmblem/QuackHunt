using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestDuckKill : MonoBehaviour
{
    // public GameObject explosion;
    private GameManager gameManager;
    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("Manager").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 6)
        {
            gameManager.FlyAway(1);
            gameManager.duckCount = gameManager.duckCount - 1;
            uiManager.DuckMiss();
            Debug.Log("duck missed! " + gameManager.duckTotal + " many ducks spawned");
            Destroy(gameObject);
        }

        if (gameManager.gameOver == true)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        if (gameManager.gamePaused == true || gameManager.roundLoss == true)
        {
            return;
        }
        else if (gameManager.gamePaused == false && gameManager.bullets > 0)
        {
            gameManager.AddScore(1);
            uiManager.BulletReload();
            gameManager.duckCount = gameManager.duckCount - 1;
            uiManager.DuckScore();
            Debug.Log("duck hit! " + gameManager.duckTotal + " total ducks spawned");
            Destroy(gameObject);
        }

    }


}

