using UnityEngine;
using System.Collections;

public class mm : MonoBehaviour {

	public int x;
	// Use this for initialization
	IEnumerator Start () {
		for (int i = 0; i<=25; i++) {
			x = Random.Range (0, 25);
			switch (x) {
			case 0:
				this.animation.Play("Clip_01");
				break;
			case 1:
				this.animation.Play("Clip_02");
				break;
			case 2:
				this.animation.Play("Clip_03");
				break;
			case 3:
				this.animation.Play("Clip_04");
				break;
			case 4:
				this.animation.Play("Clip_05");
				break;
			case 5:
				this.animation.Play("Clip_06");
				break;
			case 6:
				this.animation.Play("Clip_07");
				break;
			case 7:
				this.animation.Play("Clip_08");
				break;
			case 8:
				this.animation.Play("Clip_09");
				break;
			case 9:
				this.animation.Play("Clip_10");
				break;
			case 10:
				this.animation.Play("Clip_11");
				break;
			case 11:
				this.animation.Play("Clip_12");
				break;
			case 12:
				this.animation.Play("Clip_13");
				break;
			case 13:
				this.animation.Play("Clip_14");
				break;
			case 14:
				this.animation.Play("Clip_15");
				break;
			case 15:
				this.animation.Play("Clip_16");
				break;
			case 16:
				this.animation.Play("Clip_17");
				break;
			case 17:
				this.animation.Play("Clip_18");
				break;
			case 18:
				this.animation.Play("Clip_19");
				break;
			case 19:
				this.animation.Play("Clip_20");
				break;
			case 20:
				this.animation.Play("Clip_21");
				break;
			case 21:
				this.animation.Play("Clip_22");
				break;
			case 22:
				this.animation.Play("Clip_23");
				break;
			case 23:
				this.animation.Play("Clip_24");
				break;
			case 24:
				this.animation.Play("Clip_25");
				break;
			case 25:
				this.animation.Play("Clip_26");
				break;
			default:
				break;
			}
			yield return new WaitForSeconds (10);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
