using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public float delayInSeconds=1f;
    public GameObject spawner;
    [SerializeField] GameObject spawn;
    void Start()
    {
        InvokeRepeating("InstantiateObject", delayInSeconds,delayInSeconds);
    }

    void Update()
    {

    }
    void InstantiateObject()
    {
        GameObject couples_pre=Instantiate(spawn, spawner.transform.position,Quaternion.identity);
    }
}
