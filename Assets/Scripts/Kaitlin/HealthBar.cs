using UnityEngine;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour {
	
	public static float curHp = 5.0f;
	public static float maxHp = 300.0f;
	public Texture2D HpBarTexture;
	private float hpBarLength;
	private float percentOfHp;

	public float health = 5.0f;
	private float dmgPercent;
	private float dmg;

	public float scale = 50;

	// Dani Start
	public int tagNumber;
	List<GameObject> myList= new List<GameObject>();
	// Dani End

	void Start() {

		hpBarLength = 100.0f;
		percentOfHp = 100.0f;
	}

	void OnGUI () 
	{
		if(gameObject.tag == "enemy")
		{
			if (curHp > 0)
			{
				Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0.0f,-10.0f,0.0f));
				float dist = (this.transform.position-Camera.main.transform.position).magnitude;
				GUI.DrawTexture(new Rect(pos.x-((hpBarLength*(percentOfHp/100))*((1/dist)*scale)/2),((Screen.height-pos.y))-(150*((1/dist)*scale)),(hpBarLength*(percentOfHp/100))*((1/dist)*scale),10*((1/dist)*scale)),HpBarTexture);
			}
		}
	}
	
	void Update () {
		if (health == 0) {

			percentOfHp = 0;
		}

		if(percentOfHp <= 0)
		{
			//Debug.Log("NO MORE HEALTH");
			//	Dani Start
			for (int i=0; i < myList.Count; i++) {
				myList[i].GetComponent<towerScript>().EnemyDead(tagNumber);
			}

			Destroy(this.gameObject);
		}
	}

	void HealthToPercentage() {

		// health value "5" = percentOfHP "100"
		// 1hp = ?%
		health = health - dmg;
		dmgPercent = (dmg * percentOfHp) / health;
	}

	//	Dani Start
	/*	NOTES:
	// Tag for the collision of bullets changed from "enemydamage" to "damage" */
	void OnTriggerEnter(Collider collision) {

		if(collision.gameObject.tag == "damage")
		{
			// get damage value from bullet
			dmg = collision.gameObject.GetComponent<BulletScript>().damage;
			HealthToPercentage();
			// substract percentOfHp by the damage value
			percentOfHp -= dmgPercent;
		}

		if(collision.gameObject.tag == "damageMissile")
		{
			// get damage value from bullet
			dmg = collision.gameObject.GetComponent<HomingMissile>().damage;
			HealthToPercentage();
			// substract percentOfHp by the damage value
			percentOfHp -= dmgPercent;
		}

		if(collision.gameObject.tag == "laserTower") {

			//Debug.Log("enemy inside of tower");
			myList.Add(collision.gameObject);
		}

		if(collision.gameObject.tag == "rocketTower") {
			
			//Debug.Log("enemy inside of tower");
			myList.Add(collision.gameObject);
		}
		//	Dani End
	}
}
