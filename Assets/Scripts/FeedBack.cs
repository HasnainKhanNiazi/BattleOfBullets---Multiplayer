using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedBack : MonoBehaviour {
	
	public GameObject FeedBackUI;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenFeedBack(){
		anim.SetBool ("Run",true);
	}
}