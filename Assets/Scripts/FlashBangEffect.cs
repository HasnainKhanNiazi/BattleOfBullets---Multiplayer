using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBangEffect : MonoBehaviour {
	
	private GameObject FlashBangPanel;
	CanvasGroup canvasgroup;
	public bool IsFlash = false;


	// Use this for initialization
	void Start () {
		FlashBangPanel = GameObject.Find ("FlashBangEffect");
		canvasgroup = FlashBangPanel.GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (IsFlash) {
			canvasgroup.alpha = canvasgroup.alpha - Time.deltaTime;
			if (canvasgroup.alpha <= 0)
			{
				canvasgroup.alpha = 0;
				IsFlash = false;
			}
		}
	}

	public void FlashTrue(){
		IsFlash = true;
		canvasgroup.alpha = 1;
	}

	void OnTriggerEnter(Collider col){
		IsFlash = true;
		canvasgroup.alpha = 1;
//		int i = 0;
//
//		Enemies = Physics.OverlapSphere (transform.position, DamageRadius);
//
//		foreach (Collider enemy in Enemies) {
//
//			if (enemy.tag == "Player") {
//				if (i == 0) {	
//					i++;
//					enemy.GetComponent<LocalSounds> ().GrenadeSounds ();
//					if (GetComponent<PhotonView> ().instantiationId == 0) {
//						Destroy (gameObject);
//					}
//				}
//				else {
//					return;
//				}
//			}
//		}
	}

}