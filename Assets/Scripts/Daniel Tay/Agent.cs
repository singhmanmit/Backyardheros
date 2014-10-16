using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

	public GameObject player;
	protected NavMeshAgent agent;

	// Use this for initialization
	void Start () {
	
		agent = GetComponent<NavMeshAgent> ();
		agent.updateRotation = false;
	}

	void Update() {
		agent.updateRotation = true;
		agent.destination = player.transform.position;
	}
}
