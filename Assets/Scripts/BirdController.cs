using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BirdController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool gameOver;

    public Action onPassPipe;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (gameOver)
        {
            return;
        }

        transform.position += Vector3.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("Wall"))
        {
            body.velocity = Vector3.zero;
            body.bodyType = RigidbodyType2D.Static;
            gameOver = true;
        } else if (collision.transform.gameObject.CompareTag("Detector"))
        {
            onPassPipe();
        }
    }
}
