
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class dogSpawner : MonoBehaviour
{
    [SerializeField] private GameObject doggo;
    [SerializeField] GameObject dogs;
    bool stopspawn = false;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(Random.Range(8f, 10f)));
    }

    // Update is called once per frame
    void Update()
    {
        if (dogs.transform.childCount > 3)
        {
            stopspawn = true;
        }
        else
        {
            stopspawn = false;
        }

    }
    private IEnumerator spawnEnemy(float delayInSeconds)
    {
       
        if(!stopspawn)
        {
            GameObject couples_pre = Instantiate(doggo, transform.position, Quaternion.identity, dogs.transform);
            yield return new WaitForSeconds(delayInSeconds);
        }

        

        StartCoroutine(spawnEnemy(Random.Range(5f, 7f)));
        
        
    }
}
