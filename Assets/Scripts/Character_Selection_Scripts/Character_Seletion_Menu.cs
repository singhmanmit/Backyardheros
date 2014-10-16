using UnityEngine;
using System.Collections;

public class Character_Seletion_Menu : MonoBehaviour {
	
	public string CH01name = "Ranger";
	public string CH02name = "Brawler";
	public string CH03name = "Rogue";
	public Player_Spawn Spawn_Point;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Box(new Rect(Screen.width/12,(Screen.height/3)*2, (Screen.width/6)*5, Screen.height/3), "Select a character");
		if(GUI.Button(new Rect((Screen.width/12)+10,((Screen.height/4)*3)+10, (Screen.width/6), Screen.height/6),CH01name)){
			Spawn_Point.SelectCharatcer(0);
		}
		GUI.enabled = false;
		if(GUI.Button(new Rect((Screen.width/2)-(Screen.width/12),((Screen.height/4)*3)+10, (Screen.width/6), Screen.height/6),CH02name)){
			Spawn_Point.SelectCharatcer(1);
		}
		if(GUI.Button(new Rect(((Screen.width/12)*9-10),((Screen.height/4)*3)+10, (Screen.width/6), Screen.height/6),CH03name)){
			Spawn_Point.SelectCharatcer(2);
		}
	}


}
