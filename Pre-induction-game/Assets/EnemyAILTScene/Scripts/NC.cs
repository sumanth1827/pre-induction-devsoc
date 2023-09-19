using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC : MonoBehaviour
{
    private EnemyAI prof;
    public GameObject questions;

    public float speed = 3f;
    public float maxX = 8f;
    public float minX = -8f;
    public float maxT = 6f;
    public float minT = 4f;
    public float timeBetweenSpawn = 2f;
    private float spawntime;

    void Start()
    {
        prof = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>();
    }


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
                float randomX = Random.Range(minX, maxX);
                var q = Instantiate(questions, transform.position + new Vector3(randomX, 0, 0), transform.rotation);
                q.GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
                StartCoroutine(des(q));
            }
        }
    }

    private IEnumerator des(GameObject go){
        yield return new WaitForSeconds(15f);
        Destroy(go);
    }
}
