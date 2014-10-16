using UnityEngine;
using System.Collections.Generic;

public class tower2 : MonoBehaviour {
	
	Dictionary<int, GameObject> myDictonary =  new Dictionary<int, GameObject>();
	private int firstTag;
	private int secondTag;
	private GameObject fEnemy;
	private Vector3 relPos;
	public float rotSpeed;
	public Transform turretSpawn;
	private Vector3 relPos2;
	private int dictKey;
	public Transform Spawnpoint;
	private float elapsedtime;
	public float shotRate = 0.5f;
	public Rigidbody bullet;
	public float bulletSpeed = 200.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		elapsedtime += Time.deltaTime;
		
		if (myDictonary.Count >=1) {
			
			dictKey = 1;	//----------------> Check for possible errors
			
			while((myDictonary.ContainsKey(dictKey))!= true) {	// while the dictionary's current key doesn't exist
				
				
				dictKey += 1;	// dictionary go to next element
//				Debug.Log ("1 dictionary goes to next one");
			}
			
			fEnemy = myDictonary[dictKey];
			
			if (fEnemy != null){	//If there is a value
				relPos = fEnemy.transform.position - transform.position;
				relPos.y = 0;
				Quaternion targetRotation = Quaternion.LookRotation(relPos);
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
				
				relPos2 = fEnemy.transform.position - turretSpawn.transform.position;
				Quaternion targetRotation2 = Quaternion.LookRotation(relPos2);
				turretSpawn.transform.rotation = Quaternion.Lerp(turretSpawn.transform.rotation, targetRotation2, Time.deltaTime * rotSpeed);
				
				//SHOOTING RATE OF TURRET
				if (elapsedtime >= shotRate) {	
					
					Rigidbody bulletInstance =  Instantiate(bullet, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody;
					bulletInstance.AddForce(Spawnpoint.forward * bulletSpeed);
					elapsedtime =0.0f;
//					Debug.Log("Dictionary contains: " + myDictonary.Count + " enemies / Current enemy has key:  " + dictKey);
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.tag == "enemy") {
			
//			Debug.Log ("HERE IS AN ENEMY");
			
			if (myDictonary.Count >= 0) {
				
				firstTag = other.gameObject.GetComponent<HealthBar>().tagNumber;	// Get tag from enemy
				myDictonary.Add(firstTag, other.gameObject);				// Add Enemy into dictionary with tag #
			}
		}
	}
	
	void OnTriggerExit(Collider other) {	
		
		if (other.gameObject.tag == "enemy") {
			
			secondTag = other.gameObject.GetComponent<HealthBar>().tagNumber;
			EnemyDead(secondTag);
		}
	}
	
	public void EnemyDead(int Keyvalue) {
		
		myDictonary.Remove(Keyvalue); // remove keytag form dictionary
//		Debug.Log("Enemy with tag: " + Keyvalue + " deleted");
	}
}
