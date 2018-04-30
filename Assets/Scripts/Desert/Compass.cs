using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

	public Vector3 NorthDirection; //Direzione del nord
	public Transform Player; //Macchina
	public Quaternion MissionDirection; //Direzione checkpoint

	public RectTransform MissionLayer; //Ago bussola

	public Transform missionplace; //Poizione checkpoint

	// Use this for initialization
	void Start () {
		missionplace = GameObject.Find ("Checkpoint01").transform; //Individua la posizione del primo checkpoint
	}
	
	// Update is called once per frame
	void Update () {
		missionplace = GameObject.FindWithTag ("active_checkpoint").transform; //Individua posizione del checkpoint attivo
		ChangeNorthDirection (); //Aggiorna il nord
		ChangeMissionDirection(); //Aggiorna la direzione verso il checkpoint
		
	}



	void ChangeNorthDirection () {
		NorthDirection.z = Player.eulerAngles.y; //Direzione "Nord" = rotazione del giocatore sull'asse y
	
	}


	void ChangeMissionDirection() {
		Vector3 dir = transform.position - missionplace.position; //direzione corrisponde a posizione relativa alla camera


		MissionDirection = Quaternion.LookRotation (dir); //Aggiorna direzione checkpoint in base a calcolo precedente

		MissionDirection.z = -MissionDirection.y; //modifica posizioni rotazione direzione sugli assi appropriati
		MissionDirection.y = 0;
		MissionDirection.x = 0;

		MissionLayer.localRotation = MissionDirection * Quaternion.Euler (NorthDirection); //Aggiorna rotazione ago in relazione a posizione checkpoint e nord   
	}
}
