using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject smoke;
	void OnDisable()
	{
		smoke = Smoke.Instantiate(smoke);
		smoke.GetComponent<Smoke>().frame = 0;
		smoke.transform.position = transform.position + transform.up / 2;
		smoke.GetComponent<Smoke>().Type = 2;


	}
	void Update()
	{
		transform.position += transform.up * Time.deltaTime * 10;
		transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * 2;
	}
}
