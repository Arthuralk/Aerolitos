using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScore : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		Score.load();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//print score and hi score
		GetComponent<UnityEngine.UI.Text>().text ="Hi-Score: " +
			Mathf.Max(Mathf.Floor(System.Convert.ToInt64(Score.Hi)), Score.points) + "\n" +
			" Score: " +
			Score.points;
	}
}
