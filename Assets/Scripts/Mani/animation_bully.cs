using UnityEngine;
using System.Collections;

public class animation_bully : MonoBehaviour {

	Transform target;
	State currentState;

	public float speed = 5.0f;
	//public float health = 10;

	private SphereCollider chaseRadius;

	IEnumerator death(float sec) {
		animation.CrossFade("death");
		yield return new WaitForSeconds(sec);
		Destroy (this.gameObject);
		
		
	}
	
	public enum State {
		idle,
		run,
		death
	};

	void Start () {
		chaseRadius = gameObject.GetComponent<SphereCollider> ();
		chaseRadius.radius = 5.0f;

		animation.wrapMode =WrapMode.Loop;
		animation["idle"].wrapMode=WrapMode.Clamp;
		animation["run"].wrapMode=WrapMode.Clamp;
		animation["death"].wrapMode=WrapMode.Clamp;
	}
	
	void Update () {

		//if (health > 0f) {
		//	death(3f);
		//}
		
		if (target != null) {

				if (currentState == State.run) {
						animation.Play ("run");
						Vector3 direction = target.transform.position - transform.position;
						direction.y = 0.0f;
		
						transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (direction),Time.deltaTime);
						this.gameObject.rigidbody.velocity = direction.normalized * speed;
				}
			} 

		else {
					animation.CrossFade ("idle");
					this.gameObject.rigidbody.velocity = Vector3.zero;
				}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "bullet") {
		//	health = 0;		
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			print ("hit player");
			target = other.gameObject.transform; 
			currentState = State.run;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			target = null;
			currentState = State.idle;
		}
	}
}

