using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3);
	}
}
