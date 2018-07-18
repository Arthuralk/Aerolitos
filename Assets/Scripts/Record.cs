using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
	float Time1 = 1;
	float Delay = 0.3f;
	public GameObject TextView;
	public GameObject Menu;
	int min = 32;
	int max = 96;
	int Cursor;
	int[] text = { 65, 65, 65 };
	// Use this for initialization
	void Start()
	{

	}

	string Under(int _val)
	{
		if (_val == 0)
		{
			return "-  ";
		}
		if (_val == 1)
		{
			return " - ";
		}
		if (_val == 2)
		{
			return "  -";
		}
		return "";
	}

	// Update is called once per frame
	void Update()
	{
		if (Score.isRecord())
		{
			if (GamePad.X + GamePad.Y == 0)
			{
				Time1 = 0;
			}
			//For set three numbers
			if (Time1 <= 0)
			{
				if (GamePad.X > 0)
				{
					Time1 = Delay;
					Cursor += 1;
					if (Cursor > 2)
					{
						Cursor = 0;
					}
				}
				if (GamePad.X < 0)
				{
					Time1 = Delay;
					Cursor -= 1;
					if (Cursor < 0)
					{
						Cursor = 2;
					}
				}


				if (GamePad.Y > 0)
				{
					Time1 = Delay;
					text[Cursor] += 1;

					if (text[Cursor] > max)
					{
						text[Cursor] = min;
					}
				}
				if (GamePad.Y < 0)
				{
					Time1 = Delay;
					text[Cursor] -= 1;

					if (text[Cursor] < min)
					{
						text[Cursor] = max;
					}
				}
				if (GamePad.B)
				{
					//pack the score and letters in one number and send to score list 
					Score.add(Score.points * 1000000.0 + text[0] * 10000 + text[1] * 100 + text[2]);
					Menu.SetActive(true);
					gameObject.SetActive(false);
				}

			}
			else
			{
				Time1 -= Time.deltaTime;
			}
			//convert numbers for letters for view
			TextView.GetComponent<UnityEngine.UI.Text>().text = "" +
				System.Convert.ToChar(text[0]) +
				System.Convert.ToChar(text[1]) +
				System.Convert.ToChar(text[2]) + "\n" +
				Under(Cursor);
		}
		else
		{
			Menu.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
