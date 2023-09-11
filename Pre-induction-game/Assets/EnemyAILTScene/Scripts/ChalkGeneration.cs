using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalkGeneration : MonoBehaviour
{
    private Transform origin;
    public GameObject chalk;
    private EnemyAI enemyAI;
    private Animator enemyAnim;
    private float timeBetweenSpawn = 2f;
    private float spawntime;
    private GameObject player;
    private Transform playerTr;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTr = player.GetComponent<Transform>();
        enemyAI = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>();
        enemyAnim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        origin = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyAI != null) {
            if(!enemyAI.aggro && !enemyAnim.GetBool("isDefeated")){
                if(Time.time > spawntime){
                    spawn();
                    spawntime = Time.time + timeBetweenSpawn;
                }
            }
        }
    }

    private void spawn(){
        var c = Instantiate(chalk, transform.position, transform.rotation);
        Chalk cb = c.GetComponent<Chalk>();
        cb.targetPos = new Vector3(playerTr.position.x - (origin.position.x - playerTr.position.x), -5, 0);
        cb.arcHeight = playerTr.position.y + 4;
    }


}
