using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private Camera cam;
    private float camHalfWidth;

    public static float tileWidth = 1f;
    private float tileHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camHalfWidth = cam.orthographicSize * cam.aspect;

        tileHalfWidth = tileWidth / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float tileRightEdge = transform.position.x + tileHalfWidth;
        float camLeftEdge = cam.transform.position.x - camHalfWidth;
        if (tileRightEdge + 1 < camLeftEdge)
        {
            Destroy(gameObject);
        }
    }
}
