using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;

    public GameObject Duck1Hit;
    public GameObject Duck2Hit;
    public GameObject Duck3Hit;
    public GameObject Duck4Hit;
    public GameObject Duck5Hit;
    public GameObject Duck6Hit;
    public GameObject Duck7Hit;
    public GameObject Duck8Hit;
    public GameObject Duck9Hit;
    public GameObject Duck10Hit;

    public GameObject Duck1Miss;
    public GameObject Duck2Miss;
    public GameObject Duck3Miss;
    public GameObject Duck4Miss;
    public GameObject Duck5Miss;
    public GameObject Duck6Miss;
    public GameObject Duck7Miss;
    public GameObject Duck8Miss;
    public GameObject Duck9Miss;
    public GameObject Duck10Miss;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.bullets >= 3)
        {
            BulletReload();
        }
        else if (gameManager.bullets == 2)
        {
            Bullet1.SetActive(false);
        }
        else if (gameManager.bullets == 1)
        {
            Bullet2.SetActive(false);
        }
        else if (gameManager.bullets <= 0)
        {
            Bullet3.SetActive(false);
        }
    }

    public void BulletReload()
    {
        Bullet1.SetActive(true);
        Bullet2.SetActive(true);
        Bullet3.SetActive(true);
    }

    public void DuckScore()
    {
        if (gameManager.duckTotal == 1)
        {
            Duck1Hit.SetActive(true);
        }
        else if (gameManager.duckTotal == 2)
        {
            Duck2Hit.SetActive(true);
        }
        else if (gameManager.duckTotal == 3)
        {
            Duck3Hit.SetActive(true);
        }
        else if (gameManager.duckTotal == 4)
        {
            Duck4Hit.SetActive(true);
        }
        else if (gameManager.duckTotal == 5)
        {
            Duck5Hit.SetActive(true);
        }
        else if (gameManager.duckTotal == 6)
        {
            Duck6Hit.SetActive(true);
        }
        else if (gameManager.duckTotal == 7)
        {
            Duck7Hit.SetActive(true);
        }
        else if (gameManager.duckTotal == 8)
        {
            Duck8Hit.SetActive(true);
        }
        else if (gameManager.duckTotal == 9)
        {
            Duck9Hit.SetActive(true);
        }
        else if (gameManager.duckTotal == 10)
        {
            Duck10Hit.SetActive(true);
        }
    }

    public void DuckMiss()
    {
        if (gameManager.duckTotal == 1)
        {
            Duck1Miss.SetActive(true);
        }
        else if (gameManager.duckTotal == 2)
        {
            Duck2Miss.SetActive(true);
        }
        else if (gameManager.duckTotal == 3)
        {
            Duck3Miss.SetActive(true);
        }
        else if (gameManager.duckTotal == 4)
        {
            Duck4Miss.SetActive(true);
        }
        else if (gameManager.duckTotal == 5)
        {
            Duck5Miss.SetActive(true);
        }
        else if (gameManager.duckTotal == 6)
        {
            Duck6Miss.SetActive(true);
        }
        else if (gameManager.duckTotal == 7)
        {
            Duck7Miss.SetActive(true);
        }
        else if (gameManager.duckTotal == 8)
        {
            Duck8Miss.SetActive(true);
        }
        else if (gameManager.duckTotal == 9)
        {
            Duck9Miss.SetActive(true);
        }
        else if (gameManager.duckTotal == 10)
        {
            Duck10Miss.SetActive(true);
        }
    }
}
