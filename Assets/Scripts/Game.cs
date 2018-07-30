using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	public GameObject Ship;
	float ReadTime;
// Revive player
	public void ReviveShip()
	{
        ReadTime = 1;
	}
	void Update()
	{
		//Whait for revive player
		if (ReadTime > 0)
		{
			ReadTime -= Time.deltaTime;
			if (ReadTime <= 0)
			{
				Ship.SetActive(true);
				Ship.GetComponent<Ship>().Start();
			}
		}
	}
}
