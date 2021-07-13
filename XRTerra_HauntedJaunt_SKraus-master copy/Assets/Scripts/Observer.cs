using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform Player;

    bool isPlayerInRange;

    public GameEnd gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == Player)
        {
            isPlayerInRange = true; 
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform == Player)
        {
            isPlayerInRange = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            Vector3 direction = Player.position - transform.position;
            direction.y += 1f;

            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) 
            {
                if (hit.collider.transform == Player)
                {
                    //print("Player Caught!");
                    gameEnd.caughtPlayer();
                }
       
            }
        }   
    }
}
