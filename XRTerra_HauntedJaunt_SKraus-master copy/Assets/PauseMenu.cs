using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isGamePause = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
  /*  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
  */
    public void Resume()
    {
        print("resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 01;
        isGamePause = false;

    }

    public void Pause()
    {
        print("Pausing");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePause = true;
       
    }
}
