using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class eventPause : MonoBehaviour
{
    public bool paused;

    public void goGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && paused == false)
        {
            SceneManager.LoadScene("PauseScene");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            goGameScene();
        }
    }
}
