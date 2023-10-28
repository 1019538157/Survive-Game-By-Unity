using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {
	
	public AudioClip collectSound;
	public GUITexture coinn;
	public GUIText score;
	public GUIText message;
	public GameObject fact;
	public float rotationSpeed = 100.0f;
	public GameObject winObj;
	public static int num = 0;
	public static bool iswin = false;
	public GameObject invent;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, rotationSpeed * Time.deltaTime, 0));
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Coconut") {
			HUDon ();
			AudioSource.PlayClipAtPoint (collectSound,transform.position);
			num++;
			Fact.all --;

			if (Fact.all == 0) {
				float x, z;
				for (int i=0; i<10; i++) {
					x = Random.Range (900, 1005);
					z = Random.Range (900, 1005);
					Instantiate (fact, new Vector3 (x, 1, z), transform.rotation);
				}
			}

			if (num >= 100){
				if (iswin == false){
					winObj.SendMessage("GameOver");
					foreach(var mouseLook in invent.GetComponentsInChildren<MouseLook>()) 
						mouseLook.enabled = false; 
					foreach(var character in invent.GetComponentsInChildren<CharacterController>())
						character.enabled = false;
					//invent.GetComponent<MouseLook>().enabled = false;
					//invent.SendMessage("winwin");
					iswin = true;
				}
			}

			print(Fact.all);
			score.text = num.ToString ();
			message.SendMessage ("ShowHint", num.ToString ());
			Destroy (gameObject);
		}
	}
	void HUDon() {
		if (!coinn.enabled) {
			coinn.enabled = true;
		}
		if (!score.enabled){
			score.enabled = true;
		}
	}
}
