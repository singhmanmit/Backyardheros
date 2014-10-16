using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GUISkin racingGUISkin;
	public Vector2 buttonStartLocation;
	public Vector2 buttonExitLocation;
	public Transform OrigAngle;
	public Transform OrigPos;

	private bool isReady = false;
	private Vector3 DestPos = new Vector3(0.0f,1.0f,-6.3f);
	private Vector3 DestAngle =  new Vector3(0.0f,0.1f,1.0f);
	private float speed = 1.5f;
	private float speed2 = 0.1f;
	private float journeyLenght;
	private float angLenght;
	private float startTime;

	void Start() {

		isReady = false;
		startTime = Time.time;
		journeyLenght = Vector3.Distance(OrigPos.position, DestPos);
		angLenght = Vector3.Distance (OrigAngle.position, DestAngle);
	}

	// Update is called once per frame
	void Update () 
	{

		float distCovered = (Time.time - startTime) * speed2;
		float fracJourney = distCovered / journeyLenght;
		Camera.mainCamera.transform.position = Vector3.Lerp (OrigPos.position, DestPos, fracJourney);

		float distAngle = (Time.time - startTime) * speed;
		float AngJourey = distAngle / angLenght;
		Camera.mainCamera.transform.rotation = Quaternion.Slerp(Camera.mainCamera.transform.rotation, Quaternion.LookRotation(DestAngle), speed*Time.deltaTime);
			
		if (Time.timeSinceLevelLoad >= 2) {
			isReady = true;
		}
	}
	
	void OnGUI()
	{
		GUI.skin = racingGUISkin;
		//GUI.depth = -1;

		if(isReady == true) {

			GUI.Box (new Rect(320,430,250,250),"MENU");
			if(GUI.Button(new Rect(370, 480, 140, 80), "START")) {
				Application.LoadLevel("Level1_Ver_2.6_test");
			}
			
			if(GUI.Button(new Rect(370, 580, 140, 80), "EXIT")) {
				Application.Quit();	
			}
		}
	}
}
