using UnityEngine;
using System.Collections;

public class jingyan : MonoBehaviour {

	public GUIText coin;
	public int jing = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setjing(int x){
		jing += x;
	}
}
