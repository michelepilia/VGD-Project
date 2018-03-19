using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public MeshRenderer Checkpoint01;
	public MeshRenderer Checkpoint02;
	public MeshRenderer Checkpoint03;
	public MeshRenderer Checkpoint04;
	public MeshRenderer Checkpoint05;
	public MeshRenderer Checkpoint06;
	public MeshRenderer Checkpoint07;

	public bool checkTimeBonus01 = true;
	public bool checkTimeBonus02 = false;
	public bool checkTimeBonus03 = false;
	public bool checkTimeBonus04 = false;
	public bool checkTimeBonus05 = false;
	public bool checkTimeBonus06 = false;
	public bool checkTimeBonus07 = false;

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
		switch (collider.gameObject.name) {
		case "Checkpoint01":
			if (checkTimeBonus01 == true) {
				Checkpoint01.enabled = false;
				Checkpoint02.enabled = true;
				GameObject.Find ("Car").SendMessage ("updateTime");
				checkTimeBonus01 = false;
				checkTimeBonus02 = true;
				//Debug.Log (collider.gameObject.name);
			}
				break;
		case "Checkpoint02":
			if (checkTimeBonus02 == true) {
				Checkpoint02.enabled = false;
				Checkpoint03.enabled = true;
				GameObject.Find ("Car").SendMessage ("updateTime");
				checkTimeBonus02 = false;
				checkTimeBonus03 = true;
				Debug.Log (collider.gameObject.name);
			}
				break;
			case "Checkpoint03":
			if (checkTimeBonus03 == true) {
				Checkpoint03.enabled = false;
				Checkpoint04.enabled = true;
				GameObject.Find ("Car").SendMessage ("updateTime");
				checkTimeBonus03 = false;
				checkTimeBonus04 = true;
				Debug.Log (collider.gameObject.name);
			}
				break;
			case "Checkpoint04":
			if (checkTimeBonus04 == true) {
				Checkpoint04.enabled = false;
				Checkpoint05.enabled = true;
				GameObject.Find ("Car").SendMessage ("updateTime");
				checkTimeBonus04 = false;
				checkTimeBonus05 = true;
				Debug.Log (collider.gameObject.name);
			}
				break;
			case "Checkpoint05":
			if (checkTimeBonus05 == true) {
				Checkpoint05.enabled = false;
				Checkpoint06.enabled = true;
				GameObject.Find ("Car").SendMessage ("updateTime");
				checkTimeBonus05 = false;
				checkTimeBonus06 = true;
				Debug.Log (collider.gameObject.name);
			}
				break;
			case "Checkpoint06":
			if (checkTimeBonus06 == true) {
				Checkpoint06.enabled = false;
				Checkpoint07.enabled = true;
				GameObject.Find ("Car").SendMessage ("updateTime");
				checkTimeBonus06 = false;
				checkTimeBonus07 = true;
				Debug.Log (collider.gameObject.name);
			}
				break;
			case "Checkpoint07":
			if (checkTimeBonus07 == true) {
				Checkpoint07.enabled = false;
				GameObject.Find ("Car").SendMessage ("updateTime");
				checkTimeBonus07 = false;
				Debug.Log (collider.gameObject.name);
			}
				break;
		}
	}
		
}
