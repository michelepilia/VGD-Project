using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*Questo script è basato su quello utilizzato per gestire i checkpoint del Desert. E' leggermente più complesso in quanto nel Forest vengono gestiti 3 diversi livelli*/

public class CheckpointForest : MonoBehaviour {

	int level;

	public Point coordinates;
	public GameObject carInGame;
	public Rigidbody rb;

	//i checkpoints da 1 a 7 riguardano il livello 2 (la prima parte del forest)
	public MeshRenderer Checkpoint01;
	public MeshRenderer Checkpoint02;
	public MeshRenderer Checkpoint03;
	public MeshRenderer Checkpoint04;
	public MeshRenderer Checkpoint05;
	public MeshRenderer Checkpoint06;

	//i checkpoints da 7 a 9 riguardano il livello 3 (seconda parte del forest)
	public MeshRenderer Checkpoint07;
	public MeshRenderer Checkpoint08;
	public MeshRenderer Checkpoint09;


	public int totCheckpoints;
	public int passedCheckpoints;

	public Text NumberOfCheckpoints;

	public bool checkTimeBonus01 = false;
	public bool checkTimeBonus02 = false;
	public bool checkTimeBonus03 = false;
	public bool checkTimeBonus04 = false;
	public bool checkTimeBonus05 = false;
	public bool checkTimeBonus06 = false;

	public bool checkTimeBonus07 = false;
	public bool checkTimeBonus08 = false;
	public bool checkTimeBonus09 = false;


	void Start(){

		level = PlayerPrefs.GetInt ("level");//attraverso il PlayerPrefs ci si recupera il livello che si vuole gestire

		rb = GetComponent<Rigidbody>();
		coordinates = new Point ();
		carInGame = GameObject.FindGameObjectWithTag ("Car");

		switch (level) {
		case 2:
			totCheckpoints = 6;
			passedCheckpoints = 0;

			NumberOfCheckpoints.text = (passedCheckpoints + "/" + totCheckpoints);

			checkTimeBonus01 = true;

			Checkpoint01.enabled = true;
			Checkpoint02.enabled = false;
			Checkpoint03.enabled = false;
			Checkpoint04.enabled = false;
			Checkpoint05.enabled = false;
			Checkpoint06.enabled = false;
			Checkpoint07.enabled = false;
			Checkpoint08.enabled = false;
			Checkpoint09.enabled = false;

			Checkpoint01.tag = "active_checkpoint";

			coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
			coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
			coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);

			break;
		case 3:
			totCheckpoints = 3;
			passedCheckpoints = 0;

			NumberOfCheckpoints.text = (passedCheckpoints + "/" + totCheckpoints);

			checkTimeBonus07 = true;

			Checkpoint01.enabled = false;
			Checkpoint02.enabled = false;
			Checkpoint03.enabled = false;
			Checkpoint04.enabled = false;
			Checkpoint05.enabled = false;
			Checkpoint06.enabled = false;

			Checkpoint07.enabled = true;
			Checkpoint08.enabled = false;
			Checkpoint09.enabled = false;

			Checkpoint07.tag = "active_checkpoint";

			coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
			coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
			coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);

			break;
		}



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
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest");
				checkTimeBonus01 = false;
				checkTimeBonus02 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
				coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);
			}
			break;
		case "Checkpoint02":
			if (checkTimeBonus02 == true) {
				Checkpoint02.tag = "Untagged";
				Checkpoint03.tag = "active_checkpoint";
				Checkpoint02.enabled = false;
				Checkpoint03.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest");
				checkTimeBonus02 = false;
				checkTimeBonus03 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
				coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);
			}
			break;
		case "Checkpoint03":
			if (checkTimeBonus03 == true) {
				Checkpoint03.tag = "Untagged";
				Checkpoint04.tag = "active_checkpoint";
				Checkpoint03.enabled = false;
				Checkpoint04.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest");
				checkTimeBonus03 = false;
				checkTimeBonus04 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
				coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);
			}
			break;
		case "Checkpoint04":
			if (checkTimeBonus04 == true) {
				Checkpoint04.tag = "Untagged";
				Checkpoint05.tag = "active_checkpoint";
				Checkpoint04.enabled = false;
				Checkpoint05.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest");
				checkTimeBonus04 = false;
				checkTimeBonus05 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
				coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);
			}
			break;
		case "Checkpoint05":
			if (checkTimeBonus05 == true) {
				Checkpoint05.tag = "Untagged";
				Checkpoint06.tag = "active_checkpoint";
				Checkpoint05.enabled = false;
				Checkpoint06.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest");
				checkTimeBonus05 = false;
				checkTimeBonus06 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
				coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);
			}
			break;
		case "Checkpoint06":
			if (checkTimeBonus06 == true) {
				Checkpoint06.enabled = false;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest");
				checkTimeBonus06 = false;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
			}
			break;
		case "Checkpoint07":
			if (checkTimeBonus07 == true) {
				Checkpoint07.tag = "Untagged";
				Checkpoint08.tag = "active_checkpoint";
				Checkpoint07.enabled = false;
				Checkpoint08.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest");
				checkTimeBonus07 = false;
				checkTimeBonus08 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
				coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);
			}
			break;
		case "Checkpoint08":
			if (checkTimeBonus08 == true) {
				Checkpoint08.tag = "Untagged";
				Checkpoint09.tag = "active_checkpoint";
				Checkpoint08.enabled = false;
				Checkpoint09.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest");
				checkTimeBonus08 = false;
				checkTimeBonus09 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
				coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);
			}
			break;
		case "Checkpoint09":
			if (checkTimeBonus09 == true) {
				Checkpoint09.enabled = false;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeForest");
				checkTimeBonus09 = false;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
			}
			break;
		}
	}


	void RepositionForestCheckpoint() {
		rb.velocity = new  Vector3(0, 0, 0);
		carInGame.transform.position = new Vector3(coordinates.GetX(), coordinates.GetY(), coordinates.GetZ()); //1537, 0, 348
		carInGame.SendMessage("updateTimeByRepositionForest");
		//carInGame.transform.rotation = Quaternion.Euler (0.0f, -54.658f, 0.0f);
		Debug.Log ("riposizionato");
	}
}
