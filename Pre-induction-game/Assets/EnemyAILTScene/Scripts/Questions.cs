using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    public EnemyAI prof;
    public GameObject questions;

    public float speed;
    public float maxY;
    public float minY;
    public float maxT;
    public float minT;
    public float timeBetweenSpawn;
    private float spawntime;

    // Start is called before the first frame update
    void Update()
    {
        if(Time.time > spawntime){
            spawn();
            spawntime = Time.time + timeBetweenSpawn;
        }
    }

    
    private void spawn(){
        if (prof != null) {
            if(prof.aggro){
                timeBetweenSpawn = Random.Range(minT, maxT);
                float randomY = Random.Range(minY, maxY);
                var q = Instantiate(questions, transform.position + new Vector3(0, randomY, 0), transform.rotation);
                q.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
                StartCoroutine(des(q));
            }
        }
    }

    private IEnumerator des(GameObject go){
        yield return new WaitForSeconds(15f);
        Destroy(go);
    }
}
