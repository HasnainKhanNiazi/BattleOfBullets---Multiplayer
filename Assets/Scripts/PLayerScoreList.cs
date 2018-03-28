using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayerScoreList : MonoBehaviour {
	public GameObject UIPrefab;
	PhotonPlayer[] PlayersList;

	// Use this for initialization
	void Start () {
		//for (int i = 0; i < 10; i++) {
			GameObject GOB = (GameObject) Instantiate (UIPrefab);
			GOB.transform.SetParent (this.transform);
		//}
	}
	
	// Update is called once per frame
	void Update () {
		int NumbrofPlayers = (int)PhotonNetwork.countOfPlayers;
		//foreach (PhotonPlayer player in PhotonNetwork.playerList) {
		//for (int i = 0; i < NumbrofPlayers; i++) {
		//	Debug.Log("Kharki de bache unity ale " + NumbrofPlayers);
		//	GameObject GOB = (GameObject) Instantiate (UIPrefab);
		//	GOB.transform.SetParent (this.transform);
		//}
		//	string Kills = (string)player.customProperties ["Kills"];
		//	string Deaths = (string)player.customProperties ["Deaths"];
		//	string Assists = (string)player.customProperties ["Assists"];
		//	GOB.transform.Find ("NameHeader").GetComponent<Text> ().text = player.name;
		//	GOB.transform.Find ("KillsHeader").GetComponent<Text> ().text = Kills;
		//	GOB.transform.Find ("DeathHeader").GetComponent<Text> ().text = Deaths;
		//}

	}
}
