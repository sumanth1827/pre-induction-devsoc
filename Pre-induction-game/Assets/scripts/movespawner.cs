using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movespawner : MonoBehaviour
{   
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if (gameObject.tag == "spawner")
        {
            transform.position = new Vector2(Camera.main.transform.position.x + 25f, transform.position.y);
        }
        else if (gameObject.tag == "end")
        {
            transform.position = new Vector2(Camera.main.transform.position.x - 25f, transform.position.y);

        }else if (gameObject.tag == "dogSpawner")
        {
            transform.position = new Vector2(Camera.main.transform.position.x + 30f, transform.position.y);
        }
    }
}
