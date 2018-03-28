using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneBackEnd : MonoBehaviour {
	public Slider SliderBar;
	public Text ProgressText;
	public Text ProgressDetalsText;
	string mapname;

	// Use this for initialization
	void Start () {
		if (MapChooseButtons.SelectedMap == null) {
			mapname = SelectedRoom.Map_Name;
		}
		else if (MapChooseButtons.SelectedMap != null) {
			mapname = MapChooseButtons.SelectedMap;
		}
		StartCoroutine (LoadScene());

	}

	IEnumerator LoadScene(){
		yield return new WaitForSeconds (10);
		AsyncOperation asyncopp = Application.LoadLevelAsync (mapname)	;

		while (!asyncopp.isDone) {
			if(asyncopp.progress > 0.9){
				asyncopp.allowSceneActivation = true;
			}
			else if (asyncopp.progress > 0.1) {
				ProgressDetalsText.text = "Loading Components";
			}
			else if (asyncopp.progress > 0.1) {
				ProgressDetalsText.text = "Initializing World";
			}
			float progress = Mathf.Clamp01(asyncopp.progress / 0.9f);
			ProgressText.text = progress * 100f + "%";
			SliderBar.value = progress;
			yield return null;
		}
	}
}