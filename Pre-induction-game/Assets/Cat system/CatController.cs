using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    public float restingTime = 10f;
    public float movementSpeed = 2f;
    public Transform playerTransform;

    private float timer;
    private int dosasFed = 0;
    private bool isAttacking = false;
    public Text timerText;
    [SerializeField] Animator canvaspart;
    public player_health playerHealth;
    private bool isTouchingPlayer = false;
    private bool hasWon = false; // Track if the player has won.

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        timer = restingTime;
        playerHealth = FindObjectOfType<player_health>();
    }

    void Update()
    {
        timerText.text = "Timer: " + Mathf.Ceil(timer).ToString();

        if (!isAttacking && !hasWon) // Check if the player has not won yet.
        {
            timer -= Time.deltaTime;

            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer < 1.0f)
            {
                isTouchingPlayer = true;
            }
            else
            {
                isTouchingPlayer = false;
            }

            if (timer <= 0f)
            {
                SwitchToAttackingState();
            }
        }
        else if (!hasWon) // Check if the player has not won yet.
        {
            anim.SetBool("is_attacking", true);
            anim.SetBool("is_walking", false);

            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            Vector3 targetPosition = transform.position + directionToPlayer * movementSpeed;
            transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed);

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
            playerHealth.decreasehealth(10f);
            yield return new WaitForSeconds(1f);
        }
    }

    public void FeedCat()
    {
        if (!hasWon) // Check if the player has not won yet.
        {
            Debug.Log("Feeding");

            dosasFed++;  // Increment the dosas fed to the cat.
            timer = Mathf.Max(restingTime - (dosasFed * 2), 2f);// Decrease timer by 2 seconds each time but ensure it's at least 2 seconds.

            if (dosasFed >= 5) // Check if the player has fed 15 dosas.
            {
                canvaspart.SetBool("win", true);
                hasWon = true; // Set the hasWon flag to true.
                Invoke("NextLevel", 0.7f);
            }
            timer = Mathf.Max(restingTime - (dosasFed * 2), 2f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
