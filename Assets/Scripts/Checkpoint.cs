using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public MeshRenderer Checkpoint01;
	public MeshRenderer Checkpoint02;
	public MeshRenderer Checkpoint03;
	public MeshRenderer Checkpoint04;
	public MeshRenderer Checkpoint05;
	public MeshRenderer Checkpoint06;
	public MeshRenderer Checkpoint07;

	void Start(){
		Checkpoint02.enabled = false;
		Checkpoint03.enabled = false;
		Checkpoint04.enabled = false;
		Checkpoint05.enabled = false;
		Checkpoint06.enabled = false;
		Checkpoint07.enabled = false;
	}

	private void OnTriggerEnter(Collider collider)
	{
		GameObject.Find ("Car").SendMessage ("updateTime");
		switch (collider.gameObject.name) {
			case "Checkpoint01":
				Checkpoint01.enabled = false;
				Checkpoint02.enabled = true;
				Debug.Log (collider.gameObject.name);
				break;
			case "Checkpoint02":
				Checkpoint02.enabled = false;
				Checkpoint03.enabled = true;
				Debug.Log (collider.gameObject.name);
				break;
			case "Checkpoint03":
				Checkpoint03.enabled = false;
				Checkpoint04.enabled = true;
				Debug.Log (collider.gameObject.name);
				break;
			case "Checkpoint04":
				Checkpoint04.enabled = false;
				Checkpoint05.enabled = true;
				Debug.Log (collider.gameObject.name);
				break;
			case "Checkpoint05":
				Checkpoint05.enabled = false;
				Checkpoint06.enabled = true;
				Debug.Log (collider.gameObject.name);
				break;
			case "Checkpoint06":
				Checkpoint06.enabled = false;
				Checkpoint07.enabled = true;
				Debug.Log (collider.gameObject.name);
				break;
			case "Checkpoint07":
				Checkpoint07.enabled = false;
				Debug.Log (collider.gameObject.name);
				break;
		}
	}
		
}
