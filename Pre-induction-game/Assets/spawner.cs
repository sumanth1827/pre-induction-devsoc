
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject couple;
    [SerializeField] float delayInSeconds = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(Random.Range(4f,8f)));
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private IEnumerator spawnEnemy(float delayInSeconds)
    {
        GameObject couples_pre = Instantiate(couple, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(delayInSeconds);
        StartCoroutine(spawnEnemy(Random.Range(4f, 8f)));
    }
   
}
