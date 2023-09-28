using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

using UnityEngine;

public class dogAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    public Rigidbody2D rb;
    private Vector3 disp;


    public float distance;
    public float speed;
    public float leapSpeed; 
    public float stopchase;
    public float attackDistance;
    public float thrust;
    public float leapCooldown = 2.0f;
    private float cooldownTimer = 0.0f;

    private bool IsFacingRight = false;
    private bool isMoving = false;
    private bool hasLeaped = false;
    private bool isAttacking = false;
    private bool isSitting = false;
    private bool test = true;



    // Start is called before the first frame update
    void Start()
    {
     anim = GetComponent<Animator>();
    }

    
    
    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMoving", isMoving);
        //anim.SetBool("isAttacking", isAttacking);
        
       



        distance = Vector2.Distance(transform.position, player.transform.position);
        disp = player.transform.position - transform.position;


        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0)
            {
                // Reset the cooldown and return to chasing state
                cooldownTimer = 0;
                isMoving = true;
            }
        }


        if (distance < stopchase) 
        {   
            
            isMoving = true;

            if (distance <= attackDistance) 
            {   
                isMoving= false;
                
                LeapTowardsPlayer();
            }
            else 
            {   
                hasLeaped= false;
                //isAttacking= false;
                if (transform.position.x > player.transform.position.x && test)
                {
                    transform.position += Vector3.left * Time.deltaTime * speed;
                }
                if (transform.position.x < player.transform.position.x && test)
                {
                    transform.position += Vector3.right * Time.deltaTime * speed;
                }
            }
            
        }
        
   
    else if (distance > stopchase && !test)
        { 
            isMoving = false;
            hasLeaped   = false;
            
        }
   
    }


    private void FixedUpdate()
    {
        turning();
    }

    private void turning()
    {
        if (!IsFacingRight && disp.x > 0)
        {
            Flip();
        }
        if (IsFacingRight && disp.x < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }

    private void LeapTowardsPlayer()
    {
        /* Vector3 leapdirection = (player.transform.position - transform.position).normalized;
         rb.velocity = leapdirection * Time.deltaTime * leapSpeed;*/
        //isAttacking = true;
        
       
            
            Vector3 leapDirection = (player.transform.position - transform.position).normalized;
        anim.SetBool("isAttacking", true);

        if (!hasLeaped && test)
        {
            isAttacking = true;
            // Apply an upward force only when within attack distance
            if (distance <= attackDistance)
            {
                Vector2 leapForce = new Vector2(leapDirection.x, 1f).normalized * thrust*Time.deltaTime;
                rb.AddForce(leapForce, ForceMode2D.Impulse);
            }

            // Set the flag to true to indicate that the leap has been performed
            hasLeaped = true;

            

            // Add logic here to trigger the leap animation
            // You can set a trigger in your Animator to play the leap animation.
            
            
        }

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isSitting = true;
            test = false;
            anim.SetBool("isSitting", true);
        }
    }



}
