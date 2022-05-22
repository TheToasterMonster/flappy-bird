using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public GameObject groundParent;
    public GameObject tileParent;
    public GameObject backdropParent;

    public GameObject bird;
    public GameObject ground;
    public GameObject tilePrefab;
    public GameObject backdropPrefab;

    public static float groundHeight = 2f;

    private float currXTile;
    private float currXBackdrop;
    private float camWidth;
    private float tileWidth;
    private float backdropWidth;

    private void Awake()
    {
        camWidth = Camera.main.orthographicSize * Camera.main.aspect;
        currXTile = -10f;
        currXBackdrop = -10f;

        tileWidth = TileController.tileWidth;
        backdropWidth = BackdropController.backdropWidth;
        groundHeight = ground.transform.localScale.y;

        while (currXTile < Camera.main.transform.position.x + camWidth)
        {
            createTile();
        }

        while (currXBackdrop < Camera.main.transform.position.x + camWidth)
        {
            createBackdrop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuController.began || BirdController.gameOver)
        {
            return;
        }

        ground.transform.position = new Vector3(bird.transform.position.x + 6, -5, groundParent.transform.position.z);
    }

    private void FixedUpdate()
    {
        if (!MenuController.began || BirdController.gameOver)
        {
            return;
        }

        if (currXTile < Camera.main.transform.position.x + camWidth + tileWidth)
        {
            createTile();
        }
        if (currXBackdrop < Camera.main.transform.position.x + camWidth + backdropWidth)
        {
            createBackdrop();
        }
    }

    void createTile()
    {
        GameObject pipe = Instantiate(tilePrefab, new Vector3(currXTile, -4.093f, tileParent.transform.position.z), Quaternion.identity);
        pipe.transform.parent = tileParent.transform;
        currXTile += tileWidth;
    }

    void createBackdrop()
    {
        GameObject backdrop = Instantiate(backdropPrefab, new Vector3(currXBackdrop, -2, backdropParent.transform.position.z), Quaternion.identity);
        backdrop.transform.parent = backdropParent.transform;
        currXBackdrop += backdropWidth;
    }
}
