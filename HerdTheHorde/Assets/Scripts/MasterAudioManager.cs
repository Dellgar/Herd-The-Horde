using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MasterAudioManager : MonoBehaviour {

	private AudioSource music;
	private Slider slider;

	public AudioClip titleAudio;
	public AudioClip overworldAudio;
	public AudioClip level1Audio;

	public int scnIndex;



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
	private void OnLevelWasLoaded(int scnIndex)
	{
		if (scnIndex == 0)//|| scnIndex == 1 || scnIndex == 2)
		{
			music.clip = titleAudio;
			music.Play();
		}
		if (scnIndex == 3)
		{
			music.clip = overworldAudio;
			music.Play();
		}
		if (scnIndex >= 4)
		{
			music.clip = level1Audio;
			music.Play();
		}
	}
	private void Update()
	{
		scnIndex = SceneManager.GetActiveScene().buildIndex;
	}

	public void MuteAudio()
	{
		AudioListener.pause = !AudioListener.pause;
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
