using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    bool facingright = false;

    bool attacked = false;
    bool attackcooldown = false;
    bool firsttime = true;

    [SerializeField] bool killedplayer = false;
    public static dogenemy instance;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        distance = new Vector2(player.transform.position.x - transform.position.x, transform.position.y);
        instance = this;
    }


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (!killedplayer)
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
            if (distance.x > 0 && !facingright)
            {
                //sprite.flipX = true;
                flip();

            }
            else if (distance.x < 0 && facingright)
            {
                //sprite.flipX = false;
                flip();

            }
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        if(player_health.instance.health <=0)
        {
            killedplayer = true;
        }


    }
    void flip()
    {
        Vector3 currentscale = transform.localScale;
        currentscale.x *= -1;
        transform.localScale = currentscale;
        facingright = !facingright;
    }
    private void FixedUpdate()
    {
        if (!killedplayer)
        {

            if (Mathf.Abs(distance.x) < minchasedist && Mathf.Abs(distance.x) > attackdistance && !attackcooldown)
            {

                rb.velocity = new Vector2(distance.normalized.x * speed, 0f);
                anim.SetBool("isMoving", true);

                firsttime = false;
            }
            else if (Mathf.Abs(distance.x) <= attackdistance && !attackcooldown)
            {
                anim.SetBool("isMoving", false);
                anim.SetTrigger("isAttacking");

                attacked = true;
                rb.velocity = new Vector2(distance.normalized.x * (speed + 5), rb.velocity.y);
            }
            else if (Mathf.Abs(distance.x) > minchasedist)
            {
                rb.velocity = Vector2.zero;
                anim.SetBool("isMoving", false);
            }



            if (attacked)
            {

                rb.AddForce(new Vector2(rb.velocity.x, jumpforce), ForceMode2D.Impulse);
                attacked = false;
                attackcooldown = true;

                StartCoroutine(coolattack());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player_health.instance.decreasehealth(5f);

        }
        if(collision.tag == "end")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dogenemy.instance.killedplayer = true;
            killedplayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dogenemy.instance.killedplayer = false;
            killedplayer = false;
        }
    }
    IEnumerator coolattack()
    {

        yield return new WaitForSeconds(0.5f);
        attackcooldown = false;
    }
    
}
