using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogenemy : MonoBehaviour
{
    GameObject player;
    Animator anim;
    Rigidbody2D rb;
    float distance;

    float minchasedist = 20f;
    float attackdistance = 5f;

    bool attacked;
     


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.x - transform.position.x;


        
    }
    private void FixedUpdate()
    {
        if(distance < minchasedist)
        {

        }
    }
}
