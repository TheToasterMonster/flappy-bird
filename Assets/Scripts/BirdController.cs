using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D body;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * speed;
    }
}
