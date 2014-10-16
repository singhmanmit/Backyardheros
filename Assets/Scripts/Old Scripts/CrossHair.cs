using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour {


	public int speed = 10;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		this.transform.Rotate(Vector3.forward * (Time.deltaTime* speed));



	}
}
