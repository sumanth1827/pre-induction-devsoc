
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject couple;

    public Transform parentSpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(Random.Range(4f,6f)));
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private IEnumerator spawnEnemy(float delayInSeconds)
    {
        GameObject couples_pre = Instantiate(couple, transform.position, Quaternion.identity,parentSpawn);
        yield return new WaitForSeconds(delayInSeconds);
        StartCoroutine(spawnEnemy(Random.Range(4f, 6f)));
    }
   
}
