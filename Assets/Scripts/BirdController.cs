using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BirdController : MonoBehaviour
{
    public Vector2 speedMinMax;
    public float pipesBeforeMaxSpeed;

    public float jumpForce;
    public float idleJumpSpeed;
    public float jumpAmplitude;

    public static bool gameOver;

    public static event Action onPassPipe;
    private Rigidbody2D body;

    private float adjustedCenterHeight;
    private float fiveSixthsPi = (float)(Mathf.PI * 5.0 / 6.0);

    private void Awake()
    {
        gameOver = false;

        adjustedCenterHeight = TerrainController.groundHeight / 4;
        transform.position = new Vector3(transform.position.x, adjustedCenterHeight, transform.position.z);

        body = GetComponent<Rigidbody2D>();
        body.bodyType = RigidbodyType2D.Kinematic;

        MenuController.onBeginGame += activateGravity;
    }

    private void OnDisable()
    {
        MenuController.onBeginGame -= activateGravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuController.began || gameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            applyImpulse();
        }
    }

    private void FixedUpdate()
    {
        if (!MenuController.began && !gameOver)
        {
            float height = jumpAmplitude * (2 * Mathf.Abs(Mathf.Sin(Time.fixedTime * idleJumpSpeed + fiveSixthsPi)) - 1);
            transform.position = new Vector3(transform.position.x, adjustedCenterHeight + height, transform.position.z);
        }

        if (!MenuController.began || gameOver)
        {
            return;
        }

        transform.position += Vector3.right * Mathf.Lerp(speedMinMax.x, speedMinMax.y, ScoreKeeper.score / pipesBeforeMaxSpeed) * Time.fixedDeltaTime;
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

    void activateGravity()
    {
        body.bodyType = RigidbodyType2D.Dynamic;
        applyImpulse();
    }

    void applyImpulse()
    {
        body.velocity = new Vector2(body.velocity.x, 0);
        body.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }
}
