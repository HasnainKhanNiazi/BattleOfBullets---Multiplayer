using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomList : MonoBehaviour {
	public GameObject RoomBoardEntry;
	public GameObject RoomBoardPanelParent;


	void Start(){
		PhotonNetwork.ConnectUsingSettings ("Version 01");
	}

	void OnReceivedRoomListUpdate(){
		foreach (RoomInfo room in PhotonNetwork.GetRoomList()) {
			GameObject RoomObject = (GameObject)Instantiate (RoomBoardEntry);
			RoomObject.transform.SetParent (RoomBoardPanelParent.transform);
			string FF = (string) room.CustomProperties ["FF"];
			string playersinlobby = room.PlayerCount + "/" + room.MaxPlayers;
			string Map_Name =(string) room.CustomProperties ["MapName"];
			string Game_Mode =(string) room.CustomProperties ["GameMode"];
			RoomObject.transform.Find ("MapHeader").GetComponent<Text> ().text = Map_Name;
			RoomObject.transform.Find ("NameHeader").GetComponent<Text> ().text = room.name;
			RoomObject.transform.Find ("PlayersHeader").GetComponent<Text> ().text = playersinlobby;

			if (Game_Mode == "TDM") {
				Game_Mode = "Team Death Match";
				if (FF == "ON") {
					RoomObject.transform.Find ("ModeHeader").GetComponent<Text> ().color = Color.red;
				}
				else if (FF == "OFF") {
					RoomObject.transform.Find ("ModeHeader").GetComponent<Text> ().color = Color.green;
				}
				RoomObject.transform.Find ("ModeHeader").GetComponent<Text> ().text = Game_Mode;
			}
			else if (Game_Mode == "FreeForAll") {
				RoomObject.transform.Find ("ModeHeader").GetComponent<Text> ().text = Game_Mode;
			}
		}
	}

	public void ShowJoinText(){
		GameObject.Find ("JoinText").transform.position =  Input.mousePosition;
		GameObject.Find ("JoinText").GetComponent<CanvasGroup> ().alpha = 1;
	}

	public void HideJoinText(){
		GameObject.Find ("JoinText").GetComponent<CanvasGroup> ().alpha = 0;
	}
}