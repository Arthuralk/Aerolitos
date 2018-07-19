using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject text;
	public GameObject Game;
	public GameObject Menu;
	public UnityEngine.Audio.AudioMixer Mixer;
	int Cursor;
	int Volume;
	float time;
	string[] Options = { "Resume", "Sound", "Restart", "Quit" };
	// Use this for initialization
	string Selection(int Cursor)
	{
		var text = "";
		for (int i = 0; i < Options.Length; i++)
		{

			if (i == Cursor)
			{
				if (Options[i] == "Sound")
				{
					for (int j = 0; j < 4 + Volume / 2; j++)
					{
						text += "<";
					}
					text += Options[i];
					for (int j = 0; j < 4 + Volume / 2; j++)
					{
						text += ">";
					}
				}
				else text += "> " + Options[i] + " <";

			}
			else
			{
				text += Options[i];
			}
			text += "\n";

		}

		return text;
	}




	void run(string cmd)
	{
		GamePad.reset();
		switch (cmd)
		{
			default:
				break;

			case "Resume":
				Game.SetActive(true);
				gameObject.SetActive(false);
				break;
			case "Sound":
				Volume-=2;
				if (Volume < -8)
				{
					Volume = 0;
				}
				Mixer.SetFloat("Vol", Volume * 10);
				GetComponent<AudioSource>().Play();
				break;
			case "Restart":
				Game.SetActive(true);
				gameObject.SetActive(false);
				Ship.Life = 0;
				Game.SetActive(false);
				Cursor = 0;
				break;
			case "Quit":
				#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
				#endif
				Application.Quit();
				print("Quit");
				break;
		}

	}

	void Start()
	{
        printText();
	}

	void printText()
	{
		text.GetComponent<UnityEngine.UI.Text>().text = "Pause\n\n" +
            Selection(Cursor);
	}

	// Update is called once per frame
	void Update()
	{
		if (time <= 0)
		{
			if (GamePad.Y < 0)
			{
				Cursor++;
				time = 1;
				if (Cursor >= Options.Length)
				{
					Cursor = 0;
				}
			}
			if (GamePad.Y > 0)
			{
				Cursor--;
				time = 1;
				if (Cursor < 0)
				{
					Cursor = Options.Length - 1;
				}
			}
			if (GamePad.A)
			{
				time = 1;
				run(Options[Cursor]);
			}
			if (time>0)
			{
                printText();
			}
		}
		else
		{
			time -= Time.deltaTime * 3;
		}

	}
}
