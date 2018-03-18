using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public MeshRenderer Checkpoint01;

	private void OnTriggerEnter(Collider other)
	{
		GameObject.Find ("Car").SendMessage ("updateTime");
		Checkpoint01.enabled = false;
	}
}
