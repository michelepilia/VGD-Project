using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CheckpointDesert : MonoBehaviour {

	public Point coordinates; //variabile di tipo Point, classe creata per poter acquisire le coordinate della macchina
	public GameObject carInGame;
	public Rigidbody rb;
	//int actualTime;

	//si richiamano le Mesh dei checkpoint per poterli gestire da script
	public MeshRenderer Checkpoint01;
	public MeshRenderer Checkpoint02;
	public MeshRenderer Checkpoint03;
	public MeshRenderer Checkpoint04;
	public MeshRenderer Checkpoint05;
	public MeshRenderer Checkpoint06;
	public MeshRenderer Checkpoint07;

	public int totCheckpoints = 7;
	public int passedCheckpoints = 0;

	public Text NumberOfCheckpoints; //utilizzato per mostrare nell'interfaccia di gioco i checkpoint superati

	//i checkTimeBonus servono per attivare i bonus in secondi a ogni chekpoint superato
	public bool checkTimeBonus01 = true;
	public bool checkTimeBonus02 = false;
	public bool checkTimeBonus03 = false;
	public bool checkTimeBonus04 = false;
	public bool checkTimeBonus05 = false;
	public bool checkTimeBonus06 = false;
	public bool checkTimeBonus07 = false;



	void Start(){

		rb = GetComponent<Rigidbody>();
		coordinates = new Point ();
		carInGame = GameObject.FindGameObjectWithTag ("Car");

		NumberOfCheckpoints.text = (passedCheckpoints + "/" + totCheckpoints);

		Checkpoint01.tag = "active_checkpoint";//utilizzato per dare un riferimento alla bussola per puntare il prossimo checkpoint

		//all'avvio, tutti i checkpoint eccetto il primo vengono disattivati
		Checkpoint02.enabled = false;
		Checkpoint03.enabled = false;
		Checkpoint04.enabled = false;
		Checkpoint05.enabled = false;
		Checkpoint06.enabled = false;
		Checkpoint07.enabled = false;

		//all'avvio vengono salvate le coordinate iniziali della macchina per poter essere riposizionata "manualmente" dal giocatore
		coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
		coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
		coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);

	}

	void Update(){

		NumberOfCheckpoints.text = (passedCheckpoints + "/" + totCheckpoints);

		//al raggiungimento dell'ultimo checkpoint, il numero di questi ultimi verrà mostrato nell'interfaccia di gioco di colore verde
		if(passedCheckpoints == totCheckpoints){
			NumberOfCheckpoints.color = Color.green;
		}
	}

	//dentro questo metodo avviene la gestione dei checkpoint: appena uno viene colpito si disattiva e viene subito attivato il successivo
	private void OnTriggerEnter(Collider collider)
	{
		switch (collider.gameObject.name) {
		case "Checkpoint01":
			if (checkTimeBonus01 == true) {
				Checkpoint01.tag = "Untagged";
				Checkpoint02.tag = "active_checkpoint";
				Checkpoint01.enabled = false;
				Checkpoint02.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTime");//questo script "comunica" con quello del timer, lanciando il metodo del timer "updateTime" che aggiunge i secondi bonus ottenuti dal checkpoint
				checkTimeBonus01 = false;
				checkTimeBonus02 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);//a ogni chekpoint vengono memorizzate le coordinate attuali della macchina
				coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);
				//actualTime = PlayerPrefs.GetInt ("actualTime");

				//Debug.Log (coordinates.GetX () + " " + coordinates.GetY () + " " + coordinates.GetZ ());
			}
				break;
		case "Checkpoint02":
			if (checkTimeBonus02 == true) {
				Checkpoint02.tag = "Untagged";
				Checkpoint03.tag = "active_checkpoint";
				Checkpoint02.enabled = false;
				Checkpoint03.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTime");
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
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTime");
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
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTime");
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
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTime");
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
				Checkpoint06.tag = "Untagged";
				Checkpoint07.tag = "active_checkpoint";
				Checkpoint06.enabled = false;
				Checkpoint07.enabled = true;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTime");
				checkTimeBonus06 = false;
				checkTimeBonus07 = true;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
				coordinates.SetX(GameObject.FindGameObjectWithTag ("Car").transform.position.x);
				coordinates.SetY(GameObject.FindGameObjectWithTag ("Car").transform.position.y);
				coordinates.SetZ(GameObject.FindGameObjectWithTag ("Car").transform.position.z);
			}
				break;
			case "Checkpoint07":
			if (checkTimeBonus07 == true) {
				Checkpoint07.enabled = false;
				GameObject.FindGameObjectWithTag("Car").SendMessage("updateTime");
				checkTimeBonus07 = false;
				Debug.Log (collider.gameObject.name);
				passedCheckpoints++;
			}
				break;
		}
	}

	/*questo metodo viene lanciato dallo script "ToTheLastCheckpoint", non appena il giocatore preme la barra spaziatrice:
	  la velocità della macchina viene riportata a 0, e la macchina viene riposizionata alle coordinate dell'ultimo checkpoint.
	  Inoltre, viene lanciato un metodo dello script del timer "updateTimeByReposition", che tiporta il tempo a disposizione a quello
	  che era al momento del superamento del precedente checkpoint*/
	void RepositionDesertCheckpoint() {
		rb.velocity = new  Vector3(0, 0, 0);
		carInGame.transform.position = new Vector3(coordinates.GetX(), coordinates.GetY(), coordinates.GetZ()); //1537, 0, 348
		carInGame.SendMessage("updateTimeByReposition");
		//carInGame.transform.rotation = Quaternion.Euler (0.0f, -54.658f, 0.0f);
		Debug.Log ("riposizionato");
	}
		
}
