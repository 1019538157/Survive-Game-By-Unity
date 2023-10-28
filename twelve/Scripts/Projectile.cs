using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision hit) {
		ContactPoint contact = hit.contacts [0];

		Quaternion hitRot = Quaternion.FromToRotation (Vector3.up, contact.normal);
		Vector3 hitPos = contact.point;
		GameObject instantiatedExplosion = Instantiate (explosion, hitPos, hitRot) as GameObject;

		Destroy (this.gameObject);
	}
}
