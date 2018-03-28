using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowFlash : MonoBehaviour {
	GameObject GunCamera;
	int count = 0;

	// Use this for initialization
	void Start () {
		GunCamera = transform.Find ("GunCamera").gameObject;		
	}
	
	// Update is called once per frame
	void Update () {
		if (count < 2) {
			if (Input.GetKeyDown (KeyCode.F)) {
				// hide gun to throw grenade
				if (transform.name == "Amanda(Clone)") {
					GunCamera.transform.Find ("Lil").gameObject.SetActive (false);
				}
				if (transform.name == "genSWAT North(Clone)") {
					GunCamera.transform.Find ("m4_fp").gameObject.SetActive (false);
				}
				if (transform.name == "genSWAT(Clone)") {
					GunCamera.transform.Find ("47T3").gameObject.SetActive (false);
				}
			}


			if (Input.GetKeyUp (KeyCode.F)) {
				//Show Gun
				if (transform.name == "Amanda(Clone)") {
					GunCamera.transform.Find ("Lil").gameObject.SetActive (true);
				}
				if (transform.name == "genSWAT North(Clone)") {
					GunCamera.transform.Find ("m4_fp").gameObject.SetActive (true);
				}
				if (transform.name == "genSWAT(Clone)") {
					GunCamera.transform.Find ("47T3").gameObject.SetActive (true);
				}
				FlashThrow ();
			}
		}
	}

	void FlashThrow(){
		
		if (Input.GetKeyUp (KeyCode.F)) {
			count++;
			GunFirePoint GFP = gameObject.GetComponentInChildren<GunFirePoint> ();
			GameObject Grenade = (GameObject)PhotonNetwork.Instantiate ("FlashBang", GFP.transform.position, GFP.transform.rotation, 0); 
			Rigidbody rb = Grenade.GetComponent<Rigidbody> ();
			rb.AddForce (transform.forward * 40f, ForceMode.VelocityChange);
		}
	}
}