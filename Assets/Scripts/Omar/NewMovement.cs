using UnityEngine;
using System.Collections;

public class NewMovement : MonoBehaviour {
	
	
	public float Gravity= -0.1f;
	
	public float max_speed = 20.0f;
	public float speed = 20.0f;
	public GameObject forward;
	public GameObject right;
	public GameObject diagonal;
	public GameObject diagonal_2;
	public Vector3 playerForward;
	public Vector3 playerRight;
	public Vector3 playerDiagonal;
	public Vector3 playerDiagonal_2;
	public KeyCode keyPause = KeyCode.P;
	public Font font;
	bool isPaused = false;
	
	
	//public Transform cam = Camera.main.transform;
	
	
	//public Vector3 cameraRelativeRight = cam.TransformDirection(Vector3.right);
	
	
	
	
	//public Vector3 moveDirection;
	
	// Use this for initialization
	void Start () {
		
		forward = GameObject.Find("Forward");
		
		right = GameObject.Find("Right");
		
		diagonal = GameObject.Find("Diagonal");
		
		diagonal_2 = GameObject.Find("Diagonal_2");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		playerForward = forward.transform.position - this.transform.position;
		
		playerRight = right.transform.position - this.transform.position;
		
		playerDiagonal = diagonal.transform.position - this.transform.position;
		
		playerDiagonal_2 = diagonal_2.transform.position - this.transform.position;
		
		//print(playerForward);
		
		
		
		
		if(Input.GetKey("w")){
			
			//playerForward.x = 0.0f;
			
			playerForward.y = Gravity;
			
			this.rigidbody.velocity = playerForward * speed;
			
		}
		
		
		if(Input.GetKey("s")){
			
			//playerForward.x = 0.0f;
			
			playerForward.y = -Gravity;
			
			this.rigidbody.velocity = -playerForward * speed;
			
		}
		
		
		
		
		
		if(Input.GetKey("a")){
			
			//playerForward.x = 0.0f;
			
			playerRight.y = -Gravity;
			
			this.rigidbody.velocity = -playerRight * speed;
			
		}
		
		
		
		if(Input.GetKey("d")){
			
			//playerForward.x = 0.0f;
			
			playerRight.y = Gravity;
			
			this.rigidbody.velocity = playerRight * speed;
			
		}
		
		
		
		
		if (Input.GetKey("w") && Input.GetKey("d")){
			
			
			playerDiagonal.y = Gravity;
			
			this.rigidbody.velocity = playerDiagonal * speed;
			
		}
		
		
		
		if (Input.GetKey("a") && Input.GetKey("s")){
			
			
			playerDiagonal.y = -Gravity;
			
			this.rigidbody.velocity = -playerDiagonal * speed;
			
		}
		
		
		if (Input.GetKey("w") && Input.GetKey("a")){
			
			
			playerDiagonal_2.y = Gravity;
			
			this.rigidbody.velocity = playerDiagonal_2 * speed;
			
		}
		
		
		if (Input.GetKey("s") && Input.GetKey("d")){
			
			
			playerDiagonal_2.y = -Gravity;
			
			this.rigidbody.velocity = -playerDiagonal_2 * speed;
			
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		if(Input.GetKeyUp("a") || Input.GetKeyUp("w") || Input.GetKeyUp("s") || Input.GetKeyUp("d")){
			
			this.rigidbody.velocity = new Vector3(0.0f,0.0f,0.0f);
			
		}
		
		
		this.rigidbody.velocity = Vector3.ClampMagnitude(this.rigidbody.velocity, max_speed);
		
		if(Input.GetKeyDown(keyPause)){	
			if (!isPaused){
				Time.timeScale = 0;
				isPaused = true;
			}
			else{
				Time.timeScale = 1;
				isPaused = false;
			}
		}
	}
	
	void OnGUI(){
		if(isPaused){
			GUI.skin.font = font;
			GUI.Label(new Rect(((Screen.width/2)-43), (Screen.height/2)-100, 180, 40), "Game Paused");
			if (GUI.Button(new Rect(((Screen.width/2)-150), (Screen.height/2)-50, 300, 40), "Main Menu")){
				Application.LoadLevel("Menu");
			}
			if(GUI.Button(new Rect(((Screen.width/2)-150), (Screen.height/2), 300, 40), "Restart")){
				Application.LoadLevel("Level1_1.3");
				Time.timeScale = 1;
				isPaused = false;
			}
			if(GUI.Button(new Rect(((Screen.width/2)-150), (Screen.height/2)+50, 300, 40), "Quit")){
				Application.Quit ();
			}
		}
	}
}
