using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestDuckKill : MonoBehaviour
{
    // public GameObject explosion;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 6)
        {
            gameManager.FlyAway(1);
            Destroy(gameObject);
        }

    }

    void OnMouseDown()
    {
        if (gameManager.gamePaused == true)
        {
            return;
        }
        else if (gameManager.gamePaused == false)
        {
            gameManager.AddScore(1);
            Destroy(gameObject);
        }

    }


}

