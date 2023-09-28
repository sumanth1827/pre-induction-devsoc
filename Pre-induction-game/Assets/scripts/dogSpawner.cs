
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;


public class dogSpawner : MonoBehaviour
{
    [SerializeField] private GameObject doggo;
    [SerializeField] GameObject dogs;
    bool stopspawn = false;
    float timer = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;


    }
    private void FixedUpdate()
    {
        if (timer > Random.Range(3f, 6f) && dogs.transform.childCount <= 2)
        {
            Instantiate(doggo, transform.position, Quaternion.identity, dogs.transform);
            timer = 0f;
        }
    }

}
