using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDuckMovement : MonoBehaviour
    
{
    public float speed;
    private Vector3 movementDirection;
    private float turnTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(("ChangeMovementDirection"));
        int startDirection = Random.Range(1, 2);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.position += movementDirection * speed * Time.deltaTime;

    }
    IEnumerator ChangeMovementDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(turnTime);
            movementDirection = new Vector3(
            Random.Range(-1.0f, 1.0f),
            Random.Range(-1.0f, 1.0f),
            0.0f // Use 0.0f for 2D, or Random.Range(-1.0f, 1.0f) for 3D
            ).normalized;
        }
    }
}
