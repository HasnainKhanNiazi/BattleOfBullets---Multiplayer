using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon.Chat;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SMSChat : MonoBehaviour,IChatClientListener {
	
	ChatClient Chat_Client;
	ExitGames.Client.Photon.Chat.AuthenticationValues authValues;
	List<string> messages;

	//Assign written text sms to send
	public Text WrittenSMS;
	//Assign Text To Show SMS
	public Text ShowSMS;
	//Assign ShowPanel To Write SMS
	public GameObject ShowWritePanel;
	//Assign WriteSMSPanel;
	public InputField WriteSMSPanel;

	int i = 0;

	void Start(){
		DontDestroyOnLoad (gameObject);
		Application.runInBackground = true;
		messages = new List<string>();
		authValues = new ExitGames.Client.Photon.Chat.AuthenticationValues();
		Chat_Client = new ChatClient (this);
		Chat_Client.ChatRegion = "Asia";
		authValues.UserId = PhotonNetwork.playerName;
		authValues.AuthType = ExitGames.Client.Photon.Chat.CustomAuthenticationType.Custom;
		Connect ();
	}

	public void Connect(){
		Chat_Client.Connect (PhotonNetwork.PhotonServerSettings.ChatAppID,"Version 01",authValues);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
			
			if (i == 0) {
				GameObject.FindObjectOfType<PlayerMovement> ().enabled = false;
				GameObject.FindObjectOfType<FirstPersonController> ().enabled = false;
				ShowWritePanel.SetActive (true);
				WrittenSMS.text = "";
				WriteSMSPanel.ActivateInputField ();
				i++;
			}
			else {
				GameObject.FindObjectOfType<PlayerMovement> ().enabled = true;
				GameObject.FindObjectOfType<FirstPersonController> ().enabled = true;
				Chat_Client.PublishMessage ("global",WrittenSMS.text);
				ShowWritePanel.SetActive (false);
				i = 0;
			}
		}
		if (Chat_Client != null) {
			Chat_Client.Service ();
		}
	}

	public void DebugReturn (ExitGames.Client.Photon.DebugLevel level, string message)
	{
		Debug.Log (string.Format("{0}: {1}",level,message));
	}

	public void OnDisconnected ()
	{
		Debug.Log ("Disconnected "+ Chat_Client.DisconnectedCause);
	}

	public void OnConnected ()
	{
		Chat_Client.Subscribe (new string[] {"global"});
		Chat_Client.SetOnlineStatus (ChatUserStatus.Online);
	}

	public void OnChatStateChange (ChatState state)
	{
		Debug.Log (state);
	}

	public void OnGetMessages (string channelName, string[] senders, object[] messages)
	{
		for (int i = 0; i < senders.Length; i++) {
			string sms = messages [i] + "";
			string sender = senders [i] + "";
//			string message = senders [i] + " : " + messages [i] + "\n";
			ShowSMS.GetComponent<Text> ().color = Color.green;
			ShowSMS.text += sender;
			ShowSMS.GetComponent<Text> ().color = Color.black;
			ShowSMS.text += ":";
			ShowSMS.GetComponent<Text> ().color = Color.white;
			ShowSMS.text += sms;
			ShowSMS.text += "\n";
//			messages.SetValue (message, i);
			}
		Debug.Log ("Message is this "+ messages[0]);
	}

	public void OnPrivateMessage (string sender, object message, string channelName)
	{
		
	}

	public void OnSubscribed (string[] channels, bool[] results)
	{
		
	}

	public void OnUnsubscribed (string[] channels)
	{
		
	}

	public void OnStatusUpdate (string user, int status, bool gotMessage, object message)
	{
		
	}

	public void OnApplicationQuit(){
		Chat_Client.Disconnect ();
	}
}