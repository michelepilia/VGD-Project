using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point{
	private float x;
	private float y;
	private float z;

	public Point()
	{
		
	}


	//getter
	public float GetX()
	{
		return x;
	}

	public float GetY()
	{
		return y;
	}

	public float GetZ()
	{
		return z;
	}


	//setter
	public void SetX(float newX)
	{
		x = newX;
	}

	public void SetY(float newY)
	{
		y = newY;
	}

	public void SetZ(float newZ)
	{
		z = newZ;
	}
}
