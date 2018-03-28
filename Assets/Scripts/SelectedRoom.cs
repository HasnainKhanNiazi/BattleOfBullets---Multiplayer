using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectedRoom : MonoBehaviour {

	public static string Selected_Room;
	public static string Map_Name;
	public static string Game_Mode;

	public void Assign_Room_To_Server(){

		Map_Name = transform.Find ("MapHeader").GetComponent<Text>().text;
		Selected_Room = transform.Find ("NameHeader").GetComponent<Text> ().text;
		Game_Mode = transform.Find ("ModeHeader").GetComponent<Text> ().text;

		if (Game_Mode == "Team Death Match") {
			SceneManager.LoadScene ("ChooseTeam");
		}
		else if (Game_Mode == "FreeForAll") {
			SceneManager.LoadScene ("HeroSelection");
		}
	}
}