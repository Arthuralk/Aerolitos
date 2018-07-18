using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeText : MonoBehaviour
{
	public Texture Tex;
	// Use this for initialization
	void Start()
	{
		GetComponent<UnityEngine.UI.Text>().text = " Life";
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnGUI()
	{
		for (int i = 0; i < Ship.Life; i++)
		{
			GUI.DrawTexture(new Rect(20 + 40 * i, Screen.height - 40, Tex.width, Tex.height), Tex);
		}
	}
}
