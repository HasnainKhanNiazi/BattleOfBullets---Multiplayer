using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomInfoForward : MonoBehaviour {
	public static string RoomName;
	public InputField RoomNameField;
	public static string Mode;
	public static string FF;
	public Toggle FriendlyFire;

	void Start(){
		
	}

	public void Getinfo(){
		if (FriendlyFire.isOn) {
			FF = "ON";
		}
		else if (FriendlyFire.isOn == false) {
			FF = "OFF";
		}
		if (CreateOrJoin.FreeForAll == true) {
			Mode = "FreeForAll";
		}
		else if (CreateOrJoin.DeathMatch == true) {
			Mode = "TDM";
		}
		RoomName = RoomNameField.transform.Find ("Text").GetComponent<Text> ().text;
		PhotonNetwork.playerName = PlayerPrefs.GetString ("Name");
	}
}