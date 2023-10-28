using UnityEngine;
using System.Collections;

public class pingA : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "qiangzombie" || col.gameObject.tag == "robot" || col.gameObject.tag == "dachuizombie") {
			col.SendMessage ("kouxue");
			col.SendMessage ("beinghit");
		}
		/*if (col.gameObject.tag == "robot") {
			robothealth.heal -= 50;
			col.SendMessage ("beinghit");
			if (robothealth.heal <= 0) {
				col.SendMessage ("isdie");

				//Destroy(col.gameObject);
			}
		} else if (col.gameObject.tag == "qiangzombie") {
			//print("5");
			//qianghealty.heal -= 50;
			col.SendMessage("kouxue");
			col.SendMessage ("beinghit");
		}else if (col.gameObject.tag == "dachuizombie") {
			//print ("5");
			dachuihealty.heal -= 50;
			print (dachuihealty.heal);
			col.SendMessage ("beinghit");
			if (dachuihealty .heal <= 0) {
				col.SendMessage ("isdie");

			}
		}*/
	}

	IEnumerator xiaohui(Collider c){
		print ("4");
		yield return new WaitForSeconds (3);
		Destroy (c.gameObject);
	}
}
