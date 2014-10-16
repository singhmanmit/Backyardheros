using UnityEngine;
using System.Collections;

public class CameraRay : MonoBehaviour {

	public Transform cube;
	public float raycastDist;

	void Update() {

//		bool foundHit = false;
//
//		RaycastHit hit = new RaycastHit();
//
//		foundHit = Physics.Raycast (transform.position, transform.forward, out hit);
//
//		if (foundHit && !checkAllTags && hit.transform.tag != tagCheck )
//			foundHit = false;
//
//		if (foundHit = true)
//		{
//			cube.position = hit.point;
//			cube.rotation = Quaternion.LookRotation (hit.normal);
//		}

		Raycasting ();
	}

	void Raycasting() {

		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0.0f));
		Debug.DrawRay (ray.origin, ray.direction * 10, Color.cyan);
		RaycastHit hit;

		//if (Input.GetMouseButtonUp (0)) {

			if(Physics.Raycast(ray, out hit) == true)
			{

//				Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
//				Debug.Log("Ray hit a " + hit.transform.gameObject.tag);
			}

			cube.transform.position = hit.point;
			//cube.rotation = Quaternion.LookRotation (hit.normal);

		//}
	}
}
