using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KATE_AI : MonoBehaviour {
	
	
	private GameObject myGoal;
	
	
	
	
	
	// Use this for initialization
	void Start () {

		myGoal = GameObject.Find("Treehouse");
	}
	
	
	//	H = Math.abs(start.x-destination.x) + Math.abs(start.y-destination.y));

	
	
	
	float myCostEstimator(GameObject start,GameObject destination)
	{

		float startX = start.transform.position.x;
		float destinationX = destination.transform.position.x;

		float startZ = start.transform.position.z;
		float destinationZ = destination.transform.position.z;

		float H = Mathf.Abs(startX - destinationX) + Mathf.Abs(startZ - destinationZ);



		return H;

	}




	GameObject eval_lowest(GameObject[] open_set)
	{

		return open_set[0];
	}



	
	
	void A_star(GameObject start, GameObject goal)
	{
		GameObject[] closed_set;
		GameObject[] open_set;

		open_set = GameObject.FindGameObjectsWithTag("navPoint");

		GameObject[] came_from;
		
		Dictionary <GameObject, float> g_score = new Dictionary<GameObject, float>();
		
		Dictionary <GameObject, float> f_score = new Dictionary<GameObject, float>();
		
		g_score[start] = 0.0f;

		f_score[start] = g_score[start] + myCostEstimator(start,goal); 
		
		
		while (open_set.Length > 0)
		{
			GameObject current = eval_lowest(open_set);



			//new Vector3 go = current.transform.position - this.transform.position;

			//this.rigidbody.velocity = go;





			break;

		}

	}
	
	
	
	
	// Update is called once per frame
	void Update () {
		
		A_star(this.gameObject, myGoal);
	}
}
