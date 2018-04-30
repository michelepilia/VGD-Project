using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ScenesMusic : MonoBehaviour
{
	public AudioClip first;
	public AudioClip second;
	public AudioClip third;
	public AudioClip fourth;
	public AudioClip fifth;

	int level;

	void Start()
	{
		level = PlayerPrefs.GetInt ("level");

		AudioSource audio = GetComponent<AudioSource>();

		//yield return new WaitForSeconds(audio.clip.length);

		switch (level) {
		case 2:
			audio.clip = first;
			audio.Play();
			break;
		case 3:
			audio.clip = second;
			break;
		case 4:
			audio.clip = third;
			break;
		case 5:
			audio.clip = fourth;
			break;
		case 6:
			audio.clip = fifth;
			break;
		}

		audio.Play();
		audio.loop = true;
	}
}