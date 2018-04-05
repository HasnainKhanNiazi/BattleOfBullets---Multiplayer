using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectForward : MonoBehaviour {
	public static string HeroName;
	AudioSource source;
	public GameObject LoadingUI;
	public string NameAssign;

	public GameObject[] UI_Components;

	[Space(10)]
	[Tooltip("Assign MapName For Loading UI")]
	public Text MapName;

	void Start(){
		source = Camera.main.GetComponent<AudioSource> ();
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			HeroName = NameAssign;
		}
	}

	public void SplashScreen(){
		for (int i = 0; i < UI_Components.Length; i++) {
			UI_Components [i].gameObject.SetActive (false);
		}
		source.loop = true;
		source.clip = Resources.Load ("Sounds/IN game Sounds/ambience") as AudioClip;
		source.Play ();
		int RandomForImage = Random.Range (1,7);
		LoadingUI.GetComponent<Image> ().overrideSprite = Resources.Load<Sprite> ("Pictures/"+RandomForImage+"");
		MapName.text = MapChooseButtons.SelectedMap;
		LoadingUI.SetActive (true);
	}

	public void DemoHeroHover(){
		
	}

	public void DemoHeroUnHover(){

	}
}