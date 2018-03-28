using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSounds : MonoBehaviour {
	public AudioClip GrenadeSound;
	public AudioClip SimpleHealingAudio;
	public AudioClip TakeCoverAudio;
	public AudioClip HeadShotAudio;
	public AudioClip DeathAudio;

	AudioSource Source;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GrenadeSounds(){
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (GrenadeSound);
	}

	public void SimpleHealing(){
		GameObject gb = GameObject.FindGameObjectWithTag ("SimpleHealingSource");
		Source = gb.GetComponent<AudioSource> ();
		Source.Play ();
	}

	public void TakeCover(){
		GameObject gb = GameObject.FindGameObjectWithTag ("Cover");
		Source = gb.GetComponent<AudioSource> ();
		Source.PlayOneShot(TakeCoverAudio);
	}

	public void HeadShot(){
		GameObject gb = GameObject.FindGameObjectWithTag ("SimpleHealingSource");
		Source = gb.GetComponent<AudioSource> ();
		Source.PlayOneShot (HeadShotAudio);
	}

	public void DeathSound(){
		GameObject gb = GameObject.FindGameObjectWithTag ("SimpleHealingSource");
		Source = gb.GetComponent<AudioSource> ();
		Source.PlayOneShot (DeathAudio);
	}
}