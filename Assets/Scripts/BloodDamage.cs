using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodDamage : MonoBehaviour {
	Image image;
	Health h;
	Color temp;

	// Use this for initialization
	void Start () {
		h = transform.GetComponent<Health> ();
		image = GameObject.Find ("BloodImage").GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (h.health > 70) {
			temp = image.color;
			temp.a = 0f;
			image.color = temp;
		}

		if (h.health <= 70 && h.health >= 50) {
			temp = image.color;
			temp.a = 0.5f;
			image.color = temp;
		}

		if (h.health <= 50 && h.health >= 30) {
			temp = image.color;
			temp.a = 0.7f;
			image.color = temp;
		}

		if (h.health <= 30 && h.health > 0) {
			h.Healingspeed = 5f;
			temp = image.color;
			temp.a = 1f;
			image.color = temp;
		}
	}
}