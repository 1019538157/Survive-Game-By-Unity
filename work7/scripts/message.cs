using UnityEngine;
using System.Collections;

public class message : MonoBehaviour {

	float duration = 2.0f;
	float startSize =50.0f;
	float endSize = 100.0f;
	float timer = 0.0f;
	bool isShowing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isShowing) {
			timer += Time.fixedDeltaTime;
			if (timer > duration) {
				guiText.enabled = false;
				isShowing = false;
				timer = 0.0f;
			} else {
				float t = timer / duration;
				float size = Mathf.Lerp (startSize, endSize, t);
				guiText.fontSize = (int)size;
			}
		}
	}

	public void ShowHint(string text){
		if (isShowing) {
			guiText.enabled = false;
			isShowing = false;
			timer = 0.0f;
		}
		guiText.fontSize = 50;
		guiText.text = text;
		guiText.enabled = true;
		isShowing = true;
	}

}
