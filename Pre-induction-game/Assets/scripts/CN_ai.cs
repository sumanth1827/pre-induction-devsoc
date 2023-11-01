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
    bool broken = false,broker2 = false;
    Animator breaker;
    private void OnTriggerStay2D(Collider2D collision)
    {
        

    if(!broken)
        {
            if (collision.CompareTag("platform"))
            {
                
                breaker = collision.gameObject.GetComponent<Animator>();
                
                broker2 = true;

            }
            if (collision.CompareTag("Player") && broker2)
            {

                // Debug.Log("Happpen2");
                Debug.Log(breaker.gameObject.name);
                if(breaker != null)
                {
                    breaker.SetTrigger("break");
                    broken = true;
                    broker2 = false;
                }
                

            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player_health.instance.decreasehealth(50f);
        }
    }
}
