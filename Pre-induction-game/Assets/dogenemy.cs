using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogenemy : MonoBehaviour
{
    GameObject player;
    Animator anim;
    Rigidbody2D rb;
    Vector2 distance;
    [SerializeField] float speed = 17f;
    SpriteRenderer sprite;
    [SerializeField] float jumpforce = 15f;
    float minchasedist = 25f;
    float attackdistance = 10f;

    bool attacked = false;
    bool attackcooldown = false;
    bool firsttime = true;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        distance = new Vector2(player.transform.position.x - transform.position.x, transform.position.y);
    }


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (firsttime)
        {
            minchasedist = 7f;
            attackdistance = 1f;
            
        }
        else
        {
            anim.SetBool("firsttime", true);
            minchasedist = 25f;
            attackdistance = 10f;
        }
        distance = new Vector2(player.transform.position.x - transform.position.x, transform.position.y);
        if (distance.x > 0)
        {
            sprite.flipX = true;

        }
        else if (distance.x < 0)
        {
            sprite.flipX = false;

        }

        

    }
    
    private void FixedUpdate()
    {
        
        
        if (Mathf.Abs(distance.x) < minchasedist && Mathf.Abs(distance.x) > attackdistance && !attackcooldown)
        {
           
               rb.velocity = new Vector2 (distance.normalized.x * speed, 0f);
               anim.SetBool("isMoving", true);
            
                firsttime = false;
        }
        else if(Mathf.Abs(distance.x) <= attackdistance && !attackcooldown)
        {
            anim.SetBool("isMoving", false);
            anim.SetTrigger("isAttacking");

            attacked = true;
            rb.velocity = new Vector2(distance.normalized.x * (speed + 5), rb.velocity.y);
        }
        else if(Mathf.Abs(distance.x) > minchasedist)
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("isMoving", false);
        }
        

        
        if(attacked)
        {
          
            rb.AddForce(new Vector2(rb.velocity.x, jumpforce), ForceMode2D.Impulse);
            attacked = false;
            attackcooldown = true;
            
            StartCoroutine(coolattack());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //end
        }
    }
    IEnumerator coolattack()
    {

        yield return new WaitForSeconds(0.5f);
        attackcooldown = false;
    }
}
