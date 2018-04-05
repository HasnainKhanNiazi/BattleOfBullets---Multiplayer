using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendPlayer : MonoBehaviour {

	//isLegend is setting by Health class
	public bool isLegend = true;

	ScoreCounterForNetwork Score;
	NetworkManager NM;

	//Wait For Animation To End
	float timer = 0.0f;
	float timerMax = 5.0f;

	void Start () {
		Score = GetComponent<ScoreCounterForNetwork> ();	
		NM = GameObject.FindObjectOfType<NetworkManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (CheckIFLegend()) {
			NM.LegendTrue = true;
		}

		if (timer < timerMax) {
			if (CheckIFLegend()) {
				timer += Time.deltaTime;
			}
		}
		else if (timer > timerMax) {
			NM.LegendTrue = false;
		}
	}

	bool CheckIFLegend(){
		if (isLegend && Score.Kills == 10){
			return true;
		}
		return false;
	}

	IEnumerator WaitForFiveSecs(){
		yield return new WaitForSeconds (5);
		//CheckIFLegend = false;
		NM.LegendTrue = false;
	}
}