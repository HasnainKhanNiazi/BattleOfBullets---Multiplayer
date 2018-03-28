using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public float health = 100;
	public float Armor = 100;
	Image HealthImage;
	Image ArmorImage;
	PhotonView PV;
	Animator anim;
	public float Healingspeed = 0f;
	public string PLayerName;
	Text DeathText;

	//handling death here
	ScoreCounterForNetwork ScoreCounter;
	PlayerScoreSaver PSS;

	//Legend Player is controlling here
	LegendPlayer legend_player;

	//Camera Shake ON HeadShot
	public CameraShake Shaker;

	//Wait For Animation To End
	float timer = 0.0f;
	float timerMax = 3.5f;

	void Start(){
		HealthImage = GameObject.Find("HealthUI").GetComponent<Image>();
		ArmorImage = GameObject.Find("ArmorUI").GetComponent<Image>();
		PV = transform.GetComponent<PhotonView> ();
		anim = transform.GetComponent<Animator> ();
		ScoreCounter = transform.GetComponent<ScoreCounterForNetwork> ();
		legend_player = transform.GetComponent<LegendPlayer> ();
		PSS = GameObject.FindObjectOfType<PlayerScoreSaver>();
		if (GetComponent<PhotonView> ().isMine) {
			PLayerName = PhotonNetwork.playerName;
		}
		DeathText = GameObject.Find ("DeathText").GetComponent<Text> ();;
	}

	void Update(){
		if (PV.isMine) {
			HealthImage.rectTransform.sizeDelta = new Vector2 (health, 100);
			ArmorImage.rectTransform.sizeDelta = new Vector2 (Armor, 100);
		}

		if (health < 50 && Fire.HeadShot == false) {
			GetComponent<LocalSounds> ().TakeCover ();
		}

		/*if (health >= 100 || health <= 100) {
			Healingspeed = 0;
		}

		if (health < 90) {
			Healingspeed = 2;
			health += Healingspeed * Time.deltaTime;
		}*/

		if (timer < timerMax) {
			if (health <= 0) {
				timer += Time.deltaTime;
				anim.SetBool ("Death",true);
			}
		}
		else if (timer > timerMax) {
			DestroyPlayer ();
		}
	}

	[PunRPC]
	public void Damage(float damage){
		if (damage == 100) {
			Healingspeed = 0;
			GetComponent<LocalSounds> ().DeathSound();
		}
		GetComponent<PhotonView> ().RPC ("ActiveBloodParticlesNetwork", PhotonTargets.All);
		health = health - damage;
		Armor -= damage / 2;
	}

	void DestroyPlayer(){
		if (health <= 0) {
			legend_player.isLegend = false;
			if (PV.isMine) {
				ScoreCounter.AddDeath ();
				PSS.SaveDeaths = ScoreCounter.Deaths;
			}
			if (GetComponent<PhotonView> ().instantiationId == 0) {
				Destroy (gameObject);
			} else {
				if (PV.isMine) {
					if (gameObject.tag == "Player") {
						NetworkManager NM = GameObject.FindObjectOfType<NetworkManager>();
						NM.AloneCamera.gameObject.SetActive (true);
						NM.respawnTIme = 5.0f;
					}
					PhotonNetwork.Destroy (gameObject);
				}
			}
		}
	}

	[PunRPC]
	void DeathTextFn(string sms){
		DeathText.text = sms;
	}
}