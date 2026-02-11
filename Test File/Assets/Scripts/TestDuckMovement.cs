using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TestDuckMovement : MonoBehaviour

{
    public float speed;
    private Vector3 movementDirection;
    private float turnTime = 0.5f;

    private GameManager gameManager;
    public bool isFlyingAway = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
        StartCoroutine(("ChangeMovementDirection"));
        InvokeRepeating("FlyAway", 5f, 0.00025f);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.position += movementDirection * speed * Time.deltaTime;


        if (gameManager.bullets == 0)
        {
            FlyAway();
            Debug.Log("no more bullets");
        }

        if (transform.position.x >= gameManager.horizontalScreenSize || transform.position.x <= -gameManager.horizontalScreenSize)
        {
            movementDirection.x = -movementDirection.x;
            //Debug.Log("boioioioing");
        }

        if ((transform.position.y >= gameManager.verticalScreenSize || transform.position.y <= -gameManager.verticalScreenSize + 2) && gameManager.roundLoss == false)
        {
            movementDirection.y = -movementDirection.y;
            //Debug.Log("boioioioing");
        }
        else if (isFlyingAway == true)
        {
            return;
        }

        if (gameManager.roundLoss == true)
        {
            FlyAway();
            Debug.Log("round loss");
        }
        else if (gameManager.roundLoss == false)
        {
            return;
        }

    }
    IEnumerator ChangeMovementDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(turnTime);
            movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f).normalized;
            if (movementDirection.x >= 0f)
            {
                transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
            }
            else if (movementDirection.x < 0f)
            {
                transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }
    }
    
    void FlyAway()
    {
        StopAllCoroutines();
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Debug.Log("fly away triggered");
    }

}