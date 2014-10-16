using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour 
{
	public float health;
	public int money;
	public int power;
	
	// Use this for initialization
	void Start () 
	{
		health = 20.0f;
		money = 10;
		power = 1;
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "health")
		{
			this.gameObject.SendMessage("HealthPickUp", health, SendMessageOptions.DontRequireReceiver);
			Destroy(collider.gameObject);
			Debug.Log("You picked up health!");
		}
		
		if(collider.gameObject.tag == "power")
		{
			this.gameObject.SendMessage("PowerUpPickUp", power, SendMessageOptions.DontRequireReceiver);
			Destroy (collider.gameObject);
			Debug.Log ("You picked up a power up!");
		}
		
		if(collider.gameObject.tag == "currency")
		{
			this.gameObject.SendMessage("CurrencyPickUp", money, SendMessageOptions.DontRequireReceiver);
			Destroy(collider.gameObject);
			Debug.Log ("You picked up money!");
		}
	}
}
