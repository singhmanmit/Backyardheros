using UnityEngine;
using System.Collections;

public class EnemyTaging : MonoBehaviour {

	public int tag;


	void Update() {

		//Debug.Log("ENEMY TAG: " + tag);
	}

//	void OnTriggerEnter (Collider other) {
//
//		if ( other.gameObject.tag == "tower") {
//
//			tag = other.gameObject.GetComponent<TowerAI>().Tagging;
////			tag = TowerAI.Tagging;
//			Debug.Log("ENEMY TAG: " + tag);
//		}
//	}
}
