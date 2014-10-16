using UnityEngine;
using System.Collections;

public class IAProjectileScript : MonoBehaviour {

	float delay = 0.2f;

	// Use this for initialization
	void Start () {
		Physics.IgnoreCollision (GameObject.FindGameObjectWithTag("Player").collider,gameObject.collider);
	}
	
	// Update is called once per frame
	void Update () {
		delay-=Time.deltaTime;
	}

	void OnCollisionEnter(Collision hit){
		if(delay<=0){
			if (hit.gameObject.tag!="player"){
				Destroy(gameObject);
				//Debug.Log("Collided");
			}
		}
	}
}
