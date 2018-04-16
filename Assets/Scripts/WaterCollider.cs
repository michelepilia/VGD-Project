using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaterCollider : MonoBehaviour {

	public GameObject GameOverMenu;
	public float timePause = 1.4f;
	public enum Mode {Simple = 1, Hard = 2};
	public Mode mode = Mode.Simple;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == "water") {
			if (mode == Mode.Simple) {
				StartCoroutine ("Reposition");
			} else if (mode == Mode.Hard) {
				StartCoroutine ("GameOver");
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
		yield return new WaitForSeconds (timePause);
		transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
		transform.position = new Vector3(467.0f, 34.0f, 808.0f); 
	}
}
