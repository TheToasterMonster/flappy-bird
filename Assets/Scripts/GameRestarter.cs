using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour
{
    private void Awake()
    {
        MenuController.onEndGame += Reload;
    }

    private void OnDisable()
    {
        MenuController.onEndGame -= Reload;
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
