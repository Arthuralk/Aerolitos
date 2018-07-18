using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
	public Sprite[] Sprites;
	float frame;
	int Frame;
	public float FPS = 24;

	void Start()
	{
		// Make confusing Stars
		frame = Random.Range(0, Sprites.Length);
	}

	void Update()
	{
		//Change frames, in the last Disable the gemeObject
		if (frame >= Sprites.Length)
		{
			frame = 0;
			gameObject.SetActive(false);
		}
		var render = GetComponent<SpriteRenderer>();
		if (int.Parse(Mathf.Floor(frame) + "") != Frame)
		{
			Frame = int.Parse(Mathf.Floor(frame) + "");
			render.sprite = (Sprites[Frame]);
		}
		frame += Time.deltaTime * FPS;
	}
}
