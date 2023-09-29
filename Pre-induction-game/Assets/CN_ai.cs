using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CN_ai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool broken = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if(collision.CompareTag("platform"))
        {
            Debug.Log("Happpen");
            var breaker = collision.gameObject.GetComponent<Animator>();
            if (collision.CompareTag("Player") && !broken)
            {
                Debug.Log("Happpen");
                breaker.SetTrigger("break");
                broken = true;
               
            }
        }
    }
}
