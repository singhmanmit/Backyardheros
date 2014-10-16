using UnityEngine;
using System.Collections;

public class EnemyPath : MonoBehaviour {
	
	
	private GameObject player;
	
	private GameObject path; // our gameobject that we go to 
	
	private Vector3 pathway; // the vector direction that we use to move
	
	private Vector3 chasePlayer;
	
	private float distance;
	
	private float next_path;
	
	private string pathName;
	
	public float max_speed = 2.0f;
	
	public float speed = 10.0f;
	
	private bool chase = false;
	
	private GameObject Spawn_1;
	
	private GameObject Spawn_2;
	
	private GameObject Spawn_3;

	private GameObject Spawn_4;
	
	
	// Use this for initialization
	void Start () {
		
		
		Spawn_1 = GameObject.Find("Spawn_1");
		Spawn_2 = GameObject.Find("Spawn_2");
		Spawn_3 = GameObject.Find("Spawn_3");
		Spawn_4 = GameObject.Find("Spawn_4");
		
		// random number is selecets between 0 and 1
		int choosePath = Random.Range(0,4);
		
		
		// if the random number from above is 0 then it chooses path on or "p_one"
		if (choosePath == 0){
			
			pathName = "p_one";
			
			this.transform.position = Spawn_1.transform.position;
			
		}
		
		
		// if the random number is 1 it chooses path 2 or "p_two"
		if (choosePath == 1){
			
			pathName = "p_two";
			
			this.transform.position = Spawn_2.transform.position;
		}
		

		if (choosePath == 2){
			
			pathName = "p_three";
			
			this.transform.position = Spawn_3.transform.position;
		}


		if (choosePath == 3){
			
			pathName = "p_four";
			
			this.transform.position = Spawn_4.transform.position;
		}
		
		print (pathName);
		
		// we find the gameobject that starts the path
		path = GameObject.Find(pathName);
		
		
		// we find the player
		player = GameObject.FindGameObjectWithTag("Player");
		//Seriously Omar, don't find by name when there could be different names for the cahracter
		
	}
	
	// Update is called once per frame
	void Update () {
		
		distance = Vector3.Distance(player.transform.position,this.transform.position);
		
		
		// the vector in which we move towards 
		pathway = path.transform.position - this.transform.position;
		
		chasePlayer = player.transform.position - this.transform.position;
		
		// we add force to the enemy to move in the pathway direction
		
		if(chase == false){
			
			this.rigidbody.AddForce(pathway * speed);
		}
		
		
		if(chase == true){
			
			distance = 10.0f;
			
			this.rigidbody.AddForce(chasePlayer * speed);
		}
		
		
		
		
		this.rigidbody.velocity = Vector3.ClampMagnitude(this.rigidbody.velocity, max_speed);
		
		
		
		if (distance <= 5.0f){
			
			int chose_choose = Random.Range(0,2);
			
			if (chose_choose == 0){
				chase = false;
			}
			
			if(chose_choose == 1){
				chase = true;
			}
			
		}
		
		
		
	}
	
	
	
	
	void OnTriggerEnter(Collider coll){
		
		
		if(coll.tag == "path"){
			
			//print ("WORKS");
			
			next_path += 1;
			
			path = GameObject.Find(pathName + next_path);
			
			
			// this pauses the enemy at each stop so it doesnt go off path 
			
			//this.rigidbody.velocity = new Vector3(0.0f,0.0f,0.0f); 
			
		}
		
		
	}
	
	
	
	
	
	
	
	
	
}




