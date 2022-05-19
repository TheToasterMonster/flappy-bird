using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public GameObject bird;
    public GameObject ground;
    public GameObject tilePrefab;

    public static float groundHeight;

    private float currX;
    private float camWidth;
    private float tileWidth;

    // Start is called before the first frame update
    void Start()
    {
        camWidth = Camera.main.orthographicSize * Camera.main.aspect;
        currX = -10f;

        tileWidth = TileController.tileWidth;
        groundHeight = ground.transform.localScale.y;

        while (currX < Camera.main.transform.position.x + camWidth)
        {
            createTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ground.transform.position = new Vector3(bird.transform.position.x + 6, -5, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (currX < Camera.main.transform.position.x + camWidth + tileWidth)
        {
            createTile();
        }
    }

    void createTile()
    {
        GameObject pipe = Instantiate(tilePrefab, new Vector3(currX, -4.093f, transform.position.z), Quaternion.identity);
        pipe.transform.parent = transform;
        currX += tileWidth;
    }
}
