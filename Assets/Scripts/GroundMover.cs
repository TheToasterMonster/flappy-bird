using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    public GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(bird.transform.position.x + 6, -5, 0);
    }
}
