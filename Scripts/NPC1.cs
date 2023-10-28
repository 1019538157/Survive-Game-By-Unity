using UnityEngine;
using System.Collections;

public class NPC1 : MonoBehaviour {

	public GUIText tell;
	public GUITexture speakUI;
	public bool isdie = false;
	public GameObject normalzombie;
	public GameObject player;

	float x,z;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if (!isdie){
			this.animation.Play("Idle");
		}
	}

	IEnumerator OnTriggerEnter(Collider col) {
		//print("1");
		if (col.gameObject.tag == "Player") {
			if (!isdie){
				HUDON();
				isdie = true;
				this.animation.Play("Rest");
				for(int i = 0;i<5;i++){
					//normal
					x = Random.Range(transform.position.x-75,transform.position.x+75);
					z = Random.Range(transform.position.z-75,transform.position.z+75);
					Instantiate (normalzombie, new Vector3 (x, transform.position.y+20, z), transform.rotation);
				}
				tell.text = "师父：\n徒儿，为师为了抵御魔物身受重伤。。。\n已然命悬一线。。。";
				yield return new WaitForSeconds(3);
				tell.text = "师父：\n我的武器和法术全都托付给你，一定要逃离这个地方啊！\n你还记得武器的使用方式吧？\n使用数字键“1”、“2”切换武器和法术,右键使用法术";
				yield return new WaitForSeconds(5);
				tell.text = "师父：\n一定要。。。\n活下去。。。";
				this.animation.Play("Die");
				player.gameObject.SendMessage("gamebegin");
				//shuaguai.gamebegin();
				yield return new WaitForSeconds(3);
				HUDdown();
			}
		}
	}

	/*void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			this.animation.Play("Die");
			isdie = true;
			HUDdown();
		}
	}*/

	void HUDON(){
		if (!tell.enabled) {
			tell.enabled = true;
		}
		if (!speakUI.enabled) {
			//speakUI.enabled = true;
		}
	}

	void HUDdown(){
		if (tell.enabled) {
			tell.enabled = false;
		}
	}
}
