using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnyShoot : MonoBehaviour
{
	public Sprite[] Sprites;
	public float Frame;
	public float fps = 10;
	public GameObject smoke;

	public void Hide()
	{
		//Hide and reconfigure
		smoke = Smoke.Instantiate(smoke);
		smoke.GetComponent<Smoke>().frame = 0;
		smoke.transform.position = transform.position;
		smoke.GetComponent<Smoke>().Type = 3;
		transform.position = new Vector3(10000, 0, 0);
	}


	void FixedUpdate()
	{
		//change frame
		GetComponent<SpriteRenderer>().sprite = (Sprites[int.Parse(Mathf.Floor(Frame) + "")]);
		Frame += Time.deltaTime * fps;
		Frame = Mathf.Min(Sprites.Length - 1, Frame);
		transform.position += transform.up * Time.deltaTime * 32 / (Frame + 1);
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
