using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float distBetween;
    private float currX;
    private float camWidth;

    // Start is called before the first frame update
    void Start()
    {
        camWidth = Camera.main.orthographicSize * Camera.main.aspect;
        currX = 6f;
        
        while (currX < Camera.main.transform.position.x + camWidth)
        {
            GameObject pipe = Instantiate(pipePrefab, new Vector3(currX, 0, 0), Quaternion.identity);
            pipe.transform.parent = gameObject.transform;
            currX += distBetween;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (currX < Camera.main.transform.position.x + camWidth + distBetween)
        {
            GameObject pipe = Instantiate(pipePrefab, new Vector3(currX, 0, 0), Quaternion.identity);
            pipe.transform.parent = gameObject.transform;
            currX += distBetween;
        }
    }
}
