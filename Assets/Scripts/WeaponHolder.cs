using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {
	public GameObject SniperRifle;
	// Use this for initialization

	void Start () {
		Instantiate (SniperRifle, transform);
		//GOB.transform.parent = transform;
	}
}
