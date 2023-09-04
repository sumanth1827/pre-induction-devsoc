using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    public EnemyAI prof;
    public GameObject questions;

    public float speed;

    public bool isnc;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(behaviour());
    }

    
    private IEnumerator behaviour(){
        if (prof != null) {
            if(prof.aggro || !isnc){
                int ran = Random.Range(0,11);
                if(ran % 10 == 0){
                    var q = Instantiate(questions, transform.position, transform.rotation);  
                    q.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
                    StartCoroutine(des(q));
                }
            }
        }
        float t = Random.Range(0,5);
        yield return new WaitForSeconds(t);
        StartCoroutine(behaviour());
    }

    private IEnumerator des(GameObject go){
        yield return new WaitForSeconds(15f);
        Destroy(go);
    }
}
