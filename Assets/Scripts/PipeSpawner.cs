using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnPipe());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    IEnumerator spawnPipe()
    {
        while (transform.childCount <= 10)
        {
            GameObject pipe = Instantiate(pipePrefab, new Vector3(12 + Camera.main.transform.position.x, 0, 0), Quaternion.identity);
            pipe.transform.parent = gameObject.transform;
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
