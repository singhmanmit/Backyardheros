using UnityEngine;
using System.Collections;

public class RotatingPickUp : MonoBehaviour 
{
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(Vector3.up * Time.deltaTime * 20);
		transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.Sin (Time.time) * 0.015625f), transform.position.z);
	}
}
