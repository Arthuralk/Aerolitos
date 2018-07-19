using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is for manage pool partys
public class Pool
{
	public GameObject Prefab;
	public GameObject[] List;
	public int Cur;
	public int Cur1;
	//Class constructor
	public Pool(GameObject _Prefab, int _size)
	{
		Prefab = _Prefab;
		List = new GameObject[_size];
	}
	//find a free object to send for work, or instanciate one, if pool is full, send any one
	public GameObject Instantiate()
	{
		Cur++;
		if (Cur >= List.Length)
		{
			Cur = 0;
		}

		for (int i = 0; i < List.Length; i++)
		{
			if (List[i] != null)
			{
				if (List[i].activeSelf == false)
				{
					Cur1 = i;
					break;
				}
			}
			Cur1 = Cur;
		}

		if (List[Cur1] != null)
		{
			List[Cur1].SetActive(false);
			List[Cur1].SetActive(true);
		}
		else
		{
			List[Cur1] = Object.Instantiate(Prefab);
		}
		List[Cur1].name = Prefab.name + Cur1.ToString("D3");
		return List[Cur1];
	}
	//Clear the pool
	public void clear()
	{
		for (int i = 0; i < List.Length; i++)
		{
			try
			{
				Object.Destroy(List[i]);
				List[i] = null;
			}
			catch (System.Exception)
			{
				List[i] = null;
			}
		}
	}

}
