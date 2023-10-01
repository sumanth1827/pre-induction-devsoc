using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Chalk : MonoBehaviour
{
	private Transform playerPos;
	private Transform profPos;
	public Vector3 targetPos;
	public float speed = 10f;
	public float arcHeight = 1;
	private Vector3 startPos;

	void Start()
	{
		startPos = transform.position;
		playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		profPos = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
		if(playerPos.position.y < 5	){
			if(Math.Abs(playerPos.position.x - profPos.position.x) < 1){
				speed =  1f;
				Debug.Log("Yes");
			}
			else{
				speed =  Math.Abs(playerPos.position.x - profPos.position.x) * 2.5f;
			}
		}
		else{
			if(Math.Abs(playerPos.position.x - profPos.position.x) < 1){
				speed =  1f;
				Debug.Log("Yes");
			}
			else{
				speed =  Math.Abs(playerPos.position.x - profPos.position.x);
			}
		}
	}

	void Update()
	{
		// Compute the next position, with arc added in
		float x0 = startPos.x;
		float x1 = targetPos.x;
		float dist = x1 - x0;
		float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
		float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
		float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
		Vector3 nextPos = new Vector3(nextX, baseY + arc, transform.position.z);

		// Rotate to face the next position, and then move there
		transform.rotation = LookAt2D(nextPos - transform.position);
		transform.position = nextPos;

		// Do something when we reach the target
		if (nextPos == targetPos) Arrived();
	}

	void Arrived()
	{
		Destroy(gameObject);
	}

	static Quaternion LookAt2D(Vector2 forward)
	{
		return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}
}