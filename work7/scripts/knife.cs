﻿using UnityEngine;
using System.Collections;

public class knife : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Fire(){
		this.animation.Play ("cut");
	}
}
