using UnityEngine;
using System.Collections;

public class animation_archer : MonoBehaviour {
	
	AnimationState idle;
	AnimationState forward;
	AnimationState backward;
	AnimationState right;
	AnimationState left;
	AnimationState jump;
	AnimationState shoot;
	
	void Start () {
		animation.wrapMode =WrapMode.Loop;
		
		idle = animation["idle"];
		idle.wrapMode = WrapMode.Clamp;
		
		forward = animation["forward"];
		forward.wrapMode = WrapMode.Clamp;
		
		backward = animation["backward"];
		backward.wrapMode = WrapMode.Clamp;
		
		right = animation["right"];
		right.wrapMode = WrapMode.Clamp;
		
		left = animation["left"];
		left.wrapMode = WrapMode.Clamp;
		
		jump = animation["jump"];
		jump.wrapMode = WrapMode.Clamp;
		
		shoot = animation["shoot"];
		shoot.wrapMode = WrapMode.Clamp;
	}
	
	void Update () {

		if(Input.GetMouseButton (0) && Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.S)){
			animation.CrossFade("backward_left_shoot");

		}else if(Input.GetMouseButton (0) && Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.S)){
			animation.CrossFade("backward_right_shoot");

		}else if(Input.GetMouseButton (0) && Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.W)){
			animation.CrossFade("forward_left_shoot");

		}else if(Input.GetMouseButton (0) && Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.W)){
			animation.CrossFade("forward_right_shoot");

		}else if(Input.GetMouseButton (0) && Input.GetKey (KeyCode.A)){
			animation.CrossFade("left_shoot");

		}else if(Input.GetMouseButton (0) && Input.GetKey (KeyCode.D)){
			animation.CrossFade("right_shoot");

		}else if(Input.GetMouseButton (0) && Input.GetKey (KeyCode.S)){
			animation.CrossFade("backward_shoot");

		}else if(Input.GetMouseButton (0) && Input.GetKey (KeyCode.W)){
			animation.CrossFade("forward_shoot");

		}else if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.S)){
			animation.CrossFade("backward_right");

		}else if(Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.S)){
			animation.CrossFade("backward_left");

		}else if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.W)){
			animation.CrossFade("forward_left");

		}else if(Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.W)){
			animation.CrossFade("forward_right");

		}else if (Input.GetMouseButton (0)) {
			//shoot.speed = 2f;
			animation.CrossFade("shoot");
			
		}else if(Input.GetKey (KeyCode.Space)){
			//jump.speed = .755f;
			animation.CrossFade ("jump");
			
		}else if(Input.GetKey (KeyCode.A)){
			animation.CrossFade ("left");
			
		}else if(Input.GetKey (KeyCode.D)){
			animation.CrossFade ("right");
			
		}else if(Input.GetKey (KeyCode.S)){
			animation.CrossFade ("backward");
			
		}else if(Input.GetKey (KeyCode.W)){
			animation.CrossFade ("forward");
			
		}else{
			animation.CrossFade("idle");
		}
	}
}
