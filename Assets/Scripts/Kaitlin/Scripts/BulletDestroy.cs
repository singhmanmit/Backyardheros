using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {
	void OnCollisionEnter()
	{
		Destroy(gameObject); 
	}
}
