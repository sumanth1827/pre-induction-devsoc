using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class couples : MonoBehaviour
{
    public bool hit = false;
    public float shrinkFactor = 0.8f;
    public float speed = 8f;
    public Rigidbody2D rb;
    public GameObject end;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        EnemySpeed();

        if (hit)
        {
            Transform objectTransform = gameObject.GetComponent<Transform>();

            Vector3 newScale = new Vector3(objectTransform.localScale.x * shrinkFactor, objectTransform.localScale.y * shrinkFactor, objectTransform.localScale.z);

            objectTransform.localScale = newScale;
        }
    }

    private void EnemySpeed()
    {
        Vector2 velocity = Vector2.left * speed;

        rb.velocity = velocity;
    }

}
