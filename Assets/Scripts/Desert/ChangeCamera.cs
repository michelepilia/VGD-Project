using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

	public Camera MainCamera;
	public Camera HighCamera;
	GameObject carSignaller;

	// Use this for initialization
	void Start () {

		carSignaller = GameObject.FindGameObjectWithTag ("TargetMap");
		MainCamera.enabled = true;
		HighCamera.enabled = false;
		carSignaller.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.U)) {
			//MainCamera.enabled = !MainCamera.enabled;
			HighCamera.enabled = !HighCamera.enabled;
			carSignaller.SetActive (!(carSignaller.activeSelf));

		}
	}
}

