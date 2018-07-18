using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAerolito : MonoBehaviour
{
	float time;
	public GameObject Aerolito;
	public Pool AerolitoPool;
	// Use this for initialization
	void Start()
	{
		AerolitoPool = new Pool(Aerolito, 64);
	}
	//Spawn a aerolito
	public GameObject Instantiate(int _type, Vector4 _pos)
	{
		Aerolito = AerolitoPool.Instantiate();
		Aerolito.GetComponent<Aerolito>().Type = _type;
		Aerolito.transform.position = _pos;
		Aerolito.transform.parent = transform;
		Aerolito.GetComponent<Aerolito>().Start();
		return Aerolito;
	}

	void Update()
	{
		//Spawn 1 Aerolito per time
		if (time <= 0)
		{
			Aerolito = Instantiate(0, new Vector2(0, 0));

			time = (300 - Score.points) / 100;
			time = Mathf.Clamp(time, 0.5f, 3);
		}
		time -= Time.deltaTime;
	}
}
