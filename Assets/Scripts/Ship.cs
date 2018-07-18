using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
	public GameObject Game;
	public GameObject Menu;
	public GameObject FireL;
	public GameObject FireR;
	public GameObject Pause;
	public GameObject Prefab;
	public GameObject smoke;
	public static int Life = 3;
	float time;

	// Use this for initialization
	void OnDisable()
	{
		if (Menu != null)
		{
			smoke = Smoke.Instantiate(smoke);
			smoke.GetComponent<Smoke>().frame = 0;
			smoke.GetComponent<Smoke>().Type = 0;
			smoke.transform.position = transform.position;
			Game.GetComponent<AudioSource>().Play();
			if (Life <= 0)
			{
				Menu.SetActive(true);
			}
			else
			{
				transform.parent.GetComponent<Game>().ReviveShip();
				transform.position = new Vector3(0, 0, 0);
				Life--;
			}
		}	}
	public void Start()
	{
		GetComponent<PolygonCollider2D>().enabled = false;
		time = 3;
	}

	// Update is called once per frame
	void Update()
	{

		if (time > 0)
		{
			time -= Time.deltaTime;
			if (time <= 0)
			{
				GetComponent<PolygonCollider2D>().enabled = true;
			}
		}


		var pause = GamePad.B;

		if (pause)
		{
			Life++;
			Pause.SetActive(true);
			Game.SetActive(false);
		}

		var Firescale = Mathf.Max(GamePad.Y, 0);
		var FirescaleL = Mathf.Max(GamePad.X, 0);
		var FirescaleR = Mathf.Max(GamePad.X * -1, 0);

		FireR.transform.localScale = new Vector2(1, 1) * Mathf.Clamp(Firescale - FirescaleR / 2 + FirescaleL, 0, 1);
		FireL.transform.localScale = new Vector2(1, 1) * Mathf.Clamp(Firescale - FirescaleL / 2 + FirescaleR, 0, 1);
	}
	static public void lifeUp()
	{
		var life = Instantiate
		(
			UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/LifeUp.prefab"),
			new Vector3(1000, 0, 0),
			new Quaternion(0, 0, 0, 0)
		);
		life.GetComponent<AudioSource>().Play();
		Destroy(life, 1);
		Life += 1;	}
}
