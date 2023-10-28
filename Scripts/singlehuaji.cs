using UnityEngine;
using System.Collections;

public class singlehuaji : MonoBehaviour {
	public bool isattack = false ; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Fire(){
		//print ("1");
		this.animation.Play("single");
		isattack = true;
		yield return new WaitForSeconds (2);
		isattack = false;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "qiangzombie" || col.gameObject.tag == "robot" || col.gameObject.tag == "dachuizombie") {
			col.SendMessage ("kouxue");
			col.SendMessage ("beinghit");
		}
		/*if (col.gameObject.tag == "robot" && isattack) {
			robothealth.heal -= 100;
			col.SendMessage ("beinghit");
			if (robothealth.heal <= 0) {
				col.SendMessage ("isdie");

				//Destroy(col.gameObject);
			}
		} else if (col.gameObject.tag == "qiangzombie" && isattack) {
			//print ("5");
			//qianghealty.heal -= 100;
			col.SendMessage ("beinghit");
		} else if (col.gameObject.tag == "dachuizombie" && isattack) {
			//print ("5");
			dachuihealty.heal -= 100;
			col.SendMessage ("beinghit");
			if (dachuihealty .heal <= 0) {
				col.SendMessage ("isdie");

			}
		}*/
	}

	IEnumerator xiaohui(Collider c){
		yield return new WaitForSeconds (3);
		Destroy (c.gameObject);
	}
}
