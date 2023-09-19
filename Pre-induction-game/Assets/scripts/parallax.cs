using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class parallax : MonoBehaviour
{
    private float length;
    private float startpos;
    private GameObject cam;
    [SerializeField] private float parllaxfactor;
    private float errorfactor;
    private GameObject player;
    public Rigidbody2D rb;

    void Start()
    {
        cam = GameObject.Find("CM vcam1");
        player = GameObject.Find("Player");
        startpos = transform.position.x;
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }
     
    private void Update()
    {   
        
        float temp = (cam.transform.position.x * (1-parllaxfactor)); // we did 1- parllax factor so we get the og pos
        float distance = (cam.transform.position.x * parllaxfactor);
        transform.position = new Vector3((startpos + distance), transform.position.y, transform.position.z);

        if (temp > startpos+length)
        {
            startpos += length;    
        }
        else if (temp < startpos-length) 
        {
            startpos -=length;
        }


    }
}
