using UnityEngine;
using System.Collections;

public class IceArrow : AbilityBaseClass {

	public float TimeSlowMultiplier = 0.50f;
	public float Speed = 3000;
	public int damage = 10;
	public GameObject ProjectileObject;
	GameObject projectile = null;
	public ProjectilePosition ProjectileScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(TimeLeftOnCD>0){
			TimeLeftOnCD-=Time.deltaTime;
		}
		else{
			if(Input.GetKey(ButtonUsed)){
				if(TimeLeftOnCD<=0){
					TriggerAbility();
				}
			}
		}
	}

	void TriggerAbility(){
		projectile = GameObject.Instantiate(ProjectileObject,ProjectileScript.GrabPosition(),transform.rotation) as GameObject;
		projectile.rigidbody.AddForce(projectile.rigidbody.transform.forward*Speed);
		TimeLeftOnCD=Cooldown;


	}

}
