using UnityEngine;
using System.Collections;

public class shuaguai : MonoBehaviour {
	public GameObject normalzombie;
	public GameObject paxing;
	public GameObject qiang;
	public GameObject dachui;

	public GUIText tishi;
	public bool isbegin = false;
	int t = ((int)(Time.time/90)+1);
	int t2 = 0;
	float x,z;
	// Use this for initialization
	void Start () {
		//while (true) {

			//yield return portal();
		//}
	}
	
	// Update is called once per frame
	void Update () {
		print (t);
		if (isbegin == true){
			//print ("1");
			t = ((int)(Time.time/45)+1);
			if (t2!=t){

				for(int i = 0;i<t*5;i++){
					//normal
					x = Random.Range(transform.position.x-75,transform.position.x+75);
					z = Random.Range(transform.position.z-75,transform.position.z+75);
					Instantiate (normalzombie, new Vector3 (x, transform.position.y+20, z), transform.rotation);
				}
				for(int i = 0;i<t*10;i++){
					//paxing
					x = Random.Range(transform.position.x-75,transform.position.x+75);
					z = Random.Range(transform.position.z-75,transform.position.z+75);
					Instantiate (paxing, new Vector3 (x, transform.position.y+20, z), transform.rotation);

				}
				for(int i = 0;i<t*2;i++){
					//qiang
					x = Random.Range(transform.position.x-100,transform.position.x+100);
					z = Random.Range(transform.position.z-100,transform.position.z+100);
					Instantiate (qiang, new Vector3 (x, transform.position.y+40, z), transform.rotation);

				}
				if (t>=2){
					for(int i = 0;i<t;i++){
						//dachui
						x = Random.Range(transform.position.x-100,transform.position.x+100);
						z = Random.Range(transform.position.z-100,transform.position.z+100);
						Instantiate (dachui , new Vector3 (x, transform.position.y+75, z), transform.rotation);

					}
				}
				t2 =t;
			}
		}
	}

	IEnumerator sh(){
		tishi.enabled = true;
		tishi.text = "新的一波魔物到来！";
		yield return new WaitForSeconds (2);
		tishi.enabled = false;
	}

	IEnumerator portal(){
		while (true) {
			if (isbegin == true){
				print ("1");
				t = ((int)(Time.time%120)+1);
				if (t2!=t){
					for(int i = 0;i<t*10;i++){
						//normal
						x = Random.Range(transform.position.x-50,transform.position.x+50);
						z = Random.Range(transform.position.z-50,transform.position.z+50);
						Instantiate (normalzombie, new Vector3 (x, transform.position.y+20, z), transform.rotation);
					}
					for(int i = 0;i<t*20;i++){
						;//paxing
					}
					for(int i = 0;i<t*2;i++){
						;//qiang
					}
					if (t>=2){
						for(int i = 0;i<t;i++){
							;//dachui
						}
					}
					t2 =t;
				}else {
					yield break;
				}
			}else{
				yield break; 
			}
		}
	}

	public void gamebegin(){
		isbegin = true;
		print ("2");
	}
}
