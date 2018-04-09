using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarInWater : MonoBehaviour {

	public Rigidbody Car;

	private void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.name == "WaterProNighttime")
		{
			Car.drag = 5;
			Debug.Log (collider.gameObject.name);
		}
	}
}
