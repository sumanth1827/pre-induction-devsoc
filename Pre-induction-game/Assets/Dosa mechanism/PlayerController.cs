using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int dosaCounter = 0;
    public Text DosaCounterText;
    public CatController catController;
    [SerializeField] GameObject dosas;
    float disttocat;
    Vector2 directiontocat;
    public int gpay = 1000;
    bool feedable = true;
    public static PlayerController instance;

    private void Awake()
    {
        disttocat = Vector2.Distance(transform.position, catController.transform.position);
    }
    void Start()
    {
        // Initialize the dosa counter.
        dosaCounter = 0;
        gpay = 1000;
        instance = this;
    }

    void Update()
    {
        disttocat = Vector2.Distance(transform.position, catController.transform.position);
        directiontocat = (transform.position - catController.transform.position).normalized;
        DosaCounterText.text = gpay.ToString();
        


        // Update the UI Text to display the dosa counter value.
        // Convert dosaCounter to a string.
    }
    private void FixedUpdate()
    {
       
        {
            
            if (disttocat < 5f && feedable)
            {

               

                //catController.FeedCat(dosaCounter);

                StartCoroutine(thrower());
                
                //dosaCounter = 0;
                //feedable = false;

            }
        }
    }
    IEnumerator thrower()
    {

        while(dosaCounter >0)
        {
            
            feedable = false;
            GameObject dosa = Instantiate(dosas, transform.position, Quaternion.identity);
            dosa.GetComponent<Rigidbody2D>().velocity = -directiontocat * 30f;
            catController.FeedCat(1);
            dosaCounter = dosaCounter - 1;
            
            yield return new WaitForSeconds(0.5f);
        }
        if(dosaCounter> 0)
        {
            //yield return new WaitForSeconds(0.3f);
           // StartCoroutine(thrower());
        }
        if(dosaCounter <= 0)
        {
            
            feedable = true;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (dosaCounter <= 4)
        {
            if (collision.CompareTag("Dosa"))
            {
                // Increment the dosa counter when the player touches a dosa.
                dosaCounter++;
                gpay -= 55;
                //Debug.Log("Dosa Counter: " + dosaCounter);
                
            }
        }



        

        
    }
}