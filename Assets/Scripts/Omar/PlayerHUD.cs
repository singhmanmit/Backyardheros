using UnityEngine;
using System.Collections;

public class PlayerHUD : MonoBehaviour {
	

	public Texture btnTexture;

	public Texture btnTexture2;

	public Texture btnTexture3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	void OnGUI()
	{
		GUI.Box(new Rect(80,70,160,120),btnTexture3, GUIStyle.none);// Lollipop power ups
		GUI.Box(new Rect(100,50,250,40),btnTexture2, GUIStyle.none); // Crayon Health
		GUI.Box(new Rect(20,0,160,120),btnTexture, GUIStyle.none); // how to remove border in button ""GUIStyle.none" 
		//        ^^^^ (Pos X, pos Y, scale X, scale Y) ^^^^
	}



}