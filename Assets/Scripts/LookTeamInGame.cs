using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTeamInGame : MonoBehaviour {
	public string Team = null;

	// Use this for initialization
	void Start () {
		Team = ChooseTeamScene.SelectedTeam;
	}
}