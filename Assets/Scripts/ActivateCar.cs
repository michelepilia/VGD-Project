using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivateCar : MonoBehaviour {

	//public Rigidbody rb;
	public float timePause = 1.4f;

	public GameObject FiatPunto;
	public GameObject FordFocus;
	public GameObject FordFocusSporca;
	public GameObject Pickup;
	public GameObject MitsubishiRally;
	public GameObject Peugeot206;
	public GameObject carInGame;
	public ArrayList arrayCars = new ArrayList();
	string activateCar;
	public int level;
	bool reposition;

	//public GameObject car = new GameObject();

	// Use this for initialization
	void Start () {

		reposition = false;

		level = PlayerPrefs.GetInt ("level");

		arrayCars.Add (FiatPunto);
		arrayCars.Add (FordFocus);
		arrayCars.Add (FordFocusSporca);
		arrayCars.Add (Pickup);
		arrayCars.Add (MitsubishiRally);
		arrayCars.Add (Peugeot206);

		for (int i = 0; i < arrayCars.Count; i++) {
			((GameObject)arrayCars [i]).SetActive (false);
		}

		activateCar = PlayerPrefs.GetString("selectedCar");
		AudioListener.pause = false;

	}

	// Update is called once per frame
	void Update () {

		for (int i = 0; i < arrayCars.Count; i++) {
			if (((GameObject)arrayCars [i]).name.ToString ().Equals (activateCar)) {
				((GameObject)arrayCars [i]).SetActive (true);
				carInGame = ((GameObject)arrayCars [i]);
				break;
			}

		}

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
