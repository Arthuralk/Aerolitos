using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
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
		Star.transform.position = new Vector2(Random.Range(-9, 9), Random.Range(-5, 5));
		Star.transform.parent = transform;
	}
}
