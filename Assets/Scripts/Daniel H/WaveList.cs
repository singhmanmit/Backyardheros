using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class spawnpoint{
	public GameObject Location;
	public List<Mobs> EnemiesToSpawn;
}

[System.Serializable]
public class WaveMob{
	public List<spawnpoint> SpawnPoints;
}

[System.Serializable]
public class Mobs{
	public GameObject Enemy;
	public int Number;
}

public class WaveList : MonoBehaviour {
	
	public List<WaveMob> Waves;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}