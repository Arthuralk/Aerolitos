using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Is a Input abstration
public class GamePad : MonoBehaviour
{
	static bool BtnA;
	static bool BtnB;
	static bool BtnUp;
	static bool BtnDown;
	static bool BtnLeft;
	static bool BtnRight;

	static int boolToint(bool _val)
	{
		if (_val)
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}

	public static float X
	{
		get
		{
			return Mathf.Clamp(InputX() + boolToint(BtnRight) - boolToint(BtnLeft), -1, 1);
		}
	}
	public static float Y
	{
		get
		{
			return Mathf.Clamp(InputY() + boolToint(BtnUp) - boolToint(BtnDown), -1, 1);
		}
	}
	public static bool A
	{
		get
		{
			return InputA() || BtnA;
		}
	}
	public static bool B
	{
		get
		{
			return InputB() || BtnB;
		}
	}

	static float InputX()
	{
		return Input.GetAxis("Horizontal");
	}
	static float InputY()
	{
		return Input.GetAxis("Vertical");
	}
	static bool InputA()
	{
		if (Input.GetAxis("Submit") > 0)
		{
			return true;
		}
		return false;
	}
	static bool InputB()
	{
		if (Input.GetAxis("Cancel") > 0)
		{
			return true;
		}
		return false;	}

	public void Press(string _bt)
	{
		if (_bt == "A")
		{
			BtnA = true;
		}
		if (_bt == "B")
		{
			BtnB = true; ;
		}
		if (_bt == "Up")
		{
			BtnUp = true; ;
		}
		if (_bt == "Down")
		{
			BtnDown = true;
		}
		if (_bt == "Left")
		{
			BtnLeft = true;
		}
		if (_bt == "Right")
		{
			BtnRight = true; ;
		}
	}
	public void Release(string _bt)
	{
		if (_bt == "A")
		{
			BtnA = false;
		}
		if (_bt == "B")
		{
			BtnB = false;
		}
		if (_bt == "Up")
		{
			BtnUp = false;
		}
		if (_bt == "Down")
		{
			BtnDown = false;
		}
		if (_bt == "Left")
		{
			BtnLeft = false;
		}
		if (_bt == "Right")
		{
			BtnRight = false;
		}	}
	public static void reset()
	{
		BtnA = false;
		BtnB = false;
		BtnUp = false;
		BtnDown = false;
		BtnLeft = false;
		BtnRight = false;
	}

}