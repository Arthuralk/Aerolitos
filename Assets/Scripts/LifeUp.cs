using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D Col)
	{
		//Add a life if collide with player
		if (Col.gameObject.name == "Ship")
		{
			Destroy(gameObject, 1);
			Ship.Life += 1;
			GetComponent<AudioSource>().Play();
			transform.position = new Vector3(1000, 0, 0);
		}
	}
	void Update()
	{
		//if spawn out of screen, go to screen
		var pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, -8, 8);
		pos.y = Mathf.Clamp(pos.y, -4, 4);
		transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 60 * 0.1f);
	}
}