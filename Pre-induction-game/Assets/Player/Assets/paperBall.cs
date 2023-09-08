using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(des());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.tag == "Enenmy"){
            Destroy(gameObject);
        }
    }

    IEnumerator des(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
