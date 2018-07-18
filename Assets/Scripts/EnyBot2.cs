using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnyBot2 : MonoBehaviour
{
	int motion = 1;
	public GameObject smoke;
	public GameObject Eny;
	public GameObject Shoot;
	float time;
	// Use this for initialization
	void Start()
	{
		transform.position = new Vector2(20, 4);
	}

	// Update is called once per frame
	void Update()
	{
		//Shoot
		if (time <= 0)
		{
			time = 1;
			Shoot.GetComponent<EnyShoot>().Hide();
			Shoot.transform.parent = transform.parent;
			Shoot.GetComponent<EnyShoot>().Frame = 0;
			Shoot.transform.rotation = transform.rotation;
			Shoot.transform.Rotate(new Vector3(0, 0, 180));
			Shoot.transform.position = transform.position - transform.up/2;
			Eny.SetActive(false);
		}
		time -= Time.deltaTime;
		//Moviment
		if (Score.points < 5000)
		{
			var pos = transform.position;
			if (pos.x < -20)
			{
				pos.x = 20;
			}
			if (pos.x > 20)
			{
				pos.x = -20;
			}
			transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(transform.position.x) * 32);
			pos.x += Time.deltaTime * motion;
			transform.position = pos;
		}
		else
		{
			//disable if score is over 5000
			Eny.SetActive(true);
			gameObject.SetActive(false);
		}
	}
	void OnCollisionEnter2D(Collision2D Col)
	{
		//if collide on player or shoot, reconfigure and restart cycle
		if (Col.gameObject.CompareTag("Player"))
		{
			motion *= -1;
			Score.points += 25;
			smoke = Smoke.Instantiate(smoke);
			smoke.GetComponent<Smoke>().frame = 0;
			smoke.GetComponent<Smoke>().Type = 0;
			smoke.transform.position = transform.position;
			transform.position = new Vector2(20, 4);
			Col.gameObject.SetActive(false);
			transform.parent.gameObject.GetComponent<AudioSource>().Play();
			//Swap to other Eny
			if (Eny)
			{
				Eny.SetActive(true);
				gameObject.SetActive(false);
			}

		}
	}
}
