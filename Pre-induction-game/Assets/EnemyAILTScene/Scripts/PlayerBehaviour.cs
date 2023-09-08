using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public int health = 5;
    public Text healthbox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbox.text = health.ToString();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Attack"){
            health--;
        }
    }
}
