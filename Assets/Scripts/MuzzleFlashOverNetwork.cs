using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashOverNetwork : MonoBehaviour {

	public ParticleSystem FlashNetwork;
	public ParticleSystem BloodParticle;

	[PunRPC]
	void ActiveMuzzleFlashNetwork(){
		FlashNetwork.Play();
	}

	[PunRPC]
	void ActiveBloodParticlesNetwork(){
		BloodParticle.Play();
	}
}