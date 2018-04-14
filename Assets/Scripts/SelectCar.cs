using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCar : MonoBehaviour {

	public GameObject FiatPunto;
	public GameObject FordFocus;
	public GameObject FordFocusSporca;
	public GameObject Pickup;
	public GameObject MitsubishiRally;
	public int nCar = 5;
	//public int click = 0;

	public ArrayList arrayCars = new ArrayList();

	// Use this for initialization
	void Start () {
		arrayCars.Add (FiatPunto);
		arrayCars.Add (FordFocus);
		arrayCars.Add (FordFocusSporca);
		arrayCars.Add (Pickup);
		arrayCars.Add (MitsubishiRally);

		for (int i = 0; i < arrayCars.Count; i++) {
			if (i == 0) {
				((GameObject)arrayCars [i]).SetActive (true);
			}
			else{
				((GameObject) arrayCars[i]).SetActive(false);
			}
		
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LeftButton()
	{
		for (int i = 0; i < arrayCars.Count; i++) {
			if (((GameObject)arrayCars [i]).activeSelf) {
				((GameObject)arrayCars [i]).SetActive (false);
				//Debug.Log (i);
				if (i == 0) {
					((GameObject)arrayCars [i - 1 + nCar]).SetActive (true);
				} else {
					((GameObject)arrayCars [i - 1]).SetActive (true);
				}
				break;
			}
		}
	}

	public void RightButton()
	{
		for (int i = 0; i < arrayCars.Count; i++) {
			if (((GameObject)arrayCars [i]).activeSelf) {
				((GameObject)arrayCars [i]).SetActive (false);
				//Debug.Log ((i) /*% nCar*/);
				((GameObject)arrayCars [(i + 1) % nCar]).SetActive (true);
				break;
			}
		}

	}
}
