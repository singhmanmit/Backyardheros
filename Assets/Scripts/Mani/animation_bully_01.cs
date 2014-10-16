using UnityEngine;
using System.Collections;

public class animation_bully_01 : MonoBehaviour {

	public GameObject gameobject;

	void Start () {
		animation.wrapMode =WrapMode.Loop;
		
		animation["idle"].wrapMode=WrapMode.Clamp;
		animation["chase"].wrapMode=WrapMode.Clamp;
	}
	
	void Update () {

		//GameObject gameobject = GameObject.Find("Enemy");
		//EnemyHealthBar enemyHealthBar = gameobject.GetComponent<EnemyHealthBar>();

		//animation.CrossFade("idle");
		//print("idle");
		
		if (gameobject)
		animation.CrossFade ("chase");
		//if (enemyHealthBar.ifdead == 1) {
		//	animation.CrossFade ("death");
		//		}


	}
}
