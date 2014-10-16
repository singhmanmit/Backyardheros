using UnityEngine;
using System.Collections;

public class Traps : MonoBehaviour {
	private float resetTime = 3.0f;
	private bool trapActivation = true;
	public float fireDamage;
	public float iceDamage;
	public float meleeDamage;
	
	void Start(){
		this.renderer.material.color = Color.yellow;
		fireDamage = 10.0f;
		iceDamage = 7.0f;
		meleeDamage = 5.0f;

	}
	
	void Update(){

	}
	
	void Awake(){

	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "enemy" && trapActivation == true){
			if(this.gameObject.tag == "FIREtrap"){
				trapActivation = false;
				other.gameObject.SendMessage("FireTrap", fireDamage, SendMessageOptions.DontRequireReceiver);
				this.renderer.material.color = Color.red;
			}
			if(this.gameObject.tag == "ICEtrap"){
				trapActivation = false;
				other.gameObject.SendMessage("IceTrap", iceDamage, SendMessageOptions.DontRequireReceiver);
				this.renderer.material.color = Color.blue;
			}
			if(this.gameObject.tag == "MELEEtrap"){
				trapActivation = false;
				other.gameObject.SendMessage("MeleeTrap", meleeDamage, SendMessageOptions.DontRequireReceiver);
				this.renderer.material.color = Color.green;
			}
			StartCoroutine(Trap());
		}
	}

	IEnumerator Trap(){
		yield return new WaitForSeconds(resetTime);
		this.renderer.material.color = Color.black;
		trapActivation = true;
	}
}
