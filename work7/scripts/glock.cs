using UnityEngine;
using System.Collections;

public class glock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Fire(){
		this.animation.Play ("FPSHand|Fire");
	}
	void Reload(){
		this.animation.Play ("FPSHand|Reload");
	}
}
