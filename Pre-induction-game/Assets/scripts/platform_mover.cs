using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_mover : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float offsetx, offsety = 0f;
    Vector2 frompos, topos;
    // Start is called before the first frame update
    void Start()
    {
        frompos = new Vector2(transform.position.x, transform.position.y);
        topos = new Vector2(transform.position.x + offsetx, transform.position.y + offsety);


    }

    // Update is called once per frame
    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(frompos, topos, pingPong);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playermovement.instance.grounded && playermovement.instance.grounded2)
        {
            
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
