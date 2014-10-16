using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {



	
	public float speed = 7.0f;

	public float inertia = 150.0f;


	Vector3 counterForce;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	

		// MOVEMENT FOR A  ==================================================================



		if (Input.GetKey ("a")) {

			//this.rigidbody.velocity = this.transform.forward * speed;
			//this.rigidbody.velocity = Vector3.forward * speed;
			this.rigidbody.velocity = new Vector3(-speed,0.0f,0.0f);


		}


		if (Input.GetKeyUp ("a")) {

			this.rigidbody.AddForce(-inertia,0.0f,0.0f);
		}






		// MOVEMENT FOR D =======================================================================

		if (Input.GetKey ("d")) {

			this.rigidbody.velocity = new Vector3(speed,0.0f,0.0f);

			//this.rigidbody.velocity = -Vector3.forward * speed;
		}




		if (Input.GetKeyUp ("d")) {
			
			this.rigidbody.AddForce(inertia,0.0f,0.0f);
		}






		// MOVEMENT FOR W =========================================================================

		if (Input.GetKey ("w")) {

			//this.rigidbody.velocity = new Vector3(0.0f,0.0f,speed);

			this.rigidbody.velocity = Vector3.forward * speed;

		}


		if (Input.GetKeyUp ("w")) {
			
			this.rigidbody.AddForce(0.0f,0.0f,inertia);
		}






		// MOVEMENT FOR S ==========================================================================
		if (Input.GetKey ("s")) {

			this.rigidbody.velocity = new Vector3(0.0f,0.0f,-speed);
		}


		if (Input.GetKeyUp ("s")) {
			
			this.rigidbody.AddForce(0.0f,0.0f,-inertia);
		}








		// MOVEMENT COMBOS A AND W ==========================================================

		if (Input.GetKey ("a") && Input.GetKey ("w")) {

			this.rigidbody.velocity = new Vector3(-speed,0.0f,speed);


		}







		//MOVEMENT COMBOS A AND S ===============================================================

		if (Input.GetKey ("a") && Input.GetKey ("s")) {

			this.rigidbody.velocity = new Vector3(-speed, 0.0f, -speed);
		}








		//MOVEMENT COMBOS D AND W ===============================================================
		
		if (Input.GetKey ("d") && Input.GetKey ("w")) {
			
			this.rigidbody.velocity = new Vector3(speed, 0.0f, speed);
		}






		//MOVEMENT COMBOS D AND S ===============================================================
		
		if (Input.GetKey ("d") && Input.GetKey ("s")) {
			
			this.rigidbody.velocity = new Vector3(speed, 0.0f, -speed);
		}










		if (Input.GetKeyUp ("a") || Input.GetKeyUp ("s") || Input.GetKeyUp ("w") || Input.GetKeyUp ("d")) {

			this.rigidbody.velocity = new Vector3(0.0f,0.0f,0.0f);

		}


		//print (this.rigidbody.velocity);

	}
}
