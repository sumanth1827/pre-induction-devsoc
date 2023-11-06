using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Microlight.MicroBar;

public class CatController : MonoBehaviour
{
    [SerializeField] float restingTime = 17f;
    public float movementSpeed = 2f;
    public Transform playerTransform;

    public float timer = 0f;
    private int dosasFed = 0;
    private bool isAttacking = false;
    
    [SerializeField] Animator canvaspart;
    player_health playerHealth;
    private bool isTouchingPlayer = false;
    private bool hasWon = false; // Track if the player has won.

    Animator anim;
    [SerializeField] MicroBar hunger_bar;
    float gametimer = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        timer = 0f;
        playerHealth = player_health.instance;
        hunger_bar.Initialize(restingTime);
    }

    void Update()
    {

        gametimer += Time.deltaTime;
        if (!isAttacking && !hasWon) // Check if the player has not won yet.
        {
            timer += Time.deltaTime;
            
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);



            if (distanceToPlayer < 1.0f)
            {
                isTouchingPlayer = true;
            }
            else
            {
                isTouchingPlayer = false;
            }

            if (timer >= restingTime)
            {
                SwitchToAttackingState();
            }   
            hunger_bar.UpdateHealthBar(timer, true);
        }
        else if (!hasWon) // Check if the player has not won yet.
        {
            anim.SetBool("is_attacking", true);
            anim.SetBool("is_walking", false);

            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            Vector3 targetPosition = transform.position + directionToPlayer * movementSpeed;
            if (!isTouchingPlayer)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed);

            }


            if (playerTransform.position.x > transform.position.x)
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

    }

    void SwitchToAttackingState()
    {
        isAttacking = true;
        StartCoroutine(DamagePlayerOverTime());
    }

    IEnumerator DamagePlayerOverTime()
    {
        while (isAttacking)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            
            if (distanceToPlayer < 2.0f)
            {
                playerHealth.decreasehealth(8f);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }


    public void FeedCat(int dosacount)
    {
        if (!hasWon) // Check if the player has not won yet.
        {
            Debug.Log("Feeding");

             // Increment the dosas fed to the cat.
                         // timer = Mathf.Max(restingTime - (dosasFed * 2), 2f);// Decrease timer by 2 seconds each time but ensure it's at least 2 seconds.
            timer -= dosacount*2;
            if (gametimer >= 38f) // Check if the player has fed 15 dosas.
            {
                canvaspart.SetBool("win", true);
                hasWon = true; // Set the hasWon flag to true.
                Invoke("NextLevel", 0.7f);
            }
           // timer = Mathf.Max(restingTime - (dosasFed * 2), 2f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}