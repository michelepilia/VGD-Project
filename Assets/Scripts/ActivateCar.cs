using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//questo script serve ad attivare la macchina scelta in precedenza nel menu di selezione delle auto
public class ActivateCar : MonoBehaviour {

	//public Rigidbody rb;
	public float timePause = 1.4f;

	//si richiamano i GameObject delle auto per poter essere gestiti da script
	public GameObject FiatPunto;
	public GameObject FordFocus;
	public GameObject FordFocusSporca;
	public GameObject Pickup;
	public GameObject MitsubishiRally;
	public GameObject Peugeot206;
	public GameObject carInGame;
	public ArrayList arrayCars = new ArrayList();//le macchine vengono gestite e mostrate al giocatore attraverso l'utilizzo di un ArrayList
	string activateCar;
	public int level;/*viene incrementato al completamento di ogni livello. Poichè nel forest vengono gestiti 3 livelli, in questo caso va utilizzato
	per capire se la macchina vi riposizionata all'avvio della scena*/
	bool reposition;

	//public GameObject car = new GameObject();

	// Use this for initialization
	void Start () {

		reposition = false;

		level = PlayerPrefs.GetInt ("level");

		//all'avvio del livello, l'array delle auto viene popolato
		arrayCars.Add (FiatPunto);
		arrayCars.Add (FordFocus);
		arrayCars.Add (FordFocusSporca);
		arrayCars.Add (Pickup);
		arrayCars.Add (MitsubishiRally);
		arrayCars.Add (Peugeot206);

		//ci si assicura che all'avvio tutte le auto siano disabilitate
		for (int i = 0; i < arrayCars.Count; i++) {
			((GameObject)arrayCars [i]).SetActive (false);
		}

		activateCar = PlayerPrefs.GetString("selectedCar");//attraverso il PlayerPrefs ci si recupera il nome dell'auto scelta in precedenza
		AudioListener.pause = false;

	}

	// Update is called once per frame
	void Update () {

		//attraverso un for si scorre l'array delle auto e viene abilitata quella col nome uguale a quello salvato in activateCar
		for (int i = 0; i < arrayCars.Count; i++) {
			if (((GameObject)arrayCars [i]).name.ToString ().Equals (activateCar)) {
				((GameObject)arrayCars [i]).SetActive (true);
				carInGame = ((GameObject)arrayCars [i]);
				break;
			}

		}

		//se il livello da eseguire all'avvio della scena è il terzo, la macchina viene riposizionata
		switch (level) {
		case 3:
			if(reposition == false){
				reposition = true;
				RepositionForest02 ();
			}
			break;
		}

	}



	void RepositionForest02() {
		//rb.velocity = new  Vector3(0, 0, 0);
		//yield return new WaitForSeconds (timePause);
		carInGame.transform.position = new Vector3(3568.922f, 3.2f, 1612.259f); //1537, 0, 348
		carInGame.transform.rotation = Quaternion.Euler (0.0f, -54.658f, 0.0f);
		Debug.Log ("riposizionato");
	}
}
