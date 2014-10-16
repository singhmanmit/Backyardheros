using UnityEngine;
using System.Collections;

public class Directions: MonoBehaviour {


	public GameObject player;




	// Use this for initialization
	void Start () {

		player = GameObject.Find("Capsule");
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = player.transform.position + new Vector3(0.0f,0.0f,1.0f);
	
	}
}
