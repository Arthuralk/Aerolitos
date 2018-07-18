using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
	public GameObject Tiro;
	public float LifeTime = 2;
	float TiroStatus;
	Pool TiroPool;
	// Use this for initialization
	void Start()
	{
		//Create pool party
		TiroPool = new Pool(Tiro, 10);
	}
	// Update is called once per frame
	void Update()
	{
		var ShootBt = GamePad.A;
		//Shoot
		if (TiroStatus <= 0 && ShootBt)
		{
			Tiro = TiroPool.Instantiate();
			Tiro.transform.position = transform.position;
			Tiro.transform.rotation = transform.rotation;
			Tiro.transform.position += Tiro.transform.up * 0.8f;
			Tiro.transform.localScale = new Vector3(1, 1, 1);
			Tiro.transform.parent = transform.parent;
			Tiro.GetComponent<AudioSource>().Play();
			Tiro.GetComponent<BoxCollider2D>().isTrigger = false;
			TiroStatus = 0.2f;
		}
		TiroStatus -= Time.deltaTime;
	}
}