﻿using UnityEngine;
using System.Collections;

public class qianghealty : MonoBehaviour {
	public int heal = 800;
	
	public AudioClip att;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (heal <= 0) {
			this.SendMessage ("isdie");
		}
	}
	
	void beingattack(){
		playerhealth.health -=100;
		AudioSource.PlayClipAtPoint(att,transform.position);
	}	

	void kouxue(){
		heal -= 50;
	}
	
	void huajikou(){
		heal -= 100;
	}
	IEnumerator dis(){
		print ("3");
		yield return new WaitForSeconds (5);
		Destroy (this.gameObject);
	}
}
