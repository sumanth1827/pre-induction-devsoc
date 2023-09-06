using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public static playermovement instance;


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


    bool candash = true, isdashing;
    [SerializeField] float dashingpower = 24f;
    float dashingtime = 0.1f;
    float dashingcooldown = 0.5f;
    TrailRenderer dashtrail;

    float time = 0f;
    float powertime;
    float maxpowertime = 5f;
    [SerializeField] GameObject paperball;
    float launchspeed = 20f;
    Vector2 mouseposition;
    Vector2 maindirection;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        sprite = GetComponent<SpriteRenderer>();
        groundcheck = GetComponentsInChildren<Transform>()[1];
        dashtrail = GetComponent<TrailRenderer>();

    }
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isdashing)
        {
            return;
        }
        walkInput = Input.GetAxisRaw("Horizontal");
        speed = grounded ? groundspeed : airspeed;
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos = transform.position;
        maindirection = mouseposition - pos;
        
        if(walkInput > 0 )
        {
            sprite.flipX = false;
            direction = 1;
        }
        else if(walkInput < 0 )
        {
            sprite.flipX = true;
            direction = -1;
        }
        anim.SetBool("jump", grounded);
        if (Input.GetKeyDown("space") && grounded)
        {
            
            rb.AddForce(new Vector2(rb.velocity.x, jumpforce), ForceMode2D.Impulse);
            
            //rb.velocity = new Vector2(rb.velocity.x, 15f);
            //grounded = false;
        }
 
        if(Input.GetKeyDown(KeyCode.LeftShift) && candash)
        {
            StartCoroutine(Dashing());
        }

        if (Input.GetMouseButton(0))
        {
            time += Time.deltaTime;


        }
        if(Input.GetMouseButtonUp(0))
        {
            if(time> maxpowertime)
            {
                powertime = maxpowertime;
            }
            else
            {
                powertime = time;
            }
            float force;
            force = shoot(powertime);
            Debug.Log(shoot(powertime));
            GameObject newball = Instantiate(paperball, transform.position, transform.rotation);

            newball.GetComponent<Rigidbody2D>().velocity = maindirection.normalized*force;

            time = 0;
        }
    

    }
    private void FixedUpdate()
    {
        if (isdashing)
        {
            return;
        }
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
        force = 5f + powertime*launchspeed;
        return force;

    }
}
