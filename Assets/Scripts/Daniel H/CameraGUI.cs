using UnityEngine;
using System.Collections;

public class CameraGUI : MonoBehaviour {
	
	public float rayDistance = 100f;
	public TowerNode_Script NODE;
	//RaycastHit hitObj;
	//Ray ray;
	//public int MenuPositionX = 0;
	//public int MenuPositionY = 0;
	bool Pausegame = false;
	public Collider SphereNodeTrigger;
	public GameObject nodeinrange;
	
	GameObject Player;
	Currency player;

	public Texture2D crosshair;
	public Texture2D EIcon;
	public Texture2D MenuBackground;
	public Texture2D Tower1Icon;
	public Texture2D Tower2Icon;
	public Texture2D UpgradeIcon;
	public Texture2D SellIcon;
	public KeyCode MenuButton1;
	public KeyCode MenuButton2;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		Player = GameObject.FindGameObjectWithTag("Player");
		player = Player.GetComponent<Currency>();
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if(Pausegame == true){
			Time.timeScale = 0.0001f;
			Screen.showCursor = true;
		}
		else{
			Time.timeScale=1;
			Screen.showCursor = false;
		}
		
		if (Input.GetKeyDown("e") && nodeinrange!=false){
			NODE=nodeinrange.GetComponent<TowerNode_Script>();
		}
		if(Input.GetKeyDown("e")&& Pausegame==true){
			NODE=null;
			Pausegame = false;
		}
	}
	
	public bool GetPauseState(){
		return Pausegame;
	}
	
	//will need to edit size calculation when UI is finalized
	//also edit naming system once towers are finalized, if needed
	void OnGUI(){

		GUI.DrawTexture(new Rect(Screen.width / 2 - 37.5f, Screen.height/2 - 37.5f, 75, 75), crosshair);	// draws the crosshair

		if(nodeinrange!=false){
			GUI.DrawTexture(new Rect(120, 0, 40, 40), EIcon);
		}

		if (NODE == true) {
			Pausegame = true;
			GUI.DrawTexture(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), MenuBackground);
			if(NODE.IsOccupied==false){
				GUI.DrawTexture(new Rect(Screen.width/3, Screen.height/3, Screen.width/6, Screen.height/3), Tower1Icon);
				GUI.DrawTexture(new Rect((Screen.width/3)*2, Screen.height/3, Screen.width/6, Screen.height/3), Tower2Icon);
				if(Event.current.keyCode==MenuButton1){
					NODE.CreateTower(0);
					NODE=null;
					Pausegame = false;
				}
				if(Event.current.keyCode==MenuButton2){
					NODE.CreateTower(1);
					NODE=null;
					Pausegame = false;
				}
			}

			if(NODE.IsOccupied==true){
				GUI.DrawTexture(new Rect(Screen.width/3, Screen.height/3, Screen.width/6, Screen.height/3), UpgradeIcon);
				GUI.DrawTexture(new Rect((Screen.width/3)*2, Screen.height/3, Screen.width/6, Screen.height/3), SellIcon);
				if(Event.current.keyCode==MenuButton1){
					NODE.UpgradeTower();
					NODE=null;	// here it upgrades the tower.

					Pausegame = false;
				}
				if(Event.current.keyCode==MenuButton2){
					NODE.RemoveTower();
					NODE=null;
					Pausegame = false;
				}
			}


			//creates a menu based on size of buttons and number of towers in the list
			/*GUI.Box(new Rect(MenuPositionX,MenuPositionY, 160, (NODE.StartTowers.Count+3)*30), "TNode_TESTMENU");
			if(NODE.StartTowers.Count>0){
				for(int i = 1; i<=NODE.StartTowers.Count; i++){
					if(player.MoneyHeld<=10 || NODE.IsOccupied==true){
						GUI.enabled = false;	
					}
					else{
						GUI.enabled = true;
					}
					if (NODE.StartTowers[i-1] == true){
						if (GUI.Button (new Rect (MenuPositionX+10, MenuPositionY+(i*30), 130, 20), "Tower" +i)) {
							NODE.CreateTower (i-1);
							player.MoneyHeld-=10;
						}
					}
					else{
						if (GUI.Button (new Rect (MenuPositionX+10, MenuPositionY+(i*30), 130, 20), "EMPTYARRAYSLOT")) {
						}
					}
				}
			}

			if(NODE.IsOccupied==false){
				GUI.enabled = false;	
			}
			else{
				GUI.enabled = true;
				int tempS = NODE.CurrentTower.GetComponent<TowerLevels>().CurrentSpeedLevel;
				int tempP = NODE.CurrentTower.GetComponent<TowerLevels>().CurrentPowerLevel;
				int tempR = NODE.CurrentTower.GetComponent<TowerLevels>().CurrentRangeLevel;


				GUI.enabled = false;
				if (NODE.CurrentTower.GetComponent<TowerLevels>().SpeedList[tempS].cost<player.MoneyHeld){
					GUI.enabled =true;
				}
				if (GUI.Button(new Rect(MenuPositionX, MenuPositionY+((NODE.StartTowers.Count+1)*30), 50, 20), "Speed")){
					player.MoneyHeld-=NODE.CurrentTower.GetComponent<TowerLevels>().SpeedList[tempS].cost;
					NODE.CurrentTower.GetComponent<TowerLevels>().CurrentSpeedLevel+=1;
				}

				GUI.enabled = false;
				if (NODE.CurrentTower.GetComponent<TowerLevels>().RangeList[tempR].cost<player.MoneyHeld){
					GUI.enabled =true;
				}
				if (GUI.Button(new Rect(MenuPositionX+50, MenuPositionY+((NODE.StartTowers.Count+1)*30), 50, 20), "Range")){
					player.MoneyHeld-=NODE.CurrentTower.GetComponent<TowerLevels>().RangeList[tempR].cost;
					NODE.CurrentTower.GetComponent<TowerLevels>().CurrentRangeLevel+=1;
				}

				GUI.enabled = false;
				if (NODE.CurrentTower.GetComponent<TowerLevels>().PowerList[tempP].cost<player.MoneyHeld){
					GUI.enabled =true;
				}
				if (GUI.Button(new Rect(MenuPositionX+100, MenuPositionY+((NODE.StartTowers.Count+1)*30), 50, 20), "Power")){
					player.MoneyHeld-=NODE.CurrentTower.GetComponent<TowerLevels>().PowerList[tempP].cost;
					NODE.CurrentTower.GetComponent<TowerLevels>().CurrentPowerLevel+=1;
				}
			}



			if(NODE.IsOccupied==false){
				GUI.enabled = false;	
			}
			else{
				GUI.enabled = true;
			}
			if (GUI.Button (new Rect (MenuPositionX+10, MenuPositionY+((NODE.StartTowers.Count+2)*30), 130, 20), "SellTower")) {
				NODE.RemoveTower ();
				player.MoneyHeld+=5;
			}*/
		}
	}
	
	/*void grabNode (){
		ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		Debug.DrawRay(ray.origin, (ray.direction * rayDistance), Color.red, 9000);
		if (Physics.Raycast (ray.origin, ray.direction, out hitObj, rayDistance)){
			if(hitObj.collider.gameObject.tag == "Node"){
				//Debug.Log("raycast HIT!");
				NODE = hitObj.collider.gameObject.GetComponent<TowerNode_Script>();
			}
			else{
				NODE = null;
			}
		}
	}*/

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Node") {
			nodeinrange=other.gameObject;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Node") {
			nodeinrange=null;
		}
	}
}


