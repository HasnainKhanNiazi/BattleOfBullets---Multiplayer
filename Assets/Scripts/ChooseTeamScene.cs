using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTeamScene : MonoBehaviour {
	public static string SelectedTeam = null;

	public void TeamCT(){
		SelectedTeam = "CT";
	}

	public void TeamT(){
		SelectedTeam = "T";
	}
}