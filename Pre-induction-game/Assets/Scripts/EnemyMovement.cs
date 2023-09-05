using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] pathPoints;
    public float moveSpeed;
    public Transform targetPoint;
    public EnemyAI enemyAI;
    private int currentPointIndex = 0;  
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = pathPoints[currentPointIndex];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = moveSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, step);

        if(enemyAI.aggro){
            moveSpeed = 0;
        }
        else{
            moveSpeed = 1;
        }

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.01f)
        {
            currentPointIndex = (currentPointIndex + 1) % pathPoints.Length;
            targetPoint = pathPoints[currentPointIndex];
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, transform.eulerAngles + 180f* Vector3.up, Time.deltaTime*1000f);
        }   

    }
}
