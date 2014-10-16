using UnityEngine;
using System.Collections;

public class EnemyHealthBar_2 : MonoBehaviour {
	
	public static float curHp = 300.0f;
	public static float maxHp = 300.0f;
	public Texture2D HpBarTexture;
	public float hpBarLength;
	public float percentOfHp;
	//changed some stuff so currency would work, if confused then asked me. DH
	GameObject player;
	Currency playerC;
	//-------------------
	public float scale = 50;

	//--Daniel Tay's Start
	private TowerAI function;
	public int enemyTag;
	//--Daniel Tay's End

//	void OnGUI () 
//	{
//		if(gameObject.tag == "enemy")
//		{
//			if (curHp > 0)
//			{
//				Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
//				float dist = (this.transform.position-Camera.main.transform.position).magnitude;
//				GUI.DrawTexture(new Rect(pos.x-((hpBarLength*(percentOfHp/100))*((1/dist)*scale)/2),((Screen.height-pos.y))-(150*((1/dist)*scale)),(hpBarLength*(percentOfHp/100))*((1/dist)*scale),10*((1/dist)*scale)),HpBarTexture);
//			}
//		}
//		if(gameObject.tag == "tower")
//		{
//			if (curHp > 0)
//			{
//				Vector3 pos2 = Camera.main.WorldToScreenPoint(this.transform.position);
//				float dist2 = (this.transform.position-Camera.main.transform.position).magnitude;
//				GUI.DrawTexture(new Rect(pos2.x-((hpBarLength*(percentOfHp/100))*((1/dist2)*scale)/2),((Screen.height-pos2.y))-(150*((1/dist2)*scale)),(hpBarLength*(percentOfHp/100))*((1/dist2)*scale),10*((1/dist2)*scale)),HpBarTexture);
//			}
//		}
//	}
	void Start(){
		player=GameObject.FindGameObjectWithTag("Player");
	}


	void Update () {
		
		if(Input.GetKeyDown("h"))
		{
			percentOfHp -= 10.0f;
		}
		if(percentOfHp <= 0)
		{
			//Destroy(this.gameObject);
			//Calls function to destroy enemy
			KillEnemy();
		}
		
	}

	/* ---------Daniel's Start---------
	 */


	void KillEnemy() {
		playerC.AddMoney(2);
		Destroy(this.gameObject);
	}
	/*---------Daniel's End---------
	 */
}
