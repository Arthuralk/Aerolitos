using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHiScores : MonoBehaviour
{

	// Use this for initialization

	string decode(double _value)
	{
		//decode and return the three hide letters in the number
		if ((_value + "").Length < 6) {
			return "???";
		}

		var val = _value % 1000000;
		var A = (val - val % 10000) / 10000;
		var B = ((val - A * 10000) - (val - A * 10000) % 100) / 100;
		var C = val - A * 10000 - B * 100;
		int a = System.Convert.ToInt16(A);
		int b = System.Convert.ToInt16(B);
		int c = System.Convert.ToInt16(C);
		return
			(
				System.Convert.ToChar(a) + "" +
				System.Convert.ToChar(b) + "" +
				System.Convert.ToChar(c) + ""
			);
	}
	//return dots
	string dot(int _vount)
	{
		var text = "";
		for (int i = 0; i < _vount; i++)
		{
			text += ".";
		}

		return text;
	}

	void Start()
	{
		//load Scores from file
		Score.load();
		OnEnable();
	}


	void OnEnable()
	{
		//decode and print score list
		var text = GetComponent<UnityEngine.UI.Text>();
		text.text = "Hi-Scores\n\n";
		for (int i = 0; i < System.Math.Min(Score.Scores.Length, Score.MaxStorange); i++)
		{
			var xScore = (Score.Scores[i] - Score.Scores[i] % 1000000) / 1000000;
			var text1 = (i + 1) + "º";
			var text2 = xScore + " " + decode(Score.Scores[i]) + "\n";
			text.text += text1 + dot(32 - text1.Length - text2.Length) + text2;

		}

	}
}
