using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour {

	public GameObject target;
	public float autoDestroyAfter;
	public float damage ;
	public int missileForce;
	public float turn;

	// Use this for initialization
	void Start () {
	
		StartCoroutine (AutoExplode());
	}
	
	// Update is called once per frame
	void Update () {
	
		if (target != null) {

			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position-transform.position), turn * Time.deltaTime);
			transform.position += transform.forward * missileForce * Time.deltaTime;
		}

	}

	void OnTriggerEnter(Collider other) {
		//Damage the other gameobject &amp; then destroy self
		if (other.gameObject.tag == "enemy") {
			//ExplodeSelf ();
			other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
	
	private void ExplodeSelf () {
		Destroy(gameObject);
	}
	
	private IEnumerator AutoExplode() {
		yield return new WaitForSeconds (autoDestroyAfter);
		ExplodeSelf();
	}
}
