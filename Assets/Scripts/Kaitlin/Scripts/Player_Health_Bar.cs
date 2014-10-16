using UnityEngine;
using System.Collections;

public class Player_Health_Bar : MonoBehaviour 
{
	public float max_player_Health; //max health for player
	public float current_player_Health; //current health for player
	public float hpBarLength; //player's bar length
	public Texture2D Character; //place character icon texture into inspector
	public Texture2D PowerUp; //place lolllipop texture into inspector
	public Texture2D Crayon; //place crayon texture into inspector
	
	// Use this for initialization
	void Start () 
	{
		max_player_Health = 100.0f; //setting the player's max health number
		current_player_Health = 50.0f; //setting the current player's health number
	}
	
	// Update is called once per frame
	void Update () 
	{
		hpBarLength = (current_player_Health / max_player_Health) * 225.0f;
		if (current_player_Health >= max_player_Health)
		{
			current_player_Health = max_player_Health;
		}
		if(current_player_Health <= 0.0f)
		{
			current_player_Health = 0.0f;
		}
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(125, 60, hpBarLength, 17), Crayon);
		GUI.DrawTexture(new Rect(100, 100, 140, 90), PowerUp);
		GUI.DrawTexture(new Rect(20, 28, 120, 120), Character);
	}
	
	void HealthPickUp(float addHealth)
	{
		current_player_Health += addHealth;
		Debug.Log("Received Health");
	}
	
	void EnemyDamage(float subHealth)
	{
		current_player_Health -= subHealth;
		Debug.Log("Take Away Health");
	}
	
}