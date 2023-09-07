using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class couples : MonoBehaviour
{
    bool hit = false;
    public float shrinkFactor = 0.8f;

    public float speed=8f;
    public Rigidbody2D rb;
    public GameObject end;
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Invoke("EnemySpeed",1f);

        if (hit)
        {
            Transform objectTransform = gameObject.transform;

            Vector3 newScale = new Vector3(objectTransform.localScale.x * shrinkFactor, objectTransform.localScale.y * shrinkFactor, objectTransform.localScale.z);

            objectTransform.localScale = newScale;
        }
    }

    private void EnemySpeed()
    {
        Vector2 directionToEnd = (end.transform.position - transform.position).normalized;
        Vector2 velocity = directionToEnd * speed;

        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hit = true;
        }
    }

    void OnCollisionEnter2d(Collider2D collision)
    {
        
        if(collision.tag=="Player")
        {
            rb.GetComponent<CircleCollider2D>().isTrigger=false;
        }
    }

}
