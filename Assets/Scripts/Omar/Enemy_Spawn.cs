using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_Spawn : MonoBehaviour {

	
	// Use this for initialization

	//------------------------------------------------------------------------------
	//READ THIS OMAR. -DH
	/* 		OK, that method for counting time is simply HORRIBLE.
	 * 		The script is adding one everytime the update fuction is called, therefore it adds 1 every frame.
	 * So let's say someone's framerate is at 30, that means in that situation the person has about 10 seconds before the
	 * enemies spawn. Now if it turns out the player's framerate is around 60 instead, then they only have 5 seconds.
	 * Now, this method could work, if the framerate was capped, but it isn't so therefore this method does not truly work.
	 * 
	 * 		The method I use is Time.deltatime, since deltatime is a read varaiable that gives the amount of time 
	 * passed when rendering a frame.
	 * They are also set as float data type for obvious reasons.
	 * 
	 * 		If you are confused by how this works after looking at the code, let me know.
	 */
	//END RANT. -DH
	//------------------------------------------------------------------------------

	//private int timeSpawn = 0;  
	//public int release_time =300;

	//private GameObject Spawn_1; //Unessecary -DH
	//private GameObject Spawn_2; //Unessecary -DH
	//private GameObject Spawn_3;

	//DH Section-----------------------------------
	public int ActiveWaveTime = 130;
	//public int PassiveWaveTime = 40;
	public bool IsWaveActive=false;
	float currentTimer;

	public WaveList ListOfWaves;
	int CurrentWave = 1;
	int pointsIndex = 0;
	int mobIndex = 0;
	GameObject[] Enemies;
	//DH Section END-------------------------------

	// Dani Start
	private int tagNumber;
	// Dani End

	void Start () {

		//Spawn_1 = GameObject.Find("Spawn_1"); //Unessecary -DH
		//Spawn_2 = GameObject.Find("Spawn_2"); //Unessecary -DH
		//Spawn_3 = GameObject.Find("Spawn_3");
		//GameObject enemy = Instantiate(Resources.Load("Enemy")) as GameObject;
		//enemy.transform.position = this.transform.position;

		// Dani Start
		tagNumber = 0;
		// Dani End

		//DH Section-------------
		currentTimer = 0;
		CurrentWave = 0;
		//DH Section END---------
	}
	
	// Update is called once per frame
	void Update () {
		Enemies = GameObject.FindGameObjectsWithTag("enemy");

		//Changed the spawn system to fit the wave system.
		//The nested IF statements are to keep the indexes and timer correct.
		//if the nested statements are too confusing and you need something changed, let me know. -DH

		if (IsWaveActive==true){
			if (currentTimer > 0){
				if(pointsIndex < ListOfWaves.Waves[CurrentWave-1].SpawnPoints.Count){
					if(mobIndex < ListOfWaves.Waves[CurrentWave-1].SpawnPoints[pointsIndex].EnemiesToSpawn.Count){
						for(int i=0; i < ListOfWaves.Waves[CurrentWave-1].SpawnPoints[pointsIndex].EnemiesToSpawn[mobIndex].Number; i++){
							// Dani Start
							tagNumber +=1;
							// Dani End

							//This allows the enemy to spawn on the correct spawnpoint.
							//I also don't do the resources load method that you had because the correct enemy 
							//is already in the nested lists. -DH
							GameObject enemy = (GameObject)Instantiate((ListOfWaves.Waves[CurrentWave-1].SpawnPoints[pointsIndex].EnemiesToSpawn[mobIndex].Enemy),
							                               				ListOfWaves.Waves[CurrentWave-1].SpawnPoints[pointsIndex].Location.transform.position,
							                               				ListOfWaves.Waves[CurrentWave-1].SpawnPoints[pointsIndex].Location.transform.rotation);

							// Dani Start
							HealthBar other = enemy.gameObject.GetComponent<HealthBar>();
							other.tagNumber = tagNumber;
							// Dani End

							//enemy.transform.position = Spawn_1.transform.position; //Unessecary -DH
							//timeSpawn =0; //Unessecary -DH
						}
						mobIndex++;
					}
					else{
						mobIndex=0;
						pointsIndex++;
					}
				}
				currentTimer-=Time.deltaTime;
				if((currentTimer>15) && (currentTimer<(ActiveWaveTime-5))){
					if(Enemies.Length==0){
						currentTimer=2;
						//Debug.Log("test2");
					}
				}
				if(currentTimer<0){
					currentTimer=0;
				}
			}
			else{
				IsWaveActive=false;
				pointsIndex = 0;
				//Debug.Log("test3");
			}
		}
	}

	//WAVE GUI. -DH
	void OnGUI(){
		if(IsWaveActive==false){
			if(GUI.Button (new Rect (300, 10, 130, 20), "Start Next Wave")){
				if((CurrentWave+1) <= ListOfWaves.Waves.Count){
					currentTimer=ActiveWaveTime;
					IsWaveActive=true;
					CurrentWave+=1;
				}
				else{
					if(Enemies.Length==0){
						//trigger win screen
						Application.LoadLevel("WinScene");
					}
				}
			}
		}
		if(IsWaveActive==true){
			GUI.Box(new Rect(160,10,140,30),"Time Left: " + (int)(currentTimer));
		}
		else{
			GUI.Box(new Rect(160,10,140,30),"No wave timer active");
		}
		if(IsWaveActive==true){
			GUI.Box(new Rect(160,40,140,30),"Wave Is Active");
		}
		else{
			GUI.Box(new Rect(160,40,140,30),"Wave Is NOT Active");
		}
		GUI.Box(new Rect(160,70,140,30),"Current Wave: " + CurrentWave);
		GUI.Box(new Rect(160,100,140,30),"Enemies left: " + Enemies.Length);
	}
	//WAVE GUI END.-DH
}
