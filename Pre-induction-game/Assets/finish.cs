using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void next()
    {
        score.cg -= score.retryPenalty; //reducing cg everytime the player dies 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}