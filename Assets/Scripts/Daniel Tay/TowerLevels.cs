using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* This script should do:
 * increase the speed (shoot rate of tower)
 * increase the range of the tower
 * increase the power of the bullet
 * */

//Some Changes were made by Daniel_H

public class TowerLevels : MonoBehaviour {
	
	// public values
	public List<Attribute> SpeedList;
	public List<Attribute> PowerList;
	public List<Attribute> RangeList;
	public int CurrentSpeedLevel=0;
	public int CurrentPowerLevel=0;
	public int CurrentRangeLevel=0;

	// private values
	public float speed, range, power;
	private int level;
	private int speedLevel, rangeLevel, powerLevel;
	private int CostMultiplier = 2;

	GameObject Player;
	Currency player;

	void Start() {
		Player = GameObject.FindGameObjectWithTag("Player");
		player = Player.GetComponent<Currency>();

		speed=SpeedList[0].amount;
		power=PowerList[0].amount;
		range=RangeList[0].amount;
	}

	void Update(){
		speed=SpeedList[CurrentSpeedLevel].amount;
		power=PowerList[CurrentPowerLevel].amount;
		range=RangeList[CurrentRangeLevel].amount;
	}

}

[System.Serializable]
public class Attribute{
	public float amount;
	public int cost;
}


/* Levels
 * 1.- speed, range, power
 * 2.- speed, range, power
 * 3.- speed, range, power
 * 4.- speed, range, power
 * 5.- speed, range, power
 * 
 * How it works?
 * player will have a GUI that shows his money, and the tower information as:
 * # speed, # range, # power.
 * each power starts from level 1 and each are be upgradeable separately
 * each upgrade has 5 levels.
 */