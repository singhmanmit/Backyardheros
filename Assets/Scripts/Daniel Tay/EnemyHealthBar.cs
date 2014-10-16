using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {
	
	public static float curHp = 300.0f;
	public static float maxHp = 300.0f;
	public Texture2D HpBarTexture;
	public float hpBarLength;
	public float percentOfHp;
	public float ifdead = 0;
	
	public float scale = 50;

	public GameObject Player;

	// Dani Start
	public int tagNumber;
	// Dani End
	Currency player;

	void Start(){
		Player = GameObject.FindGameObjectWithTag("Player");
		player = Player.GetComponent<Currency>();
		Debug.Log ("Enemy number: " + tagNumber);
	}
	
	void OnGUI () 
	{
		if (curHp > 0)
		{
			//GUI.DrawTexture(new Rect((Screen.width/2) - 100, 15, hpBarLength, 10), HpBarTexture); 
			Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
			float dist = (this.transform.position-Camera.main.transform.position).magnitude;
			/*GUI.DrawTexture(new Rect((pos.x+(hpBarLength/2))*((1/dist)*scale),((Screen.height-pos.y)-50)*((1/dist)*scale),
			                         (percentOfHp/100)*((1/dist)*scale),((1/dist)*scale)),HpBarTexture);*/
			GUI.DrawTexture(new Rect(pos.x-((hpBarLength*(percentOfHp/100))*((1/dist)*scale)/2),((Screen.height-pos.y))-(150*((1/dist)*scale)),(hpBarLength*(percentOfHp/100))*((1/dist)*scale),10*((1/dist)*scale)),HpBarTexture);
		}
	}
	
	void Update () {
		
		if(Input.GetKeyDown("h"))
		{
			percentOfHp -= 10.0f;
		}
		if(percentOfHp <= 0)
		{
			//player.AddMoney(2);
			// Dani Start
//			tower2 tower = gameObject.GetComponent<tower2>();
//			tower.EnemyDead(tagNumber);
			// Dani End
			ifdead = 1 ;
			StartCoroutine(_wait(3));
			Debug.Log("KILLED");
			//Destroy(this.gameObject);
		}
		
	}
	
	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "damage")
		{
			percentOfHp -= 25.0f;
		}
	}

	IEnumerator _wait(float sec){
		yield return new WaitForSeconds(sec);
		Destroy(this.gameObject);
	}

}
