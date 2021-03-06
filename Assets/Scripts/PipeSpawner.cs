using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float distBetween;
    private float currX;
    private float camWidth;
    private float adjustedCenterHeight;

    private void Awake()
    {
        camWidth = Camera.main.orthographicSize * Camera.main.aspect;
        currX = 6f;
        adjustedCenterHeight = TerrainController.groundHeight / 4;

        while (currX < Camera.main.transform.position.x + camWidth + distBetween)
        {
            createPipe();
        }
    }

    private void FixedUpdate()
    {
        if (!MenuController.began || BirdController.gameOver)
        {
            return;
        }

        if (currX < Camera.main.transform.position.x + camWidth + distBetween)
        {
            createPipe();
        }
    }

    private void createPipe()
    {
        GameObject pipe = Instantiate(pipePrefab, new Vector3(currX, adjustedCenterHeight, 0f), Quaternion.identity);
        pipe.transform.parent = transform;
        currX += distBetween;
    }
}
