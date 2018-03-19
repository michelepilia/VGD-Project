﻿//Riferimenti al link: https://www.youtube.com/watch?v=x-C95TuQtf0

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

		if ((timeLeft % 60) < 10) {
			CountdownText.text = ("" + (timeLeft / 60) + ":0" + (timeLeft % 60));
		} else {
			CountdownText.text = ("" + (timeLeft / 60) + ":" + (timeLeft % 60));
		}
			
		if(timeLeft <= 59 && timeLeft > 9)
		{
			CountdownText.color = Color.yellow;
		}


		if(timeLeft <= 9)
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

	public void updateTime()
	{
		timeLeft += 10;
	}
}
