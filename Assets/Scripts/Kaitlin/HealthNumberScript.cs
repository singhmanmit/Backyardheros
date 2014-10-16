using UnityEngine;
using System.Collections;

public class HealthNumberScript : MonoBehaviour {
	public float maxHealth = 100;
	public float health;
	public float healthLostRate = 20.0f;
	
	void  Update (){
		if (health < 0) {
			Die();
		}
	}
	
	void  Awake (){
		health = maxHealth;
	}
	
	void  OnGUI (){
		GUI.Box ( new Rect(	200,200,150,30), "Player Health: " + Mathf.Round(health));
	}
	
	
	void  OnTriggerStay ( Collider collider  ){
		
		if (collider.tag == "damage") {
			health = health - (healthLostRate * Time.deltaTime);
		}
	}
	
	void  Die (){
		transform.position = new Vector3(0.0f, 1.0f, 0.0f);
		transform.rotation = Quaternion.Euler(0,180,0);
		health = maxHealth;
	}
}
