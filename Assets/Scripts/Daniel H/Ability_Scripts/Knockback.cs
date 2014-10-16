using UnityEngine;
using System.Collections;

public class Knockback : AbilityBaseClass {

	public float Radius;
	public float KnockbackDistance;
	public int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Event.current.Equals(ButtonUsed)){
			TriggerAbility();
		}
	}

	void TriggerAbility(){
	}
}
