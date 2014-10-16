using UnityEngine;
using System.Collections;

public class animations_script : MonoBehaviour {

	AnimationState idle;
	AnimationState run;
	AnimationState backwards;
	AnimationState r_strafe;
	AnimationState l_strafe;
	AnimationState jump;
	AnimationState shoot;

	void Start () {
		animation.wrapMode =WrapMode.Loop;
		
		idle = animation["idle"];
		idle.wrapMode = WrapMode.Clamp;

		run = animation["run"];
		run.wrapMode = WrapMode.Clamp;

		backwards = animation["backwarks"];
		backwards.wrapMode = WrapMode.Clamp;

		r_strafe = animation["r_strafe"];
		r_strafe.wrapMode = WrapMode.Clamp;

		l_strafe = animation["l_strafe"];
		l_strafe.wrapMode = WrapMode.Clamp;

		jump = animation["jump"];
		jump.wrapMode = WrapMode.Clamp;

		shoot = animation["shoot"];
		shoot.wrapMode = WrapMode.Clamp;
	}

	void Update () {
		if (Input.GetMouseButton (0)) {
			//shoot.speed = 2f;
			animation.CrossFade("shoot");
		
		}else if(Input.GetKey (KeyCode.Space)){
			//jump.speed = .755f;
			animation.CrossFade ("jump");
		
		}else if(Input.GetKey (KeyCode.A)){
			animation.CrossFade ("r_strafe");
		
		}else if(Input.GetKey (KeyCode.D)){
			animation.CrossFade ("l_strafe");
		
		}else if(Input.GetKey (KeyCode.S)){
			animation.CrossFade ("backward");
		
		}else if(Input.GetKey (KeyCode.W)){
			animation.CrossFade ("run");
		
		}else{
			animation.CrossFade("idle");
		}
	}
}