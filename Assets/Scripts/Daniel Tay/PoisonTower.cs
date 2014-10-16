using UnityEngine;
using System.Collections.Generic;

public class PoisonTower : MonoBehaviour {

	public void Start(){

	}

	public void Update(){

	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "enemy") {
		

		}
	}
}
