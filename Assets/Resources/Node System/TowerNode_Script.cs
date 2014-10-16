using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerNode_Script : MonoBehaviour {

	public GameObject CurrentTower;
	public List<GameObject> StartTowers;
	public bool IsOccupied;

	GameObject PUT; // Placeholder Upgraded Tower

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Things to add/modify:

	/*Upgrade system (need tower scripts first)
	 */

	public void CreateTower(int index){
		if (CurrentTower == null){
			CurrentTower = Instantiate(StartTowers[index], transform.position, transform.rotation) as GameObject;
			IsOccupied = true;
		}
		else{
			Debug.Log("Tower Node is Occupied");
		}

	}

	public void RemoveTower(){
		Destroy(CurrentTower);
		IsOccupied = false;
	}

	public void UpgradeTower(){
		PUT = CurrentTower.GetComponent<towerScript>().Laser2;
		RemoveTower ();
		CurrentTower = Instantiate(PUT, transform.position, transform.rotation) as GameObject;

		IsOccupied = true;
	}

}
