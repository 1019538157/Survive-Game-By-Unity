using UnityEngine;
using System.Collections;

public class robothealth : MonoBehaviour {

	public int heal = 300;
	public AudioClip att;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (heal <= 0) {
			this.SendMessage ("isdie");
		}
	}

	void beingattack(){
		playerhealth.health -=50;
		AudioSource.PlayClipAtPoint(att,transform.position);
	}
	void kouxue(){
		heal -= 50;
	}

	void huajikou(){
		heal -= 100;
	}
	/*void OnTriggerEnter(Collider col){
		print ("1");
		if (col.gameObject.tag == "huaji") {
			print ("2");
			heal-=50;
			if(heal <= 0){
				Destroy(this.gameObject);
			}
		}
	}*/
}
