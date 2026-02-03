using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDuckKill : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5)
        {
            gameManager.FlyAway(1);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        gameManager.AddScore(1);
        Destroy(gameObject);
    }
}

