using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelect : MonoBehaviour {
	public static string SelectedHero;
	RaycastHit hit;
	public GameObject UI;
	string PlayerName;
	AudioSource source;

	[Header("Assign Buttons for Heros")]
	public GameObject AmandaBtn;
	public GameObject SwatBtn;
	public GameObject SwatNothBtn;
	public GameObject USSOLDIERBtn;

	[Header("Assign Selection for Heros")]
	public GameObject AmandaSel;
	public GameObject SwatSel;
	public GameObject SwatNothSel;
	public GameObject USSOLDIERSel;

	void Start(){
		source = Camera.main.GetComponent<AudioSource> ();
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				SelectedHero = hit.collider.name;
				ButtonsON ();
				if (SelectedHero != null) {
					hit.collider.transform.Find ("Selection").gameObject.SetActive (true);
//					UI.SetActive (true);
				}
			}
		}
	}

	public void ContinueUI(){
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (Resources.Load("Sounds/IN game Sounds/ready") as AudioClip);
		UI.SetActive (false);
		Application.LoadLevel (2);
	}

	void ButtonsON(){
		if (SelectedHero == "Amanda") {
			TurnOffSelection ();
			TurnOffAllButtons ();
			AmandaBtn.gameObject.SetActive (true);
			AmandaSel.gameObject.SetActive (true);
		}
		else if (SelectedHero == "genSWAT") {
			TurnOffSelection ();
			TurnOffAllButtons ();
			SwatBtn.gameObject.SetActive (true);
			SwatSel.gameObject.SetActive (true);
		}
		else if (SelectedHero == "genSWAT North") {
			TurnOffSelection ();
			TurnOffAllButtons ();
			SwatNothBtn.gameObject.SetActive (true);
			SwatNothSel.gameObject.SetActive (true);

		}
		else if (SelectedHero == "USSOLDIER") {
			TurnOffAllButtons ();
			TurnOffSelection ();
			USSOLDIERBtn.gameObject.SetActive (true);
			USSOLDIERSel.gameObject.SetActive (true);
		}
	}

	public void TurnOffAllButtons(){
		SwatNothBtn.gameObject.SetActive (false);
		AmandaBtn.gameObject.SetActive (false);
		SwatBtn.gameObject.SetActive (false);
		USSOLDIERBtn.gameObject.SetActive (false);
	}

	public void TurnOffSelection(){
		SwatNothSel.gameObject.SetActive (false);
		AmandaSel.gameObject.SetActive (false);
		SwatSel.gameObject.SetActive (false);
		USSOLDIERSel.gameObject.SetActive (false);
	}
}