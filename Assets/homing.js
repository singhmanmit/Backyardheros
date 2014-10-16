//#pragma strict
//var fuseDelay: float; //delay we'll use before the force is applied to it
//var missileForce : int;
//var turn : float;
//var smokePrefab : ParticleSystem;
//var missileMod : Transform;
// 
//function FixedUpdate ()
// 
//{
// 
//GuidanceSystem();
// 
//}
// 
//function GuidanceSystem ()
// 
//{
// 
//	yield WaitForSeconds(fuseDelay);
//	rigidbody.isKinematic = true;
//	var targets : GameObject[] = GameObject.FindGameObjectsWithTag("target");
//	var closestDist = Mathf.Infinity;
//	var closest : GameObject;
//
//	for (Target in targets) {
//		var dist = (transform.position - Target.transform.position).sqrMagnitude;
//		 
//		if(dist < closestDist)
//		{
//			closestDist = dist;
//			closest = Target;
//		}
//	 
//	}
//	transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(closest.transform.position-transform.position), turn * Time.deltaTime);
//	transform.position += transform.forward * missileForce * Time.deltaTime;
//	 
//}
// 
//function OnCollisionEnter(theCollision : Collision)
//{
//	if(theCollision.gameObject.name == "Cube")
//{
// 
//smokePrefab.emissionRate = 0.0f;
//Destroy(missileMod.gameObject);
// 
//}
//}