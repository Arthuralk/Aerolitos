using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
	Vector2 pos;
	public GameObject Star;
	Pool StarPool;
	// Use this for initialization
	void Start()
	{
		StarPool = new Pool(Star, 32);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Star = StarPool.Instantiate();
		pos.x = Random.Range(-9, 9);
		pos.y = Random.Range(-5, 5);
		Star.transform.position = pos;
		Star.transform.parent = transform;
	}
}
