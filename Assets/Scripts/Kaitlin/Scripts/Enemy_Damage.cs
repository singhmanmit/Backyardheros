using UnityEngine;
using System.Collections;

public class Enemy_Damage : MonoBehaviour 
{

	public float damage;

	// Use this for initialization
	void Start () 
	{
		damage = 5.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if(this.gameObject.tag == "enemy")
		{
			collider.gameObject.SendMessage("EnemyDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
	}
}
