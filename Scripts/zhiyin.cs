using UnityEngine;
using System.Collections;

public class zhiyin : MonoBehaviour {

	public AudioClip ji;
	public AudioClip chang;
	public AudioClip tiao;
	public AudioClip rap;
	//public AudioClip ngm;
	public Rigidbody pow1;
	public Rigidbody pow2;
	public float throwSpeed = 60.0f;

	// Use this for initialization
	void Start () {
		//AudioSource.PlayClipAtPoint (ngm,transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Fire(){
		int x = Random.Range (0, 4);
		switch (x) {
		case 0 :
			AudioSource.PlayClipAtPoint(ji,transform.position);
			break;
		case 1 :
			AudioSource.PlayClipAtPoint(chang,transform.position);
			break;
		case 2 :
			AudioSource.PlayClipAtPoint(tiao,transform.position);
			break;
		case 3 :
			AudioSource.PlayClipAtPoint(rap,transform.position);
			break;

		}
		this.animation.Play ("Monster_002_ji_Attack");

		Rigidbody pingA = Instantiate(pow1,transform.position, transform.rotation) as Rigidbody;
		pingA.name = "pingA";
		pingA.velocity = transform.forward * throwSpeed;
		//Physics.IgnoreCollision(transform.root.collider,pingA.collider, true);
		
		yield return new WaitForSeconds(2);
		Destroy (pingA.gameObject);
	}

	void skill1(){

	}
}
