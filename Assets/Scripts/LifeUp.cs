using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour
{
	public AudioSource Audio;
	void Start()
	{
		Audio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D Col)
	{
		//Add a life if collide with player
		if (Col.gameObject.name == "Ship")
		{
			Destroy(gameObject, 1);
			Ship.Life += 1;
			Audio.Play();
			transform.position = new Vector3(1000, 0, 0);
		}
	}
	void Update()
	{
		//if spawn out of screen, go to screen
		var pos = transform.position;
		pos.x = System.Math.Min(pos.x, 8);
		pos.x = System.Math.Max(pos.x, -8);
		pos.y = System.Math.Min(pos.y, 4);
		pos.y = System.Math.Max(pos.y, -4);
		transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 60 * 0.1f);
	}
}