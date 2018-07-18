using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	public GameObject Game;
	public GameObject Record;
	public GameObject GamePrefab;
	public GameObject Pause;
	float WaitToGame;
	// Use this for initialization

	void Start()
	{
		OnEnable();
	}
	void OnEnable()
	{
		Game.SetActive(false);
		Pause.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		//configure and start the game if press a button
		if (WaitToGame > 2)
		{
			Game.SetActive(false);
			Destroy(Game);
			Game = Instantiate(GamePrefab);
			Ship.Life = 3;
			Game.SetActive(true);
			Game.transform.Find("Ship").gameObject.GetComponent<Ship>().Menu = Record;
			Game.transform.Find("Ship").gameObject.GetComponent<Ship>().Game = Game.gameObject;
			Game.transform.Find("Ship").gameObject.GetComponent<Ship>().Pause = Pause.gameObject;
			Pause.GetComponent<PauseMenu>().Menu = gameObject;
			Pause.GetComponent<PauseMenu>().Game = Game;
			Score.points = 0;
			WaitToGame = 0;
			gameObject.SetActive(false);
		}

		if (GamePad.A)
		{
			GamePad.reset();
			WaitToGame = 1.8f;
		}

		if (WaitToGame >= 1)
		{
			WaitToGame += Time.deltaTime;
		}

	}
}
