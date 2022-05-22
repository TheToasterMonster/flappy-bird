using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private Camera cam;
    private float camHalfWidth;

    public static float tileWidth = 1f;
    private float tileHalfWidth;

    private void Awake()
    {
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        camHalfWidth = cam.orthographicSize * cam.aspect;
        tileHalfWidth = tileWidth / 2;
    }

    private void FixedUpdate()
    {
        if (!MenuController.began || BirdController.gameOver)
        {
            return;
        }

        float tileRightEdge = transform.position.x + tileHalfWidth;
        float camLeftEdge = cam.transform.position.x - camHalfWidth;
        if (tileRightEdge + 1 < camLeftEdge)
        {
            Destroy(gameObject);
        }
    }
}
