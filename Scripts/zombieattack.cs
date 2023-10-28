using UnityEngine;
using System.Collections;

public class zombieattack : MonoBehaviour {
	
	public static bool isattack = false ; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static IEnumerator canattack (){
		if (isattack == false) {
			isattack = true;
		} else {
			yield return new WaitForSeconds(2);
			isattack = false;
		}
	}
}
