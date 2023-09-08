using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalkGeneration : MonoBehaviour
{
    public Transform origin;
    public GameObject chalk;
    public EnemyAI enemyAI;
    public Animator enemyAnim;
    public float minX;
    public float maxX;
    public float timeBetweenSpawn = 2f;
    private float spawntime;
    private GameObject player;
    private Transform playerTr;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTr = player.GetComponent<Transform>();
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
