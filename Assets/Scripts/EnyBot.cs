using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnyBot : MonoBehaviour
{
	Vector2 pos = new Vector2(10, 10);
	public float speed = 1;
	public GameObject smoke;
	public GameObject Shoot;
	public GameObject Ship;
	public GameObject LifeUpPre;
	public GameObject Eny;
	public float period = 50;
	float time = 1;
	float Y;

	// Update is called once per frame
	void Update()
	{
		period = (5000 - Score.points) / 100;
		period = Mathf.Clamp(period, 10, 50);
		//shoot
		if (time <= 0)
		{
			time = 1;
			Shoot.GetComponent<EnyShoot>().Hide();
			Shoot.transform.parent = transform.parent;
			Shoot.transform.position = transform.position;
			Quaternion rots;
			try
			{
				var p22 = transform.position;
				var p11 = Ship.transform.position;
				rots = Quaternion.Euler(0, 0, Mathf.Atan2(p22.y - p11.y, p22.x - p11.x) * 180 / Mathf.PI + 90 + Random.Range(-360 * period / 40, 360 * period / 40));
			}
			catch (System.Exception)
			{
				rots = transform.rotation;
			}

			Shoot.transform.rotation = rots;
			Shoot.GetComponent<EnyShoot>().Frame = 0;
		}
		time -= Time.deltaTime;
		//Moviment
		pos.y = Mathf.Sin(Y + pos.x / 4) * 4 + Y;
		pos.x += Time.deltaTime * speed;

		if (pos.x > period)
		{
			pos.x = -period;
			Y = Random.Range(-4, 4);
		}
		if (pos.x < -period)
		{
			pos.x = period;
			Y = Random.Range(-4, 4); ;
		}
		var p1 = transform.position;
		var p2 = pos;
		var rot = Quaternion.Euler(0, 0, Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * 180 / Mathf.PI + 90);
		transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 60 * 0.1f);
		transform.position = pos;
	}
	void OnCollisionEnter2D(Collision2D Col)
	{
		//if collide on player or shoot, reconfigure and restart cycle
		if (Col.gameObject.CompareTag("Player"))
		{
			Score.points += 75;
			smoke = Smoke.Instantiate(smoke);
			smoke.GetComponent<Smoke>().frame = 0;
			smoke.GetComponent<Smoke>().Type = 0;
			smoke.transform.position = transform.position;
			var LifeUp = Instantiate(LifeUpPre);
			LifeUp.transform.position = transform.position;
			pos.x = period * speed;
			transform.parent.gameObject.GetComponent<AudioSource>().Play();
			Col.gameObject.SetActive(false);
			speed *= -1;
			//Swap to other Eny
			if (Eny)
			{
				Eny.SetActive(true);
				gameObject.SetActive(false);
			}
		}
	}
}
