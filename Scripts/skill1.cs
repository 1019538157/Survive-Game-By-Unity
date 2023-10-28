using UnityEngine;
using System.Collections;

public class skill1 : MonoBehaviour {
	
	public GameObject lei1;
	public GameObject lei2;
	float x,z;
	float roa;
	public AudioClip jian;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator skill(){
		for (int j = 0; j<5; j++) {
			
			AudioSource.PlayClipAtPoint(jian,transform.position);
			for (int i = 0; i<20; i++) {
				//normal
				x = Random.Range (transform.position.x - 25, transform.position.x + 25);
				z = Random.Range (transform.position.z - 25, transform.position.z + 25);
				roa = Random.Range (0, 360);
				Instantiate (lei1, new Vector3 (x, transform.position.y - 2, z),transform.rotation);
			}
			for (int i = 0; i<40; i++) {
				//paxing
				x = Random.Range (transform.position.x - 25, transform.position.x + 25);
				z = Random.Range (transform.position.z - 25, transform.position.z + 25);
				roa = Random.Range (0, 360);
				Instantiate (lei2, new Vector3 (x, transform.position.y - 2, z),transform.rotation);
			
			}
			yield return new WaitForSeconds(1);
		}
	}

}
