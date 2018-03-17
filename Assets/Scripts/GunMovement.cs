using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour {
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			anim.SetFloat ("Walk", Input.GetAxis ("Vertical"));
		} else if (Input.GetKeyDown (KeyCode.W) && Input.GetKey (KeyCode.LeftShift)) {
			anim.SetFloat ("Run", 1);
			anim.SetFloat ("Walk", Input.GetAxis ("Vertical"));
		} else if (Input.GetMouseButton (0)) {
			anim.Play ("Shoot");
		} else if (Input.GetKeyDown (KeyCode.R)) {
			anim.Play ("Reload");
		}
		else {
			anim.SetFloat ("Walk", Input.GetAxis ("Vertical"));
			anim.SetFloat ("Run", 0);
		}
	}
}