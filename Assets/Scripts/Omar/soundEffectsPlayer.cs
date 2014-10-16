using UnityEngine;
using System.Collections;

public class soundEffectsPlayer : MonoBehaviour {




	public AudioClip shoot;
	public AudioClip jump;
	public AudioClip hit;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



		if(Input.GetMouseButtonDown(0))
		{

			audio.PlayOneShot(shoot);

		}


		if(Input.GetKeyDown("space"))
		{
			
			audio.PlayOneShot(jump);
			
		}
	
	}





}
