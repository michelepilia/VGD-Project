using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//script che gestisce la selezione delle auto nella scena che viene lanciata prima di ogni livello: SelectCar
public class SelectCar : MonoBehaviour {

	public GameObject FiatPunto;
	public GameObject FordFocus;
	public GameObject FordFocusSporca;
	public GameObject Pickup;
	public GameObject MitsubishiRally;
	public GameObject Peugeot206;
	public Text CarName;
	public string selectedCar;
	public int level;

	//anche in questo script, le auto vengono gestite attraverso un ArrayList
	public ArrayList arrayCars = new ArrayList();

	// Use this for initialization
	void Start () {
		AudioListener.pause = false;
		level = PlayerPrefs.GetInt ("level");

		//al completamento di ogni livello vengono sbloccate delle auto. In base al livello a cui si è arrivati, vengono rese disponibili determinate auto
		switch (level) {
		case 1:
			arrayCars.Add (FiatPunto);
			arrayCars.Add (Peugeot206);
			break;
		case 2:
			arrayCars.Add (FiatPunto);
			arrayCars.Add (Peugeot206);
			arrayCars.Add (Pickup);
			break;
		case 3:
			arrayCars.Add (FiatPunto);
			arrayCars.Add (Peugeot206);
			arrayCars.Add (Pickup);
			arrayCars.Add (FordFocusSporca);
			break;
		case 4:
			arrayCars.Add (FiatPunto);
			arrayCars.Add (Peugeot206);
			arrayCars.Add (Pickup);
			arrayCars.Add (FordFocusSporca);
			arrayCars.Add (FordFocus);
			break;
		}

		//attraverso questo for si fa in modo di avere una sola auto abilitata all'avvio della scena
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

		//questo for serve a visualizzare in modo corretto il nome di ogni auto nell'interfaccia utente
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
				case "Peugeot206":
					CarName.text = "Peugeot 206";
					break;
				}
			}
		}
		
	}




	/*Nella scena viene mostrata la macchina al centro, 2 bottoni ai suoi lati per scorrere le auto, e un bottone sotto di essa per scegliere di utilizzare
	  la macchina mostrata*/
	public void LeftButton()
	{
		//questo for non fa altro che disabilitare la macchina mostrata e abilitare la macchina precedente quando il bottone viene premuto
		for (int i = 0; i < arrayCars.Count; i++) {
			if (((GameObject)arrayCars [i]).activeSelf) {
				((GameObject)arrayCars [i]).SetActive (false);
				//Debug.Log (i);
				if (i == 0) {
					((GameObject)arrayCars [i - 1 + arrayCars.Count]).SetActive (true);
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
				((GameObject)arrayCars [(i + 1) % arrayCars.Count]).SetActive (true);
				break;
			}
		}

	}

	public void SelectCarButton()
	{
		//in questo for ci si salva il nome della macchina attiva al momento in cui si è premuto sul bottone
		for (int i = 0; i < arrayCars.Count; i++) {
			if(((GameObject)arrayCars [i]).activeSelf)
			{
				selectedCar = ((GameObject)arrayCars [i]).name.ToString ();
			}
		}

		//col PlayerPrefs ci si salva il nome della macchina che andrà poi attivata nella scena succesiva
		PlayerPrefs.SetString("selectedCar", selectedCar);

		/*poichè a quasta scena ci si arriva prima dell'avvio di ogni livello, ci si assicura che, una volta scelta la macchina,
		  si venga rimandati alla scena giusta*/
		switch (level) {
		case 1:
			SceneManager.LoadScene ("Desert");
			break;
		case 2:
			SceneManager.LoadScene ("Forest");
			break;
		case 3:
			SceneManager.LoadScene ("Forest");
			break;
		case 4:
			SceneManager.LoadScene ("Forest");
			break;
		}
	}
		


}
