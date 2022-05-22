using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    private Camera cam;
    private float camHalfWidth;
    private float pipeHalfWidth;

    private GameObject top;

    private void Awake()
    {
        cam = Camera.main;
        top = transform.GetChild(0).gameObject;

        transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-2f, 2f), transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        camHalfWidth = cam.orthographicSize * cam.aspect;
        pipeHalfWidth = top.transform.localScale.x / 2;
    }

    private void FixedUpdate()
    {
        if (!MenuController.began || BirdController.gameOver)
        {
            return;
        }

        float pipeRightEdge = top.transform.position.x + pipeHalfWidth;
        float camLeftEdge = cam.transform.position.x - camHalfWidth;
        if (pipeRightEdge + 1 < camLeftEdge)
        {
            Destroy(gameObject);
        }
    }
}
