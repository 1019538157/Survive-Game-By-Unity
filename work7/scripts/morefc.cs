using UnityEngine;
using System.Collections;

public class morefc : MonoBehaviour {
	public GameObject fact;


	// Use this for initialization
	void Start () {
		float x, z;
		for (int i=0; i<10; i++) {
			x = Random.Range(900,1005);
			z = Random.Range(900,1005);
			Instantiate (fact, new Vector3 (x, 1, z), transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

}
