using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int dosaCounter = 0;
    public Text DosaCounterText;
    public CatController catController;
    [SerializeField] GameObject dosas;
    float disttocat;
    Vector2 directiontocat;
    int dosastothrow = 0;

    void Start()
    {
        // Initialize the dosa counter.
        dosaCounter = 0;
    }

    void Update()
    {
        disttocat = Vector2.Distance(transform.position, catController.transform.position);
        directiontocat = (transform.position - catController.transform.position).normalized;


        
        
        // Update the UI Text to display the dosa counter value.
        // Convert dosaCounter to a string.
    }
    private void FixedUpdate()
    {
        if (dosaCounter > 4)
        {
            
            if (disttocat < 10f && dosastothrow > 0)
            {



                catController.FeedCat();

                StartCoroutine(thrower());
                
                dosaCounter = 0;


            }
        }
    }
    IEnumerator thrower()
    {
        yield return null;
        GameObject dosa = Instantiate(dosas, transform.position, Quaternion.identity);
        dosa.GetComponent<Rigidbody2D>().velocity = -directiontocat * 30f;
        dosastothrow--;
        if(dosastothrow > 0)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(thrower());
        }
    }
    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         if (dosaCounter > 4)
         {
             if (collision.gameObject.CompareTag("Cat"))
             {



                 catController.FeedCat();
                 for(int i = 0; i < dosaCounter; i++)
                 {
                    GameObject dosa = Instantiate(dosas,transform.position, Quaternion.identity);
                     dosa.GetComponent<Rigidbody2D>().velocity = directiontocat * 50f;

                 }    
                 dosaCounter = 0;


             }
         }
     }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dosaCounter <= 4)
        {
            if (collision.CompareTag("Dosa"))
            {
                // Increment the dosa counter when the player touches a dosa.
                dosaCounter++;
                dosastothrow++;
                Debug.Log("Dosa Counter: " + dosaCounter);
                DosaCounterText.text = "Dosa Count: " + dosaCounter.ToString();
            }
        }



        

        
    }
}