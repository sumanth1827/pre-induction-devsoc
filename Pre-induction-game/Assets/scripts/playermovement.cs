using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Microlight.MicroBar;
using static Unity.VisualScripting.Member;

public class playermovement : MonoBehaviour
{
    public static playermovement instance;

    //movement:
    Rigidbody2D rb;
    float walkInput;
    [SerializeField] float airspeed = 9f, groundspeed = 7f, walkDeceleration = 20f, jumpforce = 15f;
   public bool grounded = false,grounded2;
    float speed;
    Animator anim;
    int direction = 1;

    SpriteRenderer sprite;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask actground;
    Transform groundcheck;

    

    //dashing
    bool candash = true, isdashing;
    [SerializeField] float dashingpower = 24f;
    float dashingtime = 0.1f;
    float dashingcooldown = 0.5f;
    TrailRenderer dashtrail;

    //shooting
    float time = 0f;
    bool isloading;
    [SerializeField] GameObject paperball;
    Vector2 mouseposition;
    Vector2 maindirection;
    [SerializeField] MicroBar launchbar;
    Transform shootpoint;
    bool canshoot = true;
    [SerializeField] float totaltime = 2f;

    //couples
    public bool hit = false;
    Collider2D isHit;
    [SerializeField] LayerMask couples;
    Transform groundcheck2;
    [SerializeField] float bounce = 7f;

    public bool alive = true;
    [SerializeField] bool allowpaperball = false;
   
   
    // Start is called before the first frame update
    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        sprite = GetComponent<SpriteRenderer>();
        groundcheck = GetComponentsInChildren<Transform>()[1];
        shootpoint = GetComponentsInChildren<Transform>()[3];
        groundcheck2 = GetComponentsInChildren<Transform>()[2];
        dashtrail = GetComponent<TrailRenderer>();
        launchbar.Initialize(totaltime);
        Application.targetFrameRate = 300;

    }
    void Start()
    {
        
        instance = this;
        launchbar.UpdateHealthBar(0f, true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isdashing)
        {
            return;
        }
        if (alive)
        {

            isHit = Physics2D.OverlapCircle(groundcheck2.position, 0.5f, couples);
            if (isHit != null)
            {
                rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
                // isHit.gameObject.GetComponent<couples>().hit = true;
            }
            walkInput = Input.GetAxisRaw("Horizontal");
            speed = grounded ? groundspeed : airspeed;

            if (walkInput > 0)
            {
                sprite.flipX = false;
                direction = 1;
            }
            else if (walkInput < 0)
            {
                sprite.flipX = true;
                direction = -1;
            }
            anim.SetBool("jump", grounded2);
            if (Input.GetKeyDown("space") && grounded)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpforce), ForceMode2D.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && candash)
            {
                StartCoroutine(Dashing());
            }




            if(allowpaperball)
            {
                mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 pos = transform.position;
                maindirection = mouseposition - pos;
                if(Input.GetMouseButtonDown(0) && canshoot)
                {
                    time = Time.time;
                    GameObject newball = Instantiate(paperball, shootpoint.position, transform.rotation);
                    newball.GetComponent<Rigidbody2D>().velocity = maindirection.normalized * 35f;
                    canshoot = false;
                    isloading = true;
                }
                if(isloading)
                {
                    float holdtime = Time.time - time;
                    launchbar.UpdateHealthBar(holdtime, true);
                }

                if (Time.time - time > totaltime)
                {
                    canshoot = true;
                    isloading = false;
                }
                
            }


        }
        else
        {
            anim.SetBool("jump", true);
            anim.SetBool("walk", false);
        }

    }
    private void FixedUpdate()
    {
       
        if (isdashing)
        {
            return;
        }
        if (alive)
        {
            grounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, ground);
            grounded2 = Physics2D.OverlapCircle(groundcheck.position, 0.2f, actground);


            if (walkInput != 0f || (rb.velocity.x != 0 && rb.velocity.y == 0f))
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
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private IEnumerator Dashing()
    {
        candash = false;
        isdashing = true;
        float grav = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(direction*dashingpower, 0f);    
        dashtrail.emitting = true;
        yield return new WaitForSeconds(dashingtime);
        dashtrail.emitting = false;
        rb.gravityScale = grav;
        isdashing = false;
        yield return new WaitForSeconds(dashingcooldown);
        candash = true;
    }



}
