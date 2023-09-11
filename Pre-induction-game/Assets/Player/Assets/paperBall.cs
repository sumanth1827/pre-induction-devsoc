using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperBall : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity == Vector2.zero)
        {
            anim.enabled = false;
            StartCoroutine(delete());
        }
    }
    private IEnumerator delete()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);    
    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.collider.tag == "Enemy"){
            Destroy(gameObject);
        }
    } 
}
