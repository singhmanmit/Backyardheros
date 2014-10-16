using UnityEngine;
using System.Collections;

public class WinScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Box(new Rect((Screen.width/2)-70,(Screen.height/2)-15,140,30),"You WIN!!!");
	}
}
