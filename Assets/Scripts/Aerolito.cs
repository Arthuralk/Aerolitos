using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerolito : MonoBehaviour
{
	public Sprite[] SpriteList;
	public Sprite[] SpriteList1;
	public Sprite[] SpriteList2;
	public Sprite[] SpriteList3;
	public int Type;
	Vector3 lVel;
	public GameObject smoke;

	void OnDisable()
	{
		smoke = Smoke.Instantiate(smoke);
		smoke.GetComponent<Smoke>().frame = 0;
		smoke.transform.position = transform.position;
		smoke.GetComponent<Smoke>().Type = 1;
	}
	public void Start()
	{
		var body = GetComponent<Rigidbody2D>();
		transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
		body.velocity = transform.up * (Type * 2 + 1);
		body.angularVelocity = Random.Range(-100, 100);
		lVel = body.velocity;
		if (Type <= 0)
		{
			transform.position = transform.up * -15 + new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0);
		}
		var Sprites = SpriteList;
		switch (Type)
		{
			default:
				Sprites = SpriteList;
				break;
			case 1:
				Sprites = SpriteList1;
				break;
			case 2:
				Sprites = SpriteList2;
				break;
			case 3:
				Sprites = SpriteList3;
				break;
		}
		GetComponent<SpriteRenderer>().sprite = (Sprites[Random.Range(0, Sprites.Length - 1)]);
		Destroy(GetComponent<PolygonCollider2D>());
		gameObject.AddComponent<PolygonCollider2D>();
	}


	void Update()
	{
		var body = GetComponent<Rigidbody2D>();
		var vel = body.velocity;
		if (Mathf.Abs(vel.x) + Mathf.Abs(vel.y) <= 0.1)
		{
			body.velocity = lVel;
		}
		else
		{
			lVel = body.velocity;
		}
		GetComponent<PolygonCollider2D>().enabled = true;
		//If left Screen this go away.
		if (
			transform.position.x >= 20 ||
			transform.position.x <= -20 ||
			transform.position.y >= 20 ||
			transform.position.y <= -20
		   )
		{
			gameObject.SetActive(false);
		}
		//More speed if out of screen;
		if (
			transform.position.x >= 10 ||
			transform.position.x <= -10 ||
			transform.position.y >= 6 ||
			transform.position.y <= -6
		   )
		{
			transform.position += new Vector3(body.velocity.x, body.velocity.y, 0);
		}


	}

	void OnCollisionEnter2D(Collision2D Col)
	{
		//When collide whith player or Shoot
		if (Col.gameObject.CompareTag("Player"))
		{
			Type += 1;
			while (true)
			{
				if (Type > 3)
				{
					break;
				}

				for (int i = 0; i < 3; i++)
				{
					//Spawn Small Aerolitos
					var bro = transform.parent.gameObject;
					bro = bro.GetComponent<SpawnAerolito>().Instantiate(Type, transform.position);
					bro.transform.parent = transform.parent;
				}
				Col.gameObject.SetActive(false);

				break;
			}
			Score.points += (Type + 1) * 5;
			gameObject.SetActive(false);
			transform.parent.gameObject.GetComponent<AudioSource>().Play();
		}
	}
}
