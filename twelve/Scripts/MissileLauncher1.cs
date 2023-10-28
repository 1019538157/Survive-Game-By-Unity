using UnityEngine;
using System.Collections;

public class MissileLauncher1 : MonoBehaviour {
	public Rigidbody projectile;
	public float speed = 30.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Rigidbody instantiatedProjectile =
				Instantiate( projectile, transform.position,
				               transform.rotation ) as Rigidbody;
			instantiatedProjectile.velocity =
				transform.TransformDirection(
					new Vector3(0, 0, speed) );

				Physics.IgnoreCollision(
					instantiatedProjectile.collider,
					transform.root.collider );
			}
	}
}
