using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaterCollider : MonoBehaviour {

	public GameObject GameOverMenu;
	public float timePause = 1.2f;
	//public enum Mode {Simple = 1, Hard = 2};
	//public Mode mode = Mode.Simple;
	public Rigidbody rb;
	public string difficulty;

	// Use this for initialization
	void Start () {
		difficulty = PlayerPrefs.GetString("gameDifficulty"); //Ricava la modalità di gioco
		rb = GetComponent<Rigidbody>(); 
	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter (Collider collider) { //All'inizio del contatto
		if (collider.gameObject.tag == "water") {//se il collider è l'acqua
			if (difficulty.Equals("easy")) {//se la modalità è facile..
				StartCoroutine ("Reposition");//..riposiziona
			} else if (difficulty.Equals("hard")) {//se difficile..
				rb.velocity = new  Vector3(0, 0, 0);//Ferma la macchina
				StartCoroutine ("GameOver");//GameOver
			}

		}
	}

	IEnumerator GameOver() {
		yield return new WaitForSeconds (timePause);
		GameOverMenu.SetActive (true);
		Time.timeScale = 0f;
		AudioListener.pause = true;

	}

	IEnumerator Reposition() {
		yield return new WaitForSeconds (0.2f);//Aspetta 2 decimi
		rb.velocity = new  Vector3(0, 0, 0); //Ferma la macchina
		yield return new WaitForSeconds (1.0f); //Aspetta 1 secondo
		GameObject.FindGameObjectWithTag("Car").SendMessage("RepositionCurrentScene"); //Riposiziona
		//transform.rotation = Quaternion.Euler (15.0f, 114.0f, 10.0f);
		//transform.position = new Vector3(565.05f, 20.0f, 888.0f); //1537, 0, 348
	}
}
