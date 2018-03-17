using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDamage : MonoBehaviour {
	public Collider[] Enemies;
	float Damage = 75;
	float DamageRadius = 10f;
	Rigidbody RB;

	void TakeDamage(){
		RB = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider col){
		int i = 0;
		GameObject Explode = PhotonNetwork.Instantiate ("Explosion", transform.position, transform.rotation, 0);
		//RB.velocity = Vector3.zero;
		Enemies = Physics.OverlapSphere (transform.position, DamageRadius);

		foreach (Collider enemy in Enemies) {
			
			if (enemy.tag == "Player") {
				if (i == 0) {	
					i++;
					enemy.GetComponent<PhotonView> ().RPC ("Damage", PhotonTargets.AllBuffered, Damage);
					enemy.GetComponent<LocalSounds> ().GrenadeSounds ();
					if (GetComponent<PhotonView> ().instantiationId == 0) {
						Destroy (gameObject);
					} else {
						PhotonNetwork.Destroy (gameObject);
					}
				}
				else {
					return;
				}
			}
		}
	}
}