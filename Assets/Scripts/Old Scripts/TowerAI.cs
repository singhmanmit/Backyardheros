using UnityEngine;
using System.Collections.Generic;

public class TowerAI : MonoBehaviour {

	/* Tower has a radius(trigger), If and	enemy gets into the radius(trigger) of 
	 the tower, it (enemy gameObect) is added into a dictionary with a tag(key).
	 The enemy receives a tag(key) number which is used for exiting the trigger
	 when enemy leaves the radius(trigger), it is removed from the dictionary. 

	 Tower gets the first enemy tag(key) from the dictionary and calls the LOOKAT function
	 The function gets the position of the enemy and te tower in world space and calculates the distance
	 between both in real time. The tower rotates pointing at the location of the enemy*/

	private Vector3 destPos;
	private Vector3 curPos;
	private Vector3 relPos;
	public float rotSpeed;
	private int numEnemies;
	private GameObject fEnemy;
	public int Tagging;
	private int newTag;
	Dictionary<int, GameObject> MyDict =  new Dictionary<int, GameObject>();
	private int DictKey;
	public bool checkShoot;

	public Transform turretSpawn;
	private Vector3 relPos2;
	private float elapsedtime;
	public float shotRate = 0.5f;
	public Rigidbody bullet;
	public float bulletSpeed = 200.0f;
	public Transform Spawnpoint;

	void Start() {

		numEnemies = 0;
		rotSpeed = 10.0f;
		checkShoot = false;
	}

	void LateUpdate() {

		elapsedtime += Time.deltaTime;
		// Get 1st element on a disctionary by key
		if(MyDict.Count >=1){

			fEnemy = MyDict[DictKey];
			//Debug.Log (fEnemy.transform.position);

			if (fEnemy != null){
				relPos = fEnemy.transform.position - transform.position;
				relPos.y = 0;
				Quaternion targetRotation = Quaternion.LookRotation(relPos);
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
				checkShoot = true;

				relPos2 = fEnemy.transform.position - turretSpawn.transform.position;
				Quaternion targetRotation2 = Quaternion.LookRotation(relPos2);
				turretSpawn.transform.rotation = Quaternion.Lerp(turretSpawn.transform.rotation, targetRotation2, Time.deltaTime * rotSpeed);

				if (elapsedtime >= shotRate) {
					
					Rigidbody bulletInstance =  Instantiate(bullet, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody;
					bulletInstance.AddForce(Spawnpoint.forward * bulletSpeed);
					elapsedtime =0.0f;
				}
			}

			else {

				checkShoot = false;
			}
		}

		else {

//			Debug.Log("Tower in StandBY");
		}
	}

	void ShootBullet() {
		
		Debug.Log ("LETS KILL!!");
		

	}

	void OnTriggerEnter(Collider other) {

		if ( other.gameObject.tag == "enemy") {	// If trigger is enemy

			if (MyDict.Count == 0) {	// If my dictionary is empty

				numEnemies += 1;						// number of enemies goes +1
				DictKey += 1;
				Tagging = numEnemies;					// a tag number created for the enemy to take
				MyDict.Add(numEnemies, other.gameObject);	// enemy is added into a dictionary
				Debug.Log("--------------FRIST-----------------");
				Debug.Log("TOWER receives enemy: " + Tagging);
			}

			else if (MyDict.Count >= 1) {	// If my dictionary already has at least one element

				numEnemies +=1;
				Tagging = numEnemies;					// a tag number created for the enemy to take
				MyDict.Add(numEnemies, other.gameObject);	// enemy is added into a dictionary
				Debug.Log("--------------FRIST-----------------");
				Debug.Log("TOWER receives enemy: " + Tagging);
			}
		}
	}

	void OnTriggerExit(Collider other) {

		if (other.gameObject.tag == "enemy") {	// If trigger is enemy

			newTag = other.gameObject.GetComponent<EnemyTaging>().tag;
			//newTag = EnemyTaging.tag;
			MyDict.Remove(newTag);			// Remove enemy from the dictionary by its tag number
			Debug.Log("--------------SECOND-----------------");
			Debug.Log ("Enemy with Tag : " +newTag +" is leaving");
			Debug.Log ("dictionary contains "+MyDict.Count);

			if (MyDict.Count >=1) {

				if (MyDict.ContainsKey(DictKey)){
					
					Debug.Log("Using current DictKey: " + DictKey);
				}
				
				else {
					
					Debug.Log("DictKey has gone up to: " + DictKey);
					DictKey += 1;

					if (MyDict.ContainsKey(DictKey)){
						
						Debug.Log("Using current DictKey: " + DictKey);
					}
					
					else {
						
						Debug.Log("DictKey has gone up to: " + DictKey);
						DictKey += 1;
					}
				}
			}
		}
	}
}
