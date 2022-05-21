using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdropController : MonoBehaviour
{
    private Camera cam;
    private float camHalfWidth;

    public static float backdropWidth = 2f;
    private float backdropHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camHalfWidth = cam.orthographicSize * cam.aspect;

        backdropHalfWidth = backdropWidth / 2;
    }

    private void FixedUpdate()
    {
        float backdropRightEdge = transform.position.x + backdropHalfWidth;
        float camLeftEdge = cam.transform.position.x - camHalfWidth;
        if (backdropRightEdge + 1 < camLeftEdge)
        {
            Destroy(gameObject);
        }
    }
}
