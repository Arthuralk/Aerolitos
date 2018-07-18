using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
	public Sprite[] Grey;
	public Sprite[] Orange;
	public Sprite[] Laser;
	public Sprite[] Fire;
	Sprite[] Sprites;
	public int Type;
	public float frame;
	public float fps = 3;
	static public Pool SmokePool;

	//Spawn smokes, if fail, make the pool party and Spawn smokes
	public static GameObject Instantiate(GameObject _prefab = null)
	{
		try
		{
			return SmokePool.Instantiate();
		}
		catch (System.Exception)
		{
			SmokePool = new Pool(_prefab, 4);
			return SmokePool.Instantiate();
		}	}
	//Change frames, in the last Disable the gemeObject
	void Update()
	{
		if (Type == 0)
		{
			Sprites = Grey;
		}
		if (Type == 1)
		{
			Sprites = Orange; ;
		}
		if (Type == 2)
		{
			Sprites = Laser;
		}
		if (Type == 3)
		{
			Sprites = Fire; ;
		}
		GetComponent<SpriteRenderer>().sprite = (Sprites[int.Parse(Mathf.Floor(frame) + "")]);
		frame += Time.deltaTime * fps;
		if (frame >= Sprites.Length)
		{
			gameObject.SetActive(false);
		}
	}
}
