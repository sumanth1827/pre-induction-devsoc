using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float health = 100f;
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health >= 0){
            healthBar.transform.localScale = new Vector3((health)/100f, 1, 1);
        }
        else{
            healthBar.transform.localScale = new Vector3(0, 1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Attack"){
            health -= 10f;
        }
    }
}
