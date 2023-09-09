using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class dogAI : MonoBehaviour
{

    public float distance;
    public GameObject player;
    public float speed;
    public Rigidbody2D rb;
    private Vector3 disp;
    public float stopchase;
    public float startbark;
    public float stopbark;
  

     

    private bool IsFacingRight = true;
    private bool isMoving = false;
    private bool isBarking = false;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    
    
    // Update is called once per frame
    void Update()
    {




        /*Vector2 direction = player.transform.position - transform.forward;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime*speed);
        */

        distance = Vector2.Distance(transform.position, player.transform.position);
        disp = player.transform.position - transform.position;
    
    if (distance < stopchase) 
        {
            isMoving = true;
            if (transform.position.x > player.transform.position.x)
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
                

            }
            if (transform.position.x < player.transform.position.x)
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
        

    else if (distance > stopchase && distance <startbark && distance >stopbark)
        {
            isMoving = false;
            isBarking = true;
        }
    else
        {
            isMoving=false;
        }


    }

    private void FixedUpdate()
    {
        turning();
    }

    private void turning()
    {
        if (!IsFacingRight && disp.x > 0)
        {
            Flip();
        }
        if (IsFacingRight && disp.x < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }
    
}
