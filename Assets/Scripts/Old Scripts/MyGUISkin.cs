using UnityEngine;
using System.Collections;

public class MyGUISkin : MonoBehaviour {

	public GUISkin MenuSkin;
	public bool toggleTxt;
	public int toolbarInt = 0;
	public string[] toolbarStrings = new string[] {"Toolbar1", "Toolbar2", "Toolbar3"};
	public int selGridInt = 0;
	public string[] selStrings = new string[] {"Grid1","Grid2","Grid3","Grid4"};
	public float hSliderValue = 0.0f;
	public float hSbarValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUI.skin = MenuSkin;
		GUI.BeginGroup(new Rect(Screen.width/2-150,Screen.height/2-150,300,300));
		GUI.Box (new Rect(0,0,300,300),"This is the title of a box");
		GUI.Button (new Rect(0,25,100,20), "I am a button");
		GUI.Label (new Rect (0, 50, 100, 20), "I'm a Label!");
		toggleTxt = GUI.Toggle(new Rect(0, 75, 200, 30), toggleTxt, "I am a Toggle button");
		toolbarInt = GUI.Toolbar (new Rect (0, 110, 250, 25), toolbarInt, toolbarStrings);
		selGridInt = GUI.SelectionGrid (new Rect (0, 160, 200, 40), selGridInt, selStrings, 2);
		hSliderValue = GUI.HorizontalSlider (new Rect (0, 210, 100, 30), hSliderValue, 0.0f, 1.0f);
		hSbarValue = GUI.HorizontalScrollbar (new Rect (0, 230, 100, 30), hSbarValue, 1.0f, 0.0f, 10.0f);
		GUI.EndGroup ();
	}
}


//function OnGUI() {
//	
//	GUI.skin = MenuSkin;
//	
//	GUI.BeginGroup(new Rect(Screen.width/2-150,Screen.height/2-150,300,300));
//	
//	GUI.Box(Rect(0,0,300,300),"This is the title of a box");
//	
//	GUI.Button(Rect(0,25,100,20),"I am a button");
//	
//	GUI.Label (Rect (0, 50, 100, 20), "I'm a Label!");
//	
//	toggleTxt = GUI.Toggle(Rect(0, 75, 200, 30), toggleTxt, "I am a Toggle button");
//	
//	toolbarInt = GUI.Toolbar (Rect (0, 110, 250, 25), toolbarInt, toolbarStrings);
//	
//	selGridInt = GUI.SelectionGrid (Rect (0, 160, 200, 40), selGridInt, selStrings, 2);
//	
//	hSliderValue = GUI.HorizontalSlider (Rect (0, 210, 100, 30), hSliderValue, 0.0, 1.0);
//	
//	hSbarValue = GUI.HorizontalScrollbar (Rect (0, 230, 100, 30), hSbarValue, 1.0, 0.0, 10.0);
//	
//	GUI.EndGroup ();
//	
//}