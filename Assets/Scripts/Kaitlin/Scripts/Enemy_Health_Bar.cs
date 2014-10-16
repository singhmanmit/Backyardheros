using UnityEngine;
using System.Collections.Generic;

public class Enemy_Health_Bar : MonoBehaviour 
{

	public float Enemy_Health;
	public float Max_Enemy_Health;
	public Texture2D HpBarTexture;
	private float hpBarLength;
	private float scale = 12.5f;
	public int tagNumber;
	List<GameObject> myList= new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		Enemy_Health = 100.0f;
		Max_Enemy_Health = 100.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		hpBarLength = (Enemy_Health/Max_Enemy_Health) * 100.0f;
		if(Enemy_Health <= 0) 
		{
			//	Dani Start
			for (int i=0; i < myList.Count; i++) {
				myList[i].GetComponent<tower2>().EnemyDead(tagNumber);
			}
			//	Dani End
			
			Destroy(this.gameObject);
		}
	}

	//Drawing the healthbar over the enemies
	void OnGUI()
	{
		if (Enemy_Health > 0)
		{
			Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0.0f,1.5f,0.0f));
			float dist = (this.transform.position-Camera.main.transform.position).magnitude;
			GUI.DrawTexture(new Rect(pos.x-(hpBarLength*((1/dist)*scale)/2),((Screen.height-pos.y)+((1/dist))),hpBarLength*((1/dist)*scale),10*((1/dist)*scale)),HpBarTexture);
		}

	}

	//Calculating the damage that the enemies take from the bullet
	void TakeDamage(float bulletDamage)
	{
		Enemy_Health -= bulletDamage;
		Debug.Log (Enemy_Health);
		if (Enemy_Health <= 0)
		{
			Destroy(gameObject);
		}
	}

	void FireTrap(float fire)
	{
		Enemy_Health -= fire;
		Debug.Log("Fire Damage");
	}

	void IceTrap(float ice)
	{
		Enemy_Health -= ice;
		Debug.Log("Fire Damage");
	}

	void MeleeTrap(float melee)
	{
		Enemy_Health -= melee;
		Debug.Log("Fire Damage");
	}

	void OnTriggerEnter(Collider collision) {
		
		if(collision.gameObject.tag == "tower") {
			
			myList.Add(collision.gameObject);
		}
		//	Dani End
	}
}
