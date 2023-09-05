using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    Rigidbody2D rb;
    float walkInput;
    [SerializeField] float airspeed = 9f, groundspeed = 7f, walkDeceleration = 20f, jumpforce = 15f;
    bool grounded = false;
    float speed;
    Animator anim;
    SpriteRenderer sprite;
    [SerializeField] LayerMask ground;
    Transform groundcheck;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        sprite = GetComponent<SpriteRenderer>();
        groundcheck = GetComponentsInChildren<Transform>()[1];

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        walkInput = Input.GetAxisRaw("Horizontal");
        speed = grounded ? groundspeed : airspeed;
        if(walkInput > 0 )
        {
            sprite.flipX = false;
        }
        else if(walkInput < 0 )
        {
            sprite.flipX = true;
        }
        anim.SetBool("jump", grounded);
        if (Input.GetKeyDown("space") && grounded)
        {
            
            rb.AddForce(new Vector2(rb.velocity.x, jumpforce), ForceMode2D.Impulse);
            
            //rb.velocity = new Vector2(rb.velocity.x, 15f);
            //grounded = false;
        }

    }
    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, ground);
        if (walkInput != 0f)
        {
            anim.SetBool("walk", true);
          
            rb.velocity = new Vector2(walkInput * speed, rb.velocity.y);
        }
        else
        {
            anim.SetBool("walk", false);
            if (rb.velocity.x != 0)
            {
                rb.AddForce(new Vector2(-rb.velocity.x * walkDeceleration, 0));
            }
        }
    }
}
