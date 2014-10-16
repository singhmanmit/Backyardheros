using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour
{
	
	//**************************************************
	//I switched off the Unity WaterMark because it didn't sit in the middle of the screen so it was a little misleading.
	//**************************************************
	
	private int cursorWidth = 32;
	private int cursorHeight = 32;
	public Texture2D cursorImage;

	//this is the text for the white reticle, the static one
	public Texture2D centerText;

	public Texture2D testImage;
	
	void Start()
	{
		Screen.showCursor = false;
	}
	
	void OnGUI()
	{
		//I subtracted half the cursor width and height so the image center sits directly where the mouse pointer is. 
		GUI.DrawTexture(new Rect(Input.mousePosition.x - cursorWidth / 2, (Screen.height - Input.mousePosition.y) - cursorHeight / 2, cursorWidth, cursorHeight), cursorImage);
		
		//this is so the white reticle sits directly in the center screen
		//subtracter half the width and height again for the same reason
		GUI.DrawTexture(new Rect(Screen.width / 2 -37.5f, Screen.height / 2 -37.5f , 75, 75), centerText);

	}

	void OnMouseEnter() {

//		guiTexture.texture = testImage;
		Debug.Log ("ON MOUSE ENTER");
	}

}

/*

var normalTex : Texture2D;
var hoverTex : Texture2D;
 
function OnMouseEnter () {
 guiTexture.texture = hoverTex;
}
 
function OnMouseExit(){
 guiTexture.texture = normalTex;
}
 
function OnMouseDown(){
 Debug.Log("clicked");
}

 */