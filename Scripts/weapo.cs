using UnityEngine;
using System.Collections;

public class weapo : MonoBehaviour {
	public GameObject skill ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			selectweapon (0);
		} else if (Input.GetKeyDown ("2")) {
			selectweapon (1);
		} else if (Input.GetButtonDown ("Fire1")) {
			BroadcastMessage ("Fire");
		} else if (Input.GetKeyDown (KeyCode.Mouse1)) {
			skill.SendMessage ("skill");
		}else if(Input.GetKeyDown(KeyCode.Escape)){
			if(Time.timeScale != 0){
				Time.timeScale = 0;
			}else{
				Time.timeScale = 1;
			}
		}
	}
	void selectweapon(int selectinput){
		for (int i=0; i<this.transform.childCount; i++) {
			if (i == selectinput){
				this.transform.GetChild(i).gameObject.SetActive(true);
			}else{
				this.transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
}
