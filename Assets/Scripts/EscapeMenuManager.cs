using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenuManager : MonoBehaviour {
	public GameObject EscapeMenuPanel;

	public void ResumeGame(){
		Time.timeScale = 0f;
		EscapeMenuPanel.GetComponent<Animator> ().SetBool ("Run",false);
	}

	public void MainMenu(){
		PhotonNetwork.LeaveRoom ();
		SceneManager.LoadScene (0);
	}

	public void Quit(){
		PhotonNetwork.LeaveRoom ();
		Application.Quit ();
	}
}