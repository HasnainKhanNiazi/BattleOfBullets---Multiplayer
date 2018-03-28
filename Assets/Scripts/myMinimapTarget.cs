using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myMinimapTarget : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		if (GetComponent<PhotonView> ().isMine) {
			bl_MiniMap.m_Target = this.gameObject;	
		}
		else {
			bl_MiniMapItem bl = new bl_MiniMapItem ();
			bl.GraphicPrefab = this.gameObject;
			bl.Target = this.gameObject.transform;
		}
	}
}