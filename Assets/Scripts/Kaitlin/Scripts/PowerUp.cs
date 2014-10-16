using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour 
{

	public int powerUpCount = 0;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (powerUpCount >= 3)
		{
			powerUpCount = 3;
			Debug.Log ("Can't pick up anymore!");
		}
	}

	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width - 150, Screen.height - 40, 140, 30), "Power Up Count: " + powerUpCount);
	}

	void PowerUpPickUp(int addPower)
	{
		powerUpCount += 1;
		Debug.Log ("Received Power Up");
	}
}
