using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class distance : MonoBehaviour
{
    [SerializeField] GameObject player;

    float distance_away;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance_away = player.transform.position.x - transform.position.x;
        End();
    }
    
   

    private void End()
    {  
        if (SceneManager.GetActiveScene().name == "D_spine_evening") 
        {
            if (distance_away < -200)
            {
                Debug.Log("WIN");
            }
        }

        else 
        {
            if (distance_away > 200)
            {
                Debug.Log("WIN");
            }
        }
        
    }
}
