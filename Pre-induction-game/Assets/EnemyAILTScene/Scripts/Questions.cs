using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    private EnemyAI prof;
    public GameObject questions;

    public float speed = 10f;
    public float maxY = 4.5f;
    public float minY = -4.5f;
    public float maxT = 8f;
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
