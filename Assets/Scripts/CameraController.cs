using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float speed;
    public GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        speed = bird.GetComponent<BirdController>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * speed;
    }
}
