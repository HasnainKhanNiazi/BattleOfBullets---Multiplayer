using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour {
	
	public Animator anim;
	public GameObject[] UI_To_Disbale;

	IEnumerator Fading(string SceneName){
		anim.SetBool ("Fade",true);
		//UI_To_Disbale.SetActive (false);
		TurnOff();
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene (SceneName);
	}

	public void DoFade(string sceneName){
		if (sceneName == "") {
			if (CreateOrJoin.DeathMatch) {
				sceneName = "ChooseTeam";
			}
			else if (CreateOrJoin.FreeForAll) {
				sceneName = "HeroSelection";
			}
		}
		StartCoroutine (Fading(sceneName));
	}

	void TurnOff(){
		foreach (GameObject UI in UI_To_Disbale) {
			UI.SetActive (false);
		}
	}
}