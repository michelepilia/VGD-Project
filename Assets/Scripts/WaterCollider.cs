using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaterCollider : MonoBehaviour {

	public GameObject GameOverMenu;
	public float timePause = 1.4f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter (Collider collider) {
	
		if (collider.gameObject.tag == "water") {
			StartCoroutine("GameOver");
		}
	}

	IEnumerator GameOver() {
		yield return new WaitForSeconds (timePause);
		GameOverMenu.SetActive (true);
		Time.timeScale = 0f;
		AudioListener.pause = true;
	
	}
}
