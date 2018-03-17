using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunData : MonoBehaviour {
	public int ExtraAmmo = 90;
	public int Bullets = 30;
	Text BulletsText;
	Text MagzieText;

	// Use this for initialization
	void Start () {
		BulletsText = GameObject.Find ("BulletText").GetComponent<Text>();	
		MagzieText = GameObject.Find ("MagzineText").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		BulletsText.text = Bullets.ToString ();
		MagzieText.text = ExtraAmmo.ToString ();
	}

	public void DecreaseBullet(){
		Bullets -= 1;
	}

	public void ReloadGun(){
		int TempAmmo = 30 - Bullets;
		Bullets += TempAmmo;
		ExtraAmmo -= TempAmmo;
		if (ExtraAmmo <= 0) {
			ExtraAmmo = 0;
		}
	}
}