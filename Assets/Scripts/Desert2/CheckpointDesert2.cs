using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CheckpointDesert2 : MonoBehaviour {

	int level;

	public Point coordinates;
	public GameObject carInGame;
	public Rigidbody rb;

	public MeshRenderer Checkpoint01;
	public MeshRenderer Checkpoint02;
	public MeshRenderer Checkpoint03;
	public MeshRenderer Checkpoint04;
	public MeshRenderer Checkpoint05;
	public MeshRenderer Checkpoint06;

	public int totCheckpoints;
	public int passedCheckpoints;

	public Text NumberOfCheckpoints;

	public bool checkTimeBonus01;
	public bool checkTimeBonus02;
	public bool checkTimeBonus03;
	public bool checkTimeBonus04;
	public bool checkTimeBonus05;
	public bool checkTimeBonus06;


	void Start(){

		level = PlayerPrefs.GetInt ("level");//attraverso il PlayerPrefs ci si recupera il livello che si vuole gestire

		rb = GetComponent<Rigidbody>();
		coordinates = new Point ();
		carInGame = GameObject.FindGameObjectWithTag ("Car");

		checkTimeBonus01 = false;
		checkTimeBonus02 = false;
		checkTimeBonus03 = false;
		checkTimeBonus04 = false;
		checkTimeBonus05 = false;
		checkTimeBonus06 = false;

		switch (level) {
		case 5:
			totCheckpoints = 2;
			passedCheckpoints = 0;

			NumberOfCheckpoints.text = (passedCheckpoints + "/" + totCheckpoints);

			checkTimeBonus01 = true;

			Checkpoint01.enabled = true;
			Checkpoint02.enabled = false;
			Checkpoint03.enabled = false;
			Checkpoint04.enabled = false;
			Checkpoint05.enabled = false;
			Checkpoint06.enabled = false;

			Checkpoint01.tag = "active_checkpoint";

			coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
			coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
			coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);

			break;
		
		case 6:
			totCheckpoints = 4;
			passedCheckpoints = 0;

			NumberOfCheckpoints.text = (passedCheckpoints + "/" + totCheckpoints);

			checkTimeBonus03 = true;

			Checkpoint01.enabled = false;
			Checkpoint02.enabled = false;
			Checkpoint03.enabled = true;
			Checkpoint04.enabled = false;
			Checkpoint05.enabled = false;
			Checkpoint06.enabled = false;

			Checkpoint03.tag = "active_checkpoint";

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
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeDesert2");
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
				Checkpoint02.enabled = false;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeDesert2");
				checkTimeBonus02 = false;
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
				GameObject.FindGameObjectWithTag ("Car").SendMessage ("updateTimeDesert2");
				checkTimeBonus03 = false;
				checkTimeBonus04 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX (GameObject.FindGameObjectWithTag ("Car").transform.position.x);
				coordinates.SetY (GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ (GameObject.FindGameObjectWithTag ("Car").transform.position.z);
			}
			break;
		case "Checkpoint04":
			if (checkTimeBonus04 == true) {
				Checkpoint04.tag = "Untagged";
				Checkpoint05.tag = "active_checkpoint";
				Checkpoint04.enabled = false;
				Checkpoint05.enabled = true;
				GameObject.FindGameObjectWithTag ("Car").SendMessage ("updateTimeDesert2");
				checkTimeBonus04 = false;
				checkTimeBonus05 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX (GameObject.FindGameObjectWithTag ("Car").transform.position.x);
				coordinates.SetY (GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ (GameObject.FindGameObjectWithTag ("Car").transform.position.z);
			}
			break;
		case "Checkpoint05":
			if (checkTimeBonus05 == true) {
				Checkpoint05.tag = "Untagged";
				Checkpoint06.tag = "active_checkpoint";
				Checkpoint05.enabled = false;
				Checkpoint06.enabled = true;
				GameObject.FindGameObjectWithTag ("Car").SendMessage ("updateTimeDesert2");
				checkTimeBonus05 = false;
				checkTimeBonus06 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX (GameObject.FindGameObjectWithTag ("Car").transform.position.x);
				coordinates.SetY (GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ (GameObject.FindGameObjectWithTag ("Car").transform.position.z);
			}
			break;
		case "Checkpoint06":
			if (checkTimeBonus06 == true) {
				Checkpoint06.enabled = false;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTimeDesert2");
				checkTimeBonus06 = false;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
			}
			break;
		}
	}


	void RepositionDesert2Checkpoint() {
		rb.velocity = new  Vector3(0, 0, 0);
		carInGame.transform.position = new Vector3(coordinates.GetX(), coordinates.GetY(), coordinates.GetZ()); //1537, 0, 348
		carInGame.SendMessage("updateTimeByRepositionDesert2");
		//carInGame.transform.rotation = Quaternion.Euler (0.0f, -54.658f, 0.0f);
		Debug.Log ("riposizionato");
	}
}
