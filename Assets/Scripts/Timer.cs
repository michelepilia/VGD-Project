using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public int timeLeft = 180;
	public Text CountdownText;

	// Use this for initialization
	void Start () {

		StartCoroutine("LoseTime");
		
	}
	
	// Update is called once per frame
	void Update () {

		CountdownText.text = ("" + (timeLeft / 60) + ":" + (timeLeft % 60));
		//CountdownText.text = ("" + timeLeft);

		if(timeLeft <= 10)
		{
			CountdownText.color = Color.red;
		}


		if(timeLeft <= 0)
		{
			StopCoroutine ("LoseTime");
			CountdownText.text = "Tempo Scaduto!";
		}
		
	}

	IEnumerator LoseTime()
	{
		while (true) 
		{
			yield return new WaitForSeconds (1);
			timeLeft--;
		}
	}
}
