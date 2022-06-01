using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject bird;

    private void LateUpdate()
    {
        if (!MenuController.began || BirdController.gameOver)
        {
            return;
        }

        transform.position = new Vector3(bird.transform.position.x + 6, 0, -10);
    }
}
