using UnityEngine;
using System.Collections;

public class Fact : MonoBehaviour {

	public GameObject coin;
	public float coinradius;
	public int MAXCoinNumber = 20;
	public static int all = 0;

	// Use this for initialization
	void Start () {
		float x, z;
		for (int i=0; i<MAXCoinNumber; i++) {
			float theta = i * 2 * Mathf.PI / MAXCoinNumber;
			x = coinradius * Mathf.Cos (theta);
			z = coinradius * Mathf.Sin (theta);
			Instantiate (coin, new Vector3 (x, 0, z)+transform.position, transform.rotation);
		}


		for (int i=0; i<10; i++) {
			x = Random.Range(998,1005);
			z = Random.Range(998,1005);
			Instantiate (coin, new Vector3 (x, 1, z), transform.rotation);
		}
		all += 30;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
