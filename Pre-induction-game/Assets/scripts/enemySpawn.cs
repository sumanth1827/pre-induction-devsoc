using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public float delayInSeconds = 1f;

    public GameObject spawner;
    Vector2 location;

    [SerializeField] GameObject spawn;
    void Start()
    {
       StartCoroutine(spawnEnemy(delayInSeconds));
    }

    void Update()
    {
        location = spawn.transform.position;
        
    }
    private IEnumerator spawnEnemy(float delayInSeconds)
    {
        GameObject couples_pre = Instantiate(spawn, location, Quaternion.identity);
        yield return new WaitForSeconds(delayInSeconds);
        StartCoroutine(spawnEnemy(delayInSeconds));
    }
}
