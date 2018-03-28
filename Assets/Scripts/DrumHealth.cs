using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumHealth : MonoBehaviour {
	
	public int Health = 100;
	public Collider[] Enemies;
	float Damage = 50;
	float DamageRadius = 10f;
	int i = 0;

	public void DecreaseHealth(){
		Health -= 30;
	}

	void Update(){
		if (i == 0) {
			if (Health <= 0) {
				GameObject Explode = PhotonNetwork.Instantiate ("Explosion", transform.position, transform.rotation, 0);
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
				i++;		
			}
		}
	}
}