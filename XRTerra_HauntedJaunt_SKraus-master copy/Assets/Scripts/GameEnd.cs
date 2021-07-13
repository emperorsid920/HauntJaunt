using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{

    public GameObject Player;

    public CanvasGroup exitCanvasGroup;
    public CanvasGroup caughtCanvasGroup;

    bool isPlayerExit;
    bool isPlayerCaught;

    public float fadeDuration;
    public float imageDuration;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void caughtPlayer()
    {
        isPlayerCaught = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            isPlayerExit = true;
            Debug.Log("Made to the exit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerExit)
        {
            endLevel(exitCanvasGroup, false);
        }
        else if (isPlayerCaught)
        {
            endLevel(caughtCanvasGroup, true);
        }
    }

    void endLevel(CanvasGroup canvasGroup, bool restart)
    {
        Player.SetActive(false);
        timer += Time.deltaTime;
        canvasGroup.alpha = timer / fadeDuration;
        //canvasGroup.alpha
        if (timer > fadeDuration + imageDuration) 
        {
            if (restart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
            //SceneManager.LoadScene(0);
        }
    }
}
