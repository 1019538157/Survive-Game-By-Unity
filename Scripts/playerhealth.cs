using UnityEngine;
using System.Collections;

public class playerhealth : MonoBehaviour {

	public static int health = 1000;
	public GUIText show;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		healthchange ();
		if (health <= 0) {
			//Time.timeScale = 0;
			Time.timeScale = 0;
			show.text = "你死了！即将退回主菜单";
			Application.LoadLevel ("menu");
		}
	}

	void healthchange(){
		show.text = health.ToString() ;
	}


}
