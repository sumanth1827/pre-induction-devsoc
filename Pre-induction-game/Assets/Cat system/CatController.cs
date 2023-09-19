using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
   // Reference to the cat's Animator component.
    public float restingTime = 10f; // Time in seconds for the cat to rest.
    public float movementSpeed = 2f; // Cat's movement speed when attacking.
    public Transform playerTransform; // Reference to the player's transform.

    private float timer; // Timer to track resting time.
    private int dosasFed = 0; // Counter for dosas fed to the cat.
    private bool isAttacking = false; // Flag to indicate if the cat is attacking.
    public Text timerText;
    [SerializeField] Animator canvaspart;
   

Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        // Initialize the timer.
        timer = restingTime;
    }

    void Update()
    {
        timerText.text = "Timer: " + Mathf.Ceil(timer).ToString();
        if (!isAttacking)
        {
            // Decrement the timer while in the resting state.
            timer -= Time.deltaTime;

            // If the timer reaches 0, switch to the attacking state.
            if (timer <= 0f)
            {
                SwitchToAttackingState();
            }
        }
        else
        {
            if(Mathf.Abs(playerTransform.position.x-transform.position.x)<2f)
            {
                anim.SetBool("is_walking",false);
                anim.SetBool("is_attacking",true);
            }

            else{
            anim.SetBool("is_attacking",false);
            anim.SetBool("is_walking",true);

            // Calculate the direction from the cat to the player.
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

            // Calculate the target position (where the cat should move).
            Vector3 targetPosition = transform.position + directionToPlayer * movementSpeed ;

            // Move the cat smoothly towards the player.
            transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed);
            }

            if(playerTransform.position.x>transform.position.x)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

         }
    }

    // Method to switch to the attacking state.
    void SwitchToAttackingState()
    {
        isAttacking = true;
       // Trigger the "Attacking" animation.
    }

    // Method to handle player interaction (feeding the cat).
    public void FeedCat()
    {
        Debug.Log("feeding");
     
        // Increment the dosas fed to the cat.
        dosasFed =10;

        // Reset the timer to restingTime seconds.
        timer = restingTime;

        // Check if the player has fed the cat at least 4 dosas.
        if (dosasFed >= 10)
        {
            canvaspart.SetBool("win", true);
            // Implement logic for a win condition.
            Invoke("nextlevel", 0.7f);
            
        }
    }
    void nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
