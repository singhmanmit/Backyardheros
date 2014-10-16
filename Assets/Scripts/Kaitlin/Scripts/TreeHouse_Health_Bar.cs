using UnityEngine;
using System.Collections;

public class TreeHouse_Health_Bar : MonoBehaviour 
{
	public float max_Treehouse_Health; //max health for Treehouse
	public float current_Treehouse_Health; //current health for Player
	public float hpBarLength; //Treehouse's bar length
	public Texture2D TreeHouse; //place treehouse icon texture into inspector
	public Texture2D Branch; //place branch texture into inspector

	// Use this for initialization
	void Start () 
	{
		max_Treehouse_Health = 100.0f;
		current_Treehouse_Health = 100.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		hpBarLength = (current_Treehouse_Health / max_Treehouse_Health) * 225.0f;
		if (current_Treehouse_Health >= max_Treehouse_Health)
		{
			current_Treehouse_Health = max_Treehouse_Health;
		}
		if(current_Treehouse_Health <= 0.0f)
		{
			current_Treehouse_Health = 0.0f;
		}
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect((Screen.width - 350), 60, hpBarLength, 17), Branch);
		GUI.DrawTexture(new Rect((Screen.width - 140), 28, 120, 120), TreeHouse);
	}
}
