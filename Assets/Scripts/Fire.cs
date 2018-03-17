using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour {
	
	public static bool HeadShot = false;
	public float GunRange;
	float fireRate = 0.1f;
	float nextFire;
	GunData GD;
	RaycastHit hit;
	VisualEffectsManager visual;
	public ParticleSystem partsaksdma;
	public string GunName;
	AudioSource source;
	FPSm16Controller FireGunAnim;
	ScoreCounterForNetwork ScoreCounter;
	//saving scores
	PlayerScoreSaver PSS;

	//Bullet Hole
	public GameObject BulletHole;

	//Gun Bullets Spread
	public float MaxBulletsSpreadAngle = 3.0f;
	public float TimeTillMaxSpreadAngle = 1.0f;

	// Use this for initialization
	void Start () {
		GD = transform.GetComponent<GunData> ();
		visual = GameObject.FindObjectOfType<VisualEffectsManager> ();
		source = Camera.main.GetComponent<AudioSource> ();
		FireGunAnim = gameObject.GetComponentInChildren<FPSm16Controller> ();
		ScoreCounter = transform.GetComponent<ScoreCounterForNetwork> ();
		PSS = GameObject.FindObjectOfType<PlayerScoreSaver>();

	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			
			if (Input.GetMouseButton (0)) {
				
				nextFire = Time.time + fireRate;
				if (GD.Bullets > 0) {
					if (FireGunAnim.isreloading == true)
						return;
					if (FireGunAnim.isreloading != true) {
						GD.DecreaseBullet ();
						GetComponent<PhotonView> ().RPC ("ActiveMuzzleFlashNetwork", PhotonTargets.All);
						DoFire ();
					}
				}
				else if (GD.Bullets <= 0 && !(GD.ExtraAmmo <= 0)) {
					FireGunAnim.Plyyyy ();
					GD.ReloadGun ();
				}
			}
		}
	}



	void DoFire ()
	{
//		Ray ray = new Ray(Camera.main.transform.position,Camera.main.transform.forward);

		Vector3 FireDirection = Camera.main.transform.forward;
		Quaternion FireRotation = Quaternion.LookRotation (FireDirection);
		Quaternion RandomRotation = Random.rotation;
		float CurrentSpread = Mathf.Lerp (0.0f, MaxBulletsSpreadAngle, nextFire / TimeTillMaxSpreadAngle);
		FireRotation = Quaternion.RotateTowards (FireRotation, RandomRotation, Random.Range (0.0f, CurrentSpread));

		Ray ray = new Ray (Camera.main.transform.position, FireRotation * Vector3.forward);

		if (GunName == "ak47") {
			source.PlayOneShot (Resources.Load ("Sounds/Guns Sounds/ak47") as AudioClip);
			partsaksdma.Play ();
		}
		if (GunName == "g3") {
			source.PlayOneShot (Resources.Load ("Sounds/Guns Sounds/g3") as AudioClip);
			partsaksdma.Play ();
		}

		if (Physics.Raycast (ray, out hit, GunRange)) {
			float damage;
			damage = CalculateDamage (hit.collider);
			string ApniTeam = null;
			string OpponentTeam = null;

			if (hit.collider.tag == "Player") {
				ApniTeam = GetComponent<LookTeamInGame> ().Team;
				OpponentTeam = hit.collider.GetComponent<LookTeamInGame> ().Team;
			}

			//Free For AlL Damage
			if (ApniTeam == null) {
				if ((hit.collider.tag == "Player")) {
					Health h = hit.collider.GetComponent<Health> ();

					if (h.health <= damage) {
						string sms = PhotonNetwork.playerName + " Killed " + hit.collider.GetComponent<PhotonView> ().owner.NickName;
						ScoreCounter.AddKill ();
						h.GetComponent<PhotonView> ().RPC ("DeathTextFn", PhotonTargets.All, sms);
						PSS.SaveKills = ScoreCounter.Kills;
					}
					h.GetComponent<PhotonView> ().RPC ("Damage", PhotonTargets.AllBuffered, damage);
				} else if (hit.collider.tag != "Player") {
					Instantiate (BulletHole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));	
				}

				if (hit.collider.tag == "Drum") {
					hit.collider.GetComponent<DrumHealth> ().DecreaseHealth ();
				}
			}

			//Team Damage
			else if (ApniTeam != null) {
				if ((hit.collider.tag == "Player") && ApniTeam == OpponentTeam) {
					Health h = hit.collider.GetComponent<Health> ();

					if (h.health <= damage) {
						string sms = PhotonNetwork.playerName + " Killed " + hit.collider.GetComponent<PhotonView> ().owner.NickName;
						GetComponent<PhotonView> ().RPC ("DeathTextFn", PhotonTargets.All, sms);
						ScoreCounter.AddAllyKillPenalty ();
						PSS.SaveKills = ScoreCounter.Kills;
					}
					h.GetComponent<PhotonView> ().RPC ("Damage", PhotonTargets.AllBuffered, damage);
				} else if (hit.collider.tag != "Player") {
					Instantiate (BulletHole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));	
				}

				if (hit.collider.tag == "Drum") {
					hit.collider.GetComponent<DrumHealth> ().DecreaseHealth ();
				}
			}
	}
}

	float CalculateDamage(Collider Col){
		float damage = 0;

		if (hit.collider.GetType () == typeof(SphereCollider)) {
			HeadShot = true;
			hit.collider.GetComponent<LocalSounds> ().HeadShot ();
			damage = 100;

		} else if (hit.collider.GetType () == typeof(CharacterController)) {
			damage = Random.Range (20, 25); 
		}
		return damage;
	}

}