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
	public AudioClip level2Audio;
	public AudioClip level3Audio;
	public AudioClip levelEndlessAudio;



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
		if (music == null ) music = GetComponent<AudioSource>();

		if (scnIndex >= 0 && scnIndex <= 4)
		{
			music.clip = titleAudio;
            music.volume = 0.4f;
            music.Play();
		}

        if (scnIndex >= 5 && scnIndex <= 7)
		{
			music.clip = overworldAudio;
            music.volume = 0.3f;
            music.Play();
		}

		if (scnIndex == 8)
		{
			music.clip = levelEndlessAudio;
            music.volume = 0.5f;
            music.Play();
		}

		if (scnIndex == 9 || scnIndex == 12)
		{
			music.clip = level1Audio;
            music.volume = 0.3f;
            music.Play();
		}

		if (scnIndex == 10)
		{
			music.clip = level2Audio;
            music.volume = 0.35f;
            music.Play();
		}

		if (scnIndex == 11 || scnIndex == 13)
		{
			music.clip = level3Audio;
            music.volume = 0.5f;
            music.Play();
		}
	}
	private void FixedUpdate()
	{
		scnIndex = SceneManager.GetActiveScene().buildIndex;
		if (!music.isPlaying) music.Play();
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
