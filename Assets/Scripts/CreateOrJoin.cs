using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoin : MonoBehaviour {

	public static bool CreateRoom = false;
	public static bool JoinRoom = false;
	public static bool FreeForAll = false;
	public static bool DeathMatch = false;

	public void ClickCreate(){
		CreateRoom = true;
	}

	public void ClickJoin(){
		JoinRoom = true;
	}

	public void FreeForAllM(){
		DeathMatch = false;
		FreeForAll = true;
	}

	public void DeathMatchM(){
		FreeForAll = false;
		DeathMatch = true;
	}
}