using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_end : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "end")
        {
            transform.position = new Vector2(Camera.main.transform.position.x - 50f, transform.position.y);

        }
    }
}
