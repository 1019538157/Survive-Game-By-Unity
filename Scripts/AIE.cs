using UnityEngine;
using System.Collections;

public class AIE : MonoBehaviour {
	
	public Transform player;
	public float speed = 3.0f;
	public float stoppingdistance = 5.0f;
	public bool isattack = false ; 
	public bool ishit = false ; 

	// Use this for initialization
	void Start () {
		Patrol();
	}
	
	// Update is called once per frame
	IEnumerator Patrol(){
		while (true) {
			if (Vector3.Distance (transform.position, player.position) <= stoppingdistance) {
				yield return StartCoroutine("Attack");
			} else {
				speed = 3;
				transform.position = Vector3.MoveTowards (transform.position, player.position,speed*Time.deltaTime);
				transform.LookAt (player);
				this.animation.Play("Walk");
			}
		}
	}

	IEnumerator Attack(){
		if (Vector3.Distance (transform.position, player.position) > stoppingdistance) {
			transform.position = Vector3.MoveTowards (transform.position, player.position,speed*Time.deltaTime);
		} else {
			//transform.position = Vector3.RotateTowards(transform.position,player.position,speed*Time.deltaTime);
		}
		speed = -0.6f;
		transform.position = Vector3.MoveTowards (transform.position, player.position,speed*Time.deltaTime);
		
		transform.LookAt (player);
		this.animation.CrossFade ("Attack01", 0.5f);
		//playerhealth.health-=50;
		yield return new WaitForSeconds (0.55f);
	}
}
