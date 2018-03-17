using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChooseButtons : MonoBehaviour {
	[Header("Assigns Panels of all Maps")]
	public Transform MilitryPackPanel;
	public Transform ForestPanel;
	public Transform DesertPanel;
	public Transform TBDPanel;
	public Transform RoomSettingsPanel;

	[Space(10)]
	[Header("Assign Background Images for all Maps")]
	public Transform MilitryPackPanelImage;
	public Transform ParentBackgroundImage;
	public Transform ForestPanelImage;
	public Transform DesertPanelImage;
	public Transform TBDPanelImage;

	[Space(10)]

	[Header("Assign GO Button")]
	public Transform GO;

	[Space(10)]
	[Header("Selected Map")]
	public static string SelectedMap;

	bool isTrue = false;
	int check = 1;

	// Use this for initialization
	void Start () {
		ParentBackgroundImage.GetComponent<Animator> ().SetBool("Run",true);
	}

	public void MilitryPackClick(){
		ForestPanel.GetComponent<Animator> ().SetBool ("Run",false);
		TurnOffBackground ();
		MilitryPackPanelImage.GetComponent<Animator> ().SetBool("Run",true);

		if (check == 1) {
			check++;
			isTrue = true;
			GO.gameObject.SetActive (true);
			SelectedMap = "Militry";
			MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run", true);
		}
		else {
			check = 1;
			isTrue = false;
			GO.gameObject.SetActive (false);
			MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run", false);
		}
	}

	public void MilitryPackHover(){
		if (isTrue == false) {
			MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run", true);
		}
	}

	public void MilitryPackUnHover(){
		if (!isTrue) {
			MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run", false);
		}
	}

	public void ForestClick(){
		MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run",false);

		if (check == 1) {
			check++;
			isTrue = true;
			SelectedMap = "NetworkingScene";
			GO.gameObject.SetActive (true);
			ForestPanel.GetComponent<Animator> ().SetBool ("Run", true);
		}
		else {
			check = 1;
			isTrue = false;
			GO.gameObject.SetActive (false);
			ForestPanel.GetComponent<Animator> ().SetBool ("Run", false);
		}
	}

	public void ForestHover(){
		if (isTrue == false) {
			ForestPanel.GetComponent<Animator> ().SetBool ("Run", true);
		}
	}

	public void ForestUnHover(){
		if (!isTrue) {
			ForestPanel.GetComponent<Animator> ().SetBool ("Run", false);
		}
	}

	public void DesertHover(){
		if (isTrue == false) {
			DesertPanel.GetComponent<Animator> ().SetBool ("Run", true);
		}
	}

	public void DesertClick(){
		MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run",false);
		TurnOffBackground ();
		DesertPanelImage.GetComponent<Animator> ().SetBool("Run",true);

		if (check == 1) {
			check++;
			isTrue = true;
			SelectedMap = "Desert";
			GO.gameObject.SetActive (true);
			DesertPanel.GetComponent<Animator> ().SetBool ("Run", true);
		}
		else {
			check = 1;
			isTrue = false;
			GO.gameObject.SetActive (false);
			DesertPanel.GetComponent<Animator> ().SetBool ("Run", false);
		}
	}

	public void DesertUnHover(){
		if (!isTrue) {
			DesertPanel.GetComponent<Animator> ().SetBool ("Run", false);
		}
	}

	public void GoClick(){
		ForestPanel.GetComponent<Animator> ().SetBool ("Run", false);
		MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run", false);
		DesertPanel.GetComponent<Animator> ().SetBool ("Run", false);
		RoomSettingsPanel.GetComponent<Animator> ().SetBool ("Run", true);
	}

	void TurnOffBackground(){
		ParentBackgroundImage.GetComponent<Animator> ().SetBool("Run",false);
		MilitryPackPanelImage.GetComponent<Animator> ().SetBool("Run",false);
		ForestPanelImage.GetComponent<Animator> ().SetBool("Run",false);
		DesertPanelImage.GetComponent<Animator> ().SetBool("Run",false);
		TBDPanelImage.GetComponent<Animator> ().SetBool("Run",false);
	}
}