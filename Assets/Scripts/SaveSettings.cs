using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSettings : MonoBehaviour {

	[Tooltip("Assign Name Text")]
	public InputField NameField;

	[Tooltip("Assing AudioSlider")]
	public Slider AudioSlider;

	[Tooltip("Assing SenstivitySlider")]
	public Slider SentivitySlider;

	// Use this for initialization
	void Start () {
		NameField.text = PlayerPrefs.GetString ("Name");
		AudioSlider.value = PlayerPrefs.GetFloat ("AudioValue");
		SentivitySlider.value = PlayerPrefs.GetFloat ("SentivityValue");
	}

	public void SaveData(){
		PhotonNetwork.playerName = NameField.text;
		PlayerPrefs.SetString ("Name",NameField.text);
		PlayerPrefs.SetFloat ("AudioValue",AudioSlider.value);
		PlayerPrefs.SetFloat ("SentivityValue",SentivitySlider.value);
	}
}