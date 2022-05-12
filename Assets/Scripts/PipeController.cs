using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    private Camera cam;
    private float camWidth;

    private GameObject top;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camWidth = cam.orthographicSize * cam.aspect;

        top = transform.GetChild(0).gameObject;

        transform.position = new Vector3(transform.position.x, Random.Range(-3f, 3f), 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float pipeRightEdge = top.transform.position.x + top.transform.localScale.x;
        float camLeftEdge = cam.transform.position.x - camWidth;
        if (pipeRightEdge + 1 < camLeftEdge)
        {
            Destroy(gameObject);
        }
    }
}
