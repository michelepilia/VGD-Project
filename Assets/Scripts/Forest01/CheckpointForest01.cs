using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CheckpointForest01 : MonoBehaviour {

	public MeshRenderer Checkpoint01;
	public MeshRenderer Checkpoint02;
	public MeshRenderer Checkpoint03;
	public MeshRenderer Checkpoint04;
	public MeshRenderer Checkpoint05;
	public MeshRenderer Checkpoint06;

	public int totCheckpoints;
	public int passedCheckpoints;

	public Text NumberOfCheckpoints;

	public bool checkTimeBonus01 = true;
	public bool checkTimeBonus02 = false;
	public bool checkTimeBonus03 = false;
	public bool checkTimeBonus04 = false;
	public bool checkTimeBonus05 = false;
	public bool checkTimeBonus06 = false;

	void Start(){

		totCheckpoints = 6;
		passedCheckpoints = 0;

		NumberOfCheckpoints.text = (passedCheckpoints + "/" + totCheckpoints);

		Checkpoint01.tag = "active_checkpoint";

		Checkpoint02.enabled = false;
		Checkpoint03.enabled = false;
		Checkpoint04.enabled = false;
		Checkpoint05.enabled = false;
		Checkpoint06.enabled = false;

	}

	void Update(){

		NumberOfCheckpoints.text = (passedCheckpoints + "/" + totCheckpoints);

		if(passedCheckpoints == totCheckpoints){
			NumberOfCheckpoints.color = Color.green;
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		switch (collider.gameObject.name) {
		case "Checkpoint01":
			if (checkTimeBonus01 == true) {
				Checkpoint01.tag = "Untagged";
				Checkpoint02.tag = "active_checkpoint";
				Checkpoint01.enabled = false;
				Checkpoint02.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest01");
				checkTimeBonus01 = false;
				checkTimeBonus02 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
			}
			break;
		case "Checkpoint02":
			if (checkTimeBonus02 == true) {
				Checkpoint02.tag = "Untagged";
				Checkpoint03.tag = "active_checkpoint";
				Checkpoint02.enabled = false;
				Checkpoint03.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest01");
				checkTimeBonus02 = false;
				checkTimeBonus03 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
			}
			break;
		case "Checkpoint03":
			if (checkTimeBonus03 == true) {
				Checkpoint03.tag = "Untagged";
				Checkpoint04.tag = "active_checkpoint";
				Checkpoint03.enabled = false;
				Checkpoint04.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest01");
				checkTimeBonus03 = false;
				checkTimeBonus04 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
			}
			break;
		case "Checkpoint04":
			if (checkTimeBonus04 == true) {
				Checkpoint04.tag = "Untagged";
				Checkpoint05.tag = "active_checkpoint";
				Checkpoint04.enabled = false;
				Checkpoint05.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest01");
				checkTimeBonus04 = false;
				checkTimeBonus05 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
			}
			break;
		case "Checkpoint05":
			if (checkTimeBonus05 == true) {
				Checkpoint05.tag = "Untagged";
				Checkpoint06.tag = "active_checkpoint";
				Checkpoint05.enabled = false;
				Checkpoint06.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest01");
				checkTimeBonus05 = false;
				checkTimeBonus06 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
			}
			break;
		case "Checkpoint06":
			if (checkTimeBonus06 == true) {
				Checkpoint06.enabled = false;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest01");
				checkTimeBonus06 = false;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
			}
			break;
		}
	}
}
