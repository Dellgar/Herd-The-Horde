using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DontDestroyMePlease : MonoBehaviour {

	private AudioSource music;
	private Slider slider;

	private void Awake()
	{
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}
	void Start () {
		music = GetComponent<AudioSource>();

		DontDestroyOnLoad(this.gameObject);
	}

	public void MuteAudio()
	{
		music.mute = !music.mute;
	}

	public void VolumeAudio()
	{
		slider = GameObject.Find("Slider").GetComponent<Slider>();
		music.volume = slider.value;
	}
	public void PitchAudio()
	{
		slider = GameObject.Find("Pitch").GetComponent<Slider>();
		music.pitch = slider.value;
	}
}
