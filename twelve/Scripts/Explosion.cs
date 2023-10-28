using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float explosionTime = 1.0f;

	public float explosionRadius = 5.0f;
	public float explosionPower = 2000.0f;

	// Use this for initialization
	IEnumerator Start () {
		Destroy (this.gameObject, explosionTime);

		Collider[] colliders = Physics.OverlapSphere (this.transform.position, explosionRadius);

		foreach (Collider collider in colliders) {
			if (collider.rigidbody) {
				collider.rigidbody.AddExplosionForce( explosionPower, this.transform.position, explosionRadius );
			}
		}

		if (this.particleEmitter) {
			this.particleEmitter.emit = true;
			yield return new WaitForSeconds(0.5f);
			this.particleEmitter.emit = false;
		}
	}
}
