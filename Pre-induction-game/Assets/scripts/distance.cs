using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class distance : MonoBehaviour
{
    [SerializeField] GameObject player;

    float distance_away;
    [SerializeField] float totaldist = 500f;
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance_away = player.transform.position.x - transform.position.x;
        if (Mathf.Abs(distance_away) > totaldist)
        {
            anim.SetBool("win", true);
            Invoke("End", 0.5f);
        }
    }
    
   

    private void End()
    {  
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

}

