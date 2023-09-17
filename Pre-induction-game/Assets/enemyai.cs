using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class enemyai : MonoBehaviour
{
    // public Slider healthBar;
    public GameObject healthBar;
    public float health;
    GameObject player;
    Animator anim;
    float speed = 10f;
    Rigidbody2D rb;
    Vector2 distance;
    SpriteRenderer sprite;
    Transform throwpos;
    bool isagro = false;

    [SerializeField] GameObject chalk;
    [SerializeField] Transform bounds;

    
    


    // Start is called before the first frame update
    void Start()
    {
        health = 200f;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        throwpos = GetComponentsInChildren<Transform>()[1];
        StartCoroutine(behaviour(4f));
    }

    // Update is called once per frame
    void Update()
    {

        distance = new Vector2(player.transform.position.x - transform.position.x, transform.position.y);



        if (rb.velocity != Vector2.zero && !isagro)
        {
            anim.SetBool("attack", false);
            anim.SetBool("walk", true);
        }
        else if(rb.velocity == Vector2.zero && !isagro)
        {
            anim.SetBool("walk", false);
            anim.SetBool("attack", true);
        }
        else if(isagro)
        {
            anim.SetBool("walk", false);
            anim.SetBool("attack", false);
        }
        if (distance.x > 0)
        {
            sprite.flipX = true;

        }
        else if (distance.y < 0)
        {
            sprite.flipX = false;

        }

    }
    private void FixedUpdate()
    {
        if (distance.x > 10f || distance.x < -10f)
        {
            //anim.SetBool("attack", false);
            rb.velocity = new Vector2(distance.normalized.x * speed, 0f);

        }
        else
        {
            rb.velocity = Vector2.zero;

        }
        if(isagro)
        {
            rb.velocity = Vector2.zero;
        }

        // healthBar.value = ((health)/200f)*0.39f + 0.61f;
        if(health >= 0){
            healthBar.transform.localScale = new Vector3((health)/200f, 1, 1);
        }
        else{
            healthBar.transform.localScale = new Vector3(0, 1, 1);
        }
    }
    public void throw_chalk()
        {
        //Instantiate(chalk, throwpos.position, Quaternion.identity);
        var c = Instantiate(chalk, throwpos.position, Quaternion.identity);
        Chalk cb = c.GetComponent<Chalk>();
        cb.targetPos = new Vector3(player.transform.position.x - (transform.position.x - player.transform.position.x), -10, 0);
        cb.arcHeight = player.transform.position.y + 9;
    }
    private IEnumerator behaviour(float timer)
    {
        yield return new WaitForSeconds(timer);
        
        int time = Random.Range(2, 5);
        yield return new WaitForSeconds(time);
        isagro = true;
        anim.SetTrigger("agro");
        yield return new WaitForSeconds(2.5f);
        isagro = false;
        time = Random.Range(5, 10);
        yield return new WaitForSeconds(time);
        StartCoroutine(behaviour(1f));
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.tag == "playerAttacks"){
            health -= 20f;
        }
    }

}
