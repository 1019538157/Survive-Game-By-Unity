using UnityEngine;
using System.Collections;

public class TargetCollision : MonoBehaviour {

	bool beenHit = false;
	Animation targetRoot;
	public AudioClip hitSound;
	public AudioClip resetSound;
	public float resetTime = 3.0f;

	public GUITexture coinn;
	public GUIText score;
	public GUIText message;

	// Use this for initialization
	void Start () {
		targetRoot = transform.parent.transform.parent.animation;
	}
	void OnCollisionEnter(Collision col) {
		if (beenHit == false && col.gameObject.tag == "Coconut") {
			StartCoroutine("targetHit");
			HUDon ();
			score.text = coin.num.ToString ();
			message.SendMessage ("ShowHint", coin.num.ToString ());
			}
		}

	IEnumerator targetHit() {
		audio.PlayOneShot (hitSound);
		targetRoot.Play ("down");
		beenHit = true;
		coin.num++;
			yield return new WaitForSeconds(resetTime);

			audio.PlayOneShot (resetSound);
		targetRoot.Play ("up");
		beenHit = false;
		}
	// Update is called once per frame
	void Update () {
	
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
