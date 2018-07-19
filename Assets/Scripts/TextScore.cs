using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScore : MonoBehaviour
{


	void Start()
	{
		Score.load();
		printText();
	}
	void printText()
	{
		GetComponent<UnityEngine.UI.Text>().text = "Hi-Score: " +
				Mathf.Max(Mathf.Floor(System.Convert.ToInt64(Score.Hi)), Score.points) + "\n" +
				" Score: " +
				Score.points;
	}

	void FixedUpdate()
	{
		//print score and hi score
		if (Score.view)
		{
			Score.view = false;
			printText();
		}
	}
}
