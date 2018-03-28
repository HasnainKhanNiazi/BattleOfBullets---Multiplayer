using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour {
	
	public Transform LoadingBarr;
	public Text LoadingPercent;
	public Transform ContinueUI;
	public float Percentvalue;
	
	// Update is called once per frame
	void Update () {
		if (Percentvalue < 100) {
			Percentvalue += Time.deltaTime * 15;
			LoadingPercent.text = (int)Percentvalue + "";
		}
		else {
			ContinueUI.gameObject.SetActive (true);
		}
	//	LoadingBarr.GetComponent<Image> ().fillAmount = Percentvalue / 100;
	}
}