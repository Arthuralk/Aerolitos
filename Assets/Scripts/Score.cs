using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Score : MonoBehaviour
{
	public static double[] Scores = { };
	//Current game Score
	public static int points
	{
		get
		{
			return m_points;
		}
		set
		{
			m_points = value;
			//add a life by n points
			if (m_points / 1000 > Life)
			{
				Life += 1;
				lifeUp();
			}
			if (m_points == 0)
			{
				Life = 0;
			};
		}
	}
	static int m_points; 
	public static double Hi;
	public static int MaxStorange = 20;
	static string Filename = "Hiscores.data";
	static int Life;
	static void lifeUp()
	{
		var lifeUp = Instantiate
		(
			UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/LifeUp.prefab"),
			new Vector3(1000, 0, 0),
			new Quaternion(0, 0, 0, 0)
		);
		lifeUp.GetComponent<AudioSource>().Play();
        Destroy(lifeUp, 1);
		Ship.Life += 1;
	}
	//return if current score is elegible to ranking
	public static bool isRecord()
	{
		if (Scores.Length < MaxStorange)
		{
			return true;
		}
		return points > Scores[Scores.Length-1]/1000000;
		}
	//Load file whith ranking list
	public static void load()
	{
		if (System.IO.File.Exists(Filename))
		{
			var file = System.IO.File.OpenText(Filename);
			var text = file.ReadLine();
			file.Close();
			var Scores1 = text.Split(';');
			var Scores2 = new double[Mathf.Min(Scores1.Length - 1, MaxStorange)];
			for (int i = 0; i < Scores2.Length; i++)
			{
				double Out1;
				double.TryParse(Scores1[i].Replace(";", ""), out Out1);
				Scores2[i] = Out1;
			}
			Scores = Scores2;
			Hi = (Scores[0] - Scores[0] % 1000000) / 1000000;
		}
		else Scores = new double[3];
	}
	//Save Scores[] in a file
	static void save()
	{
		var Text = "";
		for (int i = 0; i < Scores.Length; i++)
		{
			Text += Scores[i] + ";";

		}
		System.IO.File.WriteAllText(Filename, Text);

	}
	//Add points in score and sort
	static public void add(double pt)
	{
		load();
		var Scores1 = new double[Scores.Length + 1];
		Scores.CopyTo(Scores1, 0);
		Scores1[Scores.Length] = pt;
		Scores = Scores1;
		System.Array.Sort(Scores);
		System.Array.Reverse(Scores);
		Hi = (Scores[0] - Scores[0] % 1000000) / 1000000;
		save();
	}


}
