using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivateCar : MonoBehaviour {

	public GameObject FiatPunto;
	public GameObject FordFocus;
	public GameObject FordFocusSporca;
	public GameObject Pickup;
	public GameObject MitsubishiRally;
	public ArrayList arrayCars = new ArrayList();
	string activateCar;
	//public GameObject car = new GameObject();

	// Use this for initialization
	void Start () {

		arrayCars.Add (FiatPunto);
		arrayCars.Add (FordFocus);
		arrayCars.Add (FordFocusSporca);
		arrayCars.Add (Pickup);
		arrayCars.Add (MitsubishiRally);

		for (int i = 0; i < arrayCars.Count; i++) {
				((GameObject)arrayCars [i]).SetActive (false);
		}

		activateCar = PlayerPrefs.GetString("selectedCar");


		/*for (int i = 0; i < arrayCars.Count; i++) {
			if (((GameObject)arrayCars [i]).name.ToString ().Equals (activateCar)) {
				((GameObject)arrayCars [i]).SetActive (true);
				break;
			}

		}*/
	}

	// Update is called once per frame
	void Update () {

		for (int i = 0; i < arrayCars.Count; i++) {
			if (((GameObject)arrayCars [i]).name.ToString ().Equals (activateCar)) {
				((GameObject)arrayCars [i]).SetActive (true);
				break;
			}

		}

	}
}
