using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
	public Sprite[] Sprites;
	float frame;
	int Frame;
	SpriteRenderer render;
	public float FPS = 24;

	void Start()
	{
		// Make confusing Stars
		frame = Random.Range(0, Sprites.Length);
		render = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		//Change frames, in the last Disable the gemeObject
		if (frame >= Sprites.Length)
		{
			frame = 0;
			gameObject.SetActive(false);
		}

		if (System.Convert.ToInt16( frame - frame%1) != Frame)
		{
			Frame = System.Convert.ToInt16( frame - frame%1);
			render.sprite = (Sprites[Frame]);
		}
		frame += Time.deltaTime * FPS;
	}
}
