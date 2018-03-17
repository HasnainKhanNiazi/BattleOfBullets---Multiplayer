using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounterForNetwork : MonoBehaviour {
	public int Kills;
	public int Deaths;
	PlayerScoreSaver PSSForLoad;
	int i = 0;

	// Use this for initialization
	void Start () {
		PSSForLoad = GameObject.FindObjectOfType<PlayerScoreSaver>();	
		Kills = PSSForLoad.SaveKills;
		Deaths = PSSForLoad.SaveDeaths;
	}

	// Update is called once per frame
	void Update () {
	}

	void JustOneTimeUpdate(){
		ExitGames.Client.Photon.Hashtable PLayerID = new ExitGames.Client.Photon.Hashtable ();
		PLayerID.Add ("Kills", Kills.ToString());
		PLayerID.Add ("Deaths", Deaths.ToString());
		PhotonNetwork.player.SetCustomProperties (PLayerID);
		i++;
	}

	public void AddKill(){
		Kills++;
		ExitGames.Client.Photon.Hashtable PLayerID = new ExitGames.Client.Photon.Hashtable ();
		PLayerID.Add ("Kills", Kills.ToString());
		PLayerID.Add ("Deaths", Deaths.ToString());
		PhotonNetwork.player.SetCustomProperties (PLayerID);
	}

	public void AddDeath(){
		Deaths++;
		ExitGames.Client.Photon.Hashtable PLayerID = new ExitGames.Client.Photon.Hashtable ();
		PLayerID.Add ("Kills", Kills.ToString());
		PLayerID.Add ("Deaths", Deaths.ToString());
		PhotonNetwork.player.SetCustomProperties (PLayerID);
	}

	public void AddAllyKillPenalty(){
		Kills--;
		ExitGames.Client.Photon.Hashtable PLayerID = new ExitGames.Client.Photon.Hashtable ();
		PLayerID.Add ("Kills", Kills.ToString());
		PLayerID.Add ("Deaths", Deaths.ToString());
		PhotonNetwork.player.SetCustomProperties (PLayerID);
	}
}