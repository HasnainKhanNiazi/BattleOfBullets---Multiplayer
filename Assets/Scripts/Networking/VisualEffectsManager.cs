using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffectsManager : MonoBehaviour {

	public GameObject RifleEffects;

	[PunRPC]
	void GunVoice(Vector3 Start,Vector3 End){
//		Instantiate (RifleEffects, Start,Quaternion.LookRotation(End - Start));

		Instantiate (RifleEffects, Start,Quaternion.identity);


	}
}