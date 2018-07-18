using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
	public int RotVel = 3;
	public int MaxVel = 1;
	void Start()
	{

	}
	void Update()
	{
		//Initialize vars
		var Rigidbody = GetComponent<Rigidbody2D>();
		var dir = new Vector2(0, 0);
		//Get Imput
		dir.x = GamePad.X;
		dir.y = GamePad.Y;
		//Set rotation
		Rigidbody.angularVelocity = -dir.x * RotVel;
		//Set velocity
		Vector2 Up = transform.up;
		Rigidbody.velocity = Rigidbody.velocity + Up * dir.y;
		//Limit velocity to MaxVel
		var speed = Rigidbody.velocity.magnitude;
		dir = Rigidbody.velocity.normalized;
		Rigidbody.velocity = dir * Mathf.Clamp(speed, -MaxVel, MaxVel) * (1 - 0.01f * Time.deltaTime * 240);
		//If left Screen, Back from other side.
		if (transform.position.x > 10)
		{
			var pos = transform.position;
			pos.x = -10;
			transform.position = pos;
		}
		if (transform.position.x < -10)
		{
			var pos = transform.position;
			pos.x = 10;
			transform.position = pos;
		}
		if (transform.position.y > 6)
		{
			var pos = transform.position;
			pos.y = -6;
			transform.position = pos;
		}
		if (transform.position.y < -6)
		{
			var pos = transform.position;
			pos.y = 6;
			transform.position = pos;
		}
	}
}
