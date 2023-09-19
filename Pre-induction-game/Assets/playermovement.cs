using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Microlight.MicroBar;

public class playermovement : MonoBehaviour
{
    public static playermovement instance;

    //movement:
    Rigidbody2D rb;
    float walkInput;
    [SerializeField] float airspeed = 9f, groundspeed = 7f, walkDeceleration = 20f, jumpforce = 15f;
    bool grounded = false;
    float speed;
    Animator anim;
    int direction = 1;

    SpriteRenderer sprite;
    [SerializeField] LayerMask ground;
    Transform groundcheck;
    

    //dashing
    bool candash = true, isdashing;
    [SerializeField] float dashingpower = 24f;
    float dashingtime = 0.1f;
    float dashingcooldown = 0.5f;
    TrailRenderer dashtrail;

    //shooting
    float time = 0f;
    float powertime;
    float maxpowertime = 0.5f;
    bool isloading;
    [SerializeField] GameObject paperball;
    float launchspeed = 20f;
    Vector2 mouseposition;
    Vector2 maindirection;
    [SerializeField] MicroBar launchbar;
    Transform shootpoint;

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
        launchbar.Initialize(20f);

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
            isHit = Physics2D.OverlapCircle(groundcheck2.position, 0.3f, couples);
            if (isHit != null)
            {
                rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
                isHit.gameObject.GetComponent<couples>().hit = true;
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
            anim.SetBool("jump", grounded);
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

                if (Input.GetMouseButtonDown(0))
                {
                    time = Time.time;
                    isloading = true;
                }
                if (isloading)
                {
                    float holdtime = Time.time - time;
                    launchbar.UpdateHealthBar(shoot(holdtime) - 15f, true);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log(Time.time - time);
                    if ((Time.time - time) > maxpowertime)
                    {
                        powertime = maxpowertime;
                    }
                    else
                    {
                        powertime = Time.time - time;
                    }
                    float force;
                    force = shoot(powertime);
                    Debug.Log(shoot(powertime));
                    GameObject newball = Instantiate(paperball, shootpoint.position, transform.rotation);
                    newball.GetComponent<Rigidbody2D>().velocity = maindirection.normalized * force;
                    isloading = false;
                    launchbar.UpdateHealthBar(0f, true);
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

    private float shoot(float powertime)
    {
        float force;
        float holdtimenormalized = Mathf.Clamp01(powertime / maxpowertime);
        force = 15f + (holdtimenormalized * launchspeed);
        
        return force;

    }

}
