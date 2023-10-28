using UnityEngine;
using System.Collections;

public class PL_2 : MonoBehaviour {
	GameObject currentDoor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

			if (Physics.Raycast (transform.position, transform.forward,out hit, 3)) {
			if (hit.collider.gameObject.tag == "playerDoor") {
				currentDoor = hit.collider.gameObject;
				currentDoor.SendMessage("DoorCheck");
				}
			}
	}
}
