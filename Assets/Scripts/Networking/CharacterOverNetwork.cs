using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOverNetwork : Photon.MonoBehaviour {
	Vector3 Position = Vector3.zero;
	Quaternion Rotation = Quaternion.identity;
	GameObject MeshCleaner;

	bool FirstUpdate = false;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
		MeshCleaner = transform.Find ("amandaprefab").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			//Do Nothing
			transform.Find("GunCamera").gameObject.SetActive(true);
			MeshCleaner.transform.Find ("hip").gameObject.SetActive (false);
			MeshCleaner.transform.Find ("mesh").gameObject.SetActive (false);

		}
		else {
			transform.Find("GunCamera").gameObject.SetActive(false);
			MeshCleaner.transform.Find ("hip").gameObject.SetActive (true);
			MeshCleaner.transform.Find ("mesh").gameObject.SetActive (true);
			transform.position = Vector3.Lerp (transform.position, Position, 0.1f);
			transform.rotation = Quaternion.Lerp (transform.rotation, Rotation, 0.1f);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if (stream.isWriting) {
			//this is our player we need to send current position to the netwrok
			stream.SendNext(transform.position);
			stream.SendNext (transform.rotation);

		} 
		else {
			//This is Enemy's player we need to receive data from them
			if (FirstUpdate == false) {
				transform.position = Position;
				transform.rotation = Rotation;
				FirstUpdate = true;
			}

			Position = (Vector3) stream.ReceiveNext();
			Rotation = (Quaternion) stream.ReceiveNext();

		}
	}

}