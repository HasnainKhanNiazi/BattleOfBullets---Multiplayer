using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public GameObject cube1;
	public float Speed = 10f;
	void Update () {
		transform.RotateAround (cube1.transform.position, Vector3.up, Speed * Time.deltaTime);
	}
}
