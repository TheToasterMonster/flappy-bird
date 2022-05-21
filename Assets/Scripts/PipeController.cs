using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    private Camera cam;
    private float camHalfWidth;
    private float pipeHalfWidth;

    private GameObject top;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camHalfWidth = cam.orthographicSize * cam.aspect;

        top = transform.GetChild(0).gameObject;
        pipeHalfWidth = top.transform.localScale.x / 2;

        transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-2f, 2f), transform.position.z);
    }

    private void FixedUpdate()
    {
        float pipeRightEdge = top.transform.position.x + pipeHalfWidth;
        float camLeftEdge = cam.transform.position.x - camHalfWidth;
        if (pipeRightEdge + 1 < camLeftEdge)
        {
            Destroy(gameObject);
        }
    }
}
