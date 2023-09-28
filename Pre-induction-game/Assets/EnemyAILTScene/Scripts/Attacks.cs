using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    // private CapsuleCollider2D cc;

    // Start is called before the first frame update
    void Start()
    {
        //cc = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            Destroy(gameObject);
            player_health.instance.decreasehealth(10f);
        }
        if (col.tag == "platform")
        {
            
            col.gameObject.GetComponent<Animator>().SetTrigger("break");
            Destroy(gameObject);
        }
    }
}
