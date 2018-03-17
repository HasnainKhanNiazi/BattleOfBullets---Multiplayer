 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {
	
	[Header("Panel for ScoreBoard")]
	[Space]
	public GameObject ScoreBoardPanelParent;
	public GameObject UIPrefab;

	[Space(10)]

	[Header("UI Elements")]
	[Space]
	public Text Bullets;
	public Text NetworkStatetext;

	[Space(10)]
	public float respawnTIme = 0;
	public Camera AloneCamera;

	[Space(10)]
	[Header("Player Attributes")]
	[Space]
	public Text PlayerName;
	public Image PlayerAvatar;

	[Space(10)]
	[Header("Set Offline Mode for testing purposes")]
	[Space]
	public bool offlinemode = false;

	[Space(10)]
	[Header("Assign Legend Player Text")]
	[Space]
	public Text Legend_PLayer_Text;
	public bool LegendTrue = false;

	[Space(10)]
	[Header("Assign Escape Menu Panel")]
	public GameObject EscapeMenuPanel;

	Health h;
	bool Connecting = false;

	void Start () {
		Connect();		
		h = FindObjectOfType<Health> ();
	}

	void Update(){
		if (Input.GetKey (KeyCode.Tab)) {
			//Destroy All Score Created Before
			foreach (Transform child in ScoreBoardPanelParent.transform.Find("ScoreBoardUnit").transform) {
				GameObject.Destroy (child.gameObject);
			}
			foreach (PhotonPlayer player in PhotonNetwork.playerList) {
				GameObject GOB = (GameObject)Instantiate (UIPrefab);
				GOB.transform.SetParent (ScoreBoardPanelParent.transform.Find ("ScoreBoardUnit").transform);
				string Kills = (string)player.customProperties ["Kills"];
				string Deaths = (string)player.customProperties ["Deaths"];
				GOB.transform.Find ("NameHeader").GetComponent<Text> ().text = player.name;
				GOB.transform.Find ("KillsHeader").GetComponent<Text> ().text = Kills;
				GOB.transform.Find ("DeathHeader").GetComponent<Text> ().text = Deaths;
			}
			ScoreBoardPanelParent.GetComponent<Animator> ().SetBool ("Run", true);
		}
		else {
			ScoreBoardPanelParent.GetComponent<Animator> ().SetBool ("Run",false);
		}

		//Escape Menu is Controlling here
		if (Input.GetKeyDown (KeyCode.Escape)) {
			EscapeMenuPanel.GetComponent<Animator> ().SetBool ("Run", true);
		}

		// Player Respawn is handling here
		if (respawnTIme > 0) {
			respawnTIme -= Time.deltaTime;

			if (respawnTIme <= 0) {
				SpawnPlayer ();
			}
		}

		//Set Player Name in UI text
		PlayerName.text = PhotonNetwork.playerName;

		if (LegendTrue) {
			Legend_PLayer_Text.GetComponent<Animator> ().SetBool ("Run",true);
		}
	}

	void Connect(){
		if (CreateOrJoin.CreateRoom) {
			PhotonNetwork.ConnectUsingSettings ("Version 01");
		}
		else if (CreateOrJoin.JoinRoom) {
			PhotonNetwork.JoinRoom (SelectedRoom.Selected_Room);
		}
	}

	[PunRPC]
	void PlayerSpawnSMS(string sms){
		GetComponent<PhotonView> ().RPC ("SMS_RPC",PhotonTargets.AllBuffered,sms);
	}

	void OnGUI(){
		if(PhotonNetwork.connected != true){
			NetworkStatetext.text = PhotonNetwork.connectionStateDetailed.ToString();
		}
		if (PhotonNetwork.connected == true) {
			NetworkStatetext.GetComponent<CanvasGroup> ().alpha = 0;
		}
	}

	void OnJoinedLobby(){
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("OnPhotonRandomJoinFailed");
		CreateRoom ();
	}

	void OnJoinedRoom(){
		Debug.Log ("OnJoinedRoom");
		Connecting = true;
		SpawnPlayer ();
	}

	void CreateRoom(){
		string RoomName = "Default";
		if (RoomInfoForward.RoomName == "") {
			RoomName = "Default";
		}
		else{
			RoomName = RoomInfoForward.RoomName;
		}
		RoomOptions roomOptions = new RoomOptions();
		roomOptions.CustomRoomPropertiesForLobby = new string[] {
			"MapName",
			"GameMode",
			"FF"
		};
		roomOptions.customRoomProperties = new ExitGames.Client.Photon.Hashtable() { {"MapName", MapChooseButtons.SelectedMap} , {"GameMode",RoomInfoForward.Mode} ,
			{"FF",RoomInfoForward.FF} }; 
		roomOptions.maxPlayers = 10;
		PhotonNetwork.CreateRoom(RoomName, roomOptions, TypedLobby.Default);
	}

	void SpawnPlayer(){
		Vector3 SpawnPoint = AloneCamera.transform.position;

		if (MapChooseButtons.SelectedMap == "Desert") {
			SpawnPoint = new Vector3 (7.03f, 7.27f, -15.82f);
		}
		else if (MapChooseButtons.SelectedMap == "Miitry") {
			SpawnPoint = new Vector3 (653.1442f, 53.852f, 703.296f);
		}
		GameObject playerobject =(GameObject) PhotonNetwork.Instantiate (HeroSelectForward.HeroName,SpawnPoint,Quaternion.identity, 0);

		if(HeroSelect.SelectedHero == "genSWAT"){
			playerobject.GetComponent<PlayerMovement> ().enabled = true;
			playerobject.GetComponent<AudioSource> ().enabled = true;
			playerobject.GetComponent<FirstPersonController>().enabled = true;
			playerobject.GetComponent<Fire>().enabled = true;
			playerobject.GetComponent<GunData> ().enabled = true;
			playerobject.GetComponent<ScoreCounterForNetwork> ().enabled = true;
			playerobject.GetComponent<BloodDamage> ().enabled = true;
			playerobject.GetComponent<GrenadeThrow> ().enabled = true;
			playerobject.GetComponent<BloodDamage> ().enabled = true;
			playerobject.GetComponent<LocalSounds> ().enabled = true;
			playerobject.GetComponent<myMinimapTarget> ().enabled = true;
			playerobject.GetComponent<ThrowFlash> ().enabled = true;
			playerobject.GetComponent<LegendPlayer> ().enabled = true;
			AloneCamera.gameObject.SetActive (false);
		}

		if (HeroSelect.SelectedHero == "Amanda") {
			playerobject.GetComponent<PlayerMovement> ().enabled = true;
			playerobject.GetComponent<AudioSource> ().enabled = true;
			playerobject.GetComponent<FirstPersonController>().enabled = true;
			playerobject.GetComponent<Fire>().enabled = true;
			playerobject.GetComponent<GunData> ().enabled = true;
			playerobject.GetComponent<ScoreCounterForNetwork> ().enabled = true;
			playerobject.GetComponent<BloodDamage> ().enabled = true;
			playerobject.GetComponent<GrenadeThrow> ().enabled = true;
			playerobject.GetComponent<LocalSounds> ().enabled = true;
			playerobject.GetComponent<myMinimapTarget> ().enabled = true;
			playerobject.GetComponent<ThrowFlash> ().enabled = true;
			playerobject.GetComponent<LegendPlayer> ().enabled = true;
			AloneCamera.gameObject.SetActive (false);
		}

		if (HeroSelect.SelectedHero == "USSOLDIER") {
			playerobject.GetComponent<PlayerMovement> ().enabled = true;
			playerobject.GetComponent<AudioSource> ().enabled = true;
			playerobject.GetComponent<FirstPersonController>().enabled = true;
			playerobject.GetComponent<Fire>().enabled = true;
			playerobject.GetComponent<GrenadeThrow> ().enabled = true;
			playerobject.GetComponent<GunData> ().enabled = true;
			playerobject.GetComponent<ScoreCounterForNetwork> ().enabled = true;
			playerobject.GetComponent<LocalSounds> ().enabled = true;
			playerobject.GetComponent<BloodDamage> ().enabled = true;
			playerobject.GetComponent<myMinimapTarget> ().enabled = true;
			playerobject.GetComponent<ThrowFlash> ().enabled = true;
			playerobject.GetComponent<LegendPlayer> ().enabled = true;
			AloneCamera.gameObject.SetActive (false);
		}

		if(HeroSelect.SelectedHero == "genSWAT North"){
			playerobject.GetComponent<PlayerMovement> ().enabled = true;
			playerobject.GetComponent<AudioSource> ().enabled = true;
			playerobject.GetComponent<FirstPersonController>().enabled = true;
			playerobject.GetComponent<Fire>().enabled = true;
			playerobject.GetComponent<GunData> ().enabled = true;
			playerobject.GetComponent<BloodDamage> ().enabled = true;
			playerobject.GetComponent<LocalSounds> ().enabled = true;
			playerobject.GetComponent<ScoreCounterForNetwork> ().enabled = true;
			playerobject.GetComponent<myMinimapTarget> ().enabled = true;
			playerobject.GetComponent<GrenadeThrow> ().enabled = true;
			playerobject.GetComponent<ThrowFlash> ().enabled = true;
			playerobject.GetComponent<LegendPlayer> ().enabled = true;
			AloneCamera.gameObject.SetActive (false);
		}
	}
}