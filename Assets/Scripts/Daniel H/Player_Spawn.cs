using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Spawn : MonoBehaviour {

	public List<GameObject> Characters;
	public int TestClassChoice = 0;
	GameObject Player;

	public GameObject EnemySpawner;
	// Use this for initialization
	void Start () {
		if(EnemySpawner==true){
			if(GameObject.FindGameObjectWithTag("Player")==false){
				SelectCharatcer(TestClassChoice);
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SelectCharatcer(int choice){
		Player = Instantiate(Characters[choice], transform.position, transform.rotation) as GameObject;
		if(EnemySpawner==false){
			DontDestroyOnLoad(Player);
			Application.LoadLevel("Level1_Ver_2.4");
		}
	}
}
