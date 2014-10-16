using UnityEngine;
using System.Collections;

public class fastAI : MonoBehaviour {



	public GameObject player;

	private Vector3 chasePlayer;

	private float distance;

	public float speed = 10.0f;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find ("New Character");

	}
	
	// Update is called once per frame
	void Update () {

		distance = Vector3.Distance(player.transform.position,this.transform.position);


		chasePlayer = player.transform.position - this.transform.position;

		this.rigidbody.AddForce(chasePlayer * speed);

	
	}
}
