using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogspawner_evening : MonoBehaviour
{
    [SerializeField] private GameObject doggo;
    private int dogCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(Random.Range(8f, 10f)));
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator spawnEnemy(float delayInSeconds)
    {
        dogCounter++;
        GameObject couples_pre = Instantiate(doggo, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(delayInSeconds);
        if (dogCounter <= 1)
            StartCoroutine(spawnEnemy(Random.Range(8f, 10f)));
    }
}
