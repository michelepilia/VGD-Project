using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCar : MonoBehaviour {

	public GameObject FiatPunto;
	public GameObject FordFocus;
	public GameObject FordFocusSporca;
	public GameObject Pickup;
	public GameObject MitsubishiRally;
	public Text CarName;
	public int nCar = 5;
	public string selectedCar;
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
		for (int i = 0; i < arrayCars.Count; i++) {
			if(((GameObject)arrayCars [i]).activeSelf)
			{
				//CarName.text = ((GameObject)arrayCars [i]).name;

				switch (((GameObject)arrayCars [i]).name) {
				case "FiatPunto":
					CarName.text = "Fiat Punto";
						break;
				case "FordFocus":
					CarName.text = "Ford Focus";
					break;
				case "FordFocusSporca":
					CarName.text = "Ford Focus (sporca)";
					break;
				case "Pickup":
					CarName.text = "Pickup";
					break;
				case "MitsubishiRally":
					CarName.text = "Mitsubishi Rally";
					break;
				}
			}
		}
		
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

	public void SelectCarButton()
	{
		for (int i = 0; i < arrayCars.Count; i++) {
			if(((GameObject)arrayCars [i]).activeSelf)
			{
				selectedCar = ((GameObject)arrayCars [i]).name.ToString ();
			}
		}
		//Awake ();
		PlayerPrefs.SetString("selectedCar", selectedCar);
		SceneManager.LoadScene ("Desert");
	}

	/*void Awake () {
		DontDestroyOnLoad (selectedCar);
	}*/


}
