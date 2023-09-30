using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class couples : MonoBehaviour
{
    public bool hit = false;

    public float rotationSpeed = 45f;
    public float shrinkFactor = 0.8f;
    public float speedX = 8f;
    public float speedY=0f;
    public Rigidbody2D rb;
    public GameObject end;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        EnemySpeed();

        if(hit)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        // if (hit)
        // {
        //     Transform objectTransform = gameObject.GetComponent<Transform>();

        //     Vector3 newScale = new Vector3(objectTransform.localScale.x * shrinkFactor, objectTransform.localScale.y * shrinkFactor, objectTransform.localScale.z);

        //     objectTransform.localScale = newScale;
        // }
    }

    private void EnemySpeed()
    {
        Vector2 velocity = Vector2.right * speedX;

        rb.velocity = new Vector2(speedX,speedY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="playerAttacks")
        {
            hit =true;
            speedX*=(-1);
            speedY = speedX *-1;
        }
    }

}
