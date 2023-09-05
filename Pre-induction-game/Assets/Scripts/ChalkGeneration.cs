using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalkGeneration : MonoBehaviour
{
    public GameObject chalk;
    public EnemyAI enemyAI;
    public float minX;
    public float maxX;
    public float timeBetweenSpawn = 2f;
    private float spawntime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyAI != null) {
            if(enemyAI.aggro){
                if(Time.time > spawntime){
                    spawn();
                    spawntime = Time.time + timeBetweenSpawn;
                }
            }
        }
    }

    private void spawn(){
        float randomX = Random.Range(minX, maxX);
        var c = Instantiate(chalk, transform.position, transform.rotation);
        Chalk cb = c.GetComponent<Chalk>();
        cb.targetPos = new Vector3(randomX, transform.position.y - 2, 0);
    }
}
