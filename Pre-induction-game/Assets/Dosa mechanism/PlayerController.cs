using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int dosaCounter = 0;
    public Text DosaCounterText;
    public CatController catController;

    void Start()
    {
        // Initialize the dosa counter.
        dosaCounter = 0;
    }

    void Update()
    {

       
        // Update the UI Text to display the dosa counter value.
        // Convert dosaCounter to a string.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dosaCounter <= 4)
        {
            if (collision.gameObject.CompareTag("Dosa"))
            {
                // Increment the dosa counter when the player touches a dosa.
                dosaCounter++;
                Debug.Log("Dosa Counter: " + dosaCounter);
                DosaCounterText.text = "Dosa Count: " + dosaCounter.ToString();
            }
        }


            if (dosaCounter >4 )
            {
                if (collision.gameObject.CompareTag("Cat"))
                {
               


                 catController.FeedCat();
                 dosaCounter = 0;


            }
        }

        
    }
}