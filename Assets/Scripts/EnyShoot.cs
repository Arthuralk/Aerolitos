using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnyShoot : MonoBehaviour
{
	public Sprite[] Sprites;
	public float frame;
	public int Frame;
	SpriteRenderer render;
	public float fps = 10;
	public GameObject smoke;

	void Start()
	{
		render = GetComponent<SpriteRenderer>();
	}
	public void Hide()
	{
		//Hide and reconfigure
		smoke = Smoke.Instantiate(smoke);
		smoke.GetComponent<Smoke>().frame = 0;
		smoke.transform.position = transform.position;
		smoke.GetComponent<Smoke>().Type = 3;
		render.sprite = (Sprites[0]);
		frame = 0;
		Frame = 0;

	}


	void FixedUpdate()
	{
		//change frame

		if (System.Convert.ToInt16(frame - frame % 1) != Frame)
		{
			Frame = System.Convert.ToInt16(frame - frame % 1);
			render.sprite = (Sprites[Frame]);
		}

		frame += Time.deltaTime * fps;
		frame = System.Math.Min(Sprites.Length - 1, frame);
		transform.position += transform.up * Time.deltaTime * 32 / (frame + 1);
	}
	void OnCollisionEnter2D(Collision2D Col)
	{
		//if collide whith player hide and disable player
		if (Col.gameObject.CompareTag("Player"))
		{
			Col.gameObject.SetActive(false);
			Hide();
		}
	}


}
