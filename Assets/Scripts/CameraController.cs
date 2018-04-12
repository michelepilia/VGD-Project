using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {//MP
	

	public GameObject car; //Selezione oggetto a cui "attaccare" la telecamera
	Quaternion rotation; //Oggetto che controlla la rotazione della camera
	float x, y, z; //variabili che conterranno le tre componenti della rotazione

	void Start(){
		rotation = transform.rotation; //all'inizio del gioco la rotazione contiene il valore impostato su Unity
	}

	void FixedUpdate(){//Tentativo bloccare rotazione su uno degli assi (z), perché rotazione totale è troppo movimentata

		/*eulerAngles converte un elemento Quaternion nel corrispondente Vector3, di cui si può estrarre x, y, o z*/
		x=car.transform.rotation.eulerAngles.x; //Aggiorno x della camera insieme alla rotazione della macchina
		y=car.transform.rotation.eulerAngles.y; //Idem
		z=rotation.eulerAngles.z; //Mantengo fisso l'asse z


		/*Euler fa l'opposto, data una tripla (dunque un Vector3), la converte in Quaternion*/
		transform.rotation = Quaternion.Euler (x, y, z); //Aggiorno la rotazione della camera
	}
}