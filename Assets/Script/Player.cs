using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	
	public GameObject [] players;
	public GameObject [] tombs;
	public int lives;
	public int hp;
	private float speed;
	protected Vector2 direction;
	public Rigidbody2D rb;
	//----------------
	public Transform GroundCheck;
	public Transform rebornPoint;
	//----------------
	public bool Grounded;
	public float JumpForce;
	public GameObject sword;
	//public GameObject spearPrefab;
	//public GameObject spearPosition;	
	//AudioSource audio;
	//public AudioClip  hitSound;
	//public AudioClip  AttackSound;
	//----------------
	public bool ableToActiveCandle;
	public bool activateCandle;
	public bool winGame;
	//----------------
	public Text uiText;
	public Text uiText2;
	public Text uiText3;
	public GameObject elder1;
	public GameObject elder2Text;
	//----------------	
	// Use this for initialization
	void Start () {
		lives = 10;
		hp = 30;
		ableToActiveCandle = false;
		activateCandle = false;
		winGame = false;
		speed = 8f;
		JumpForce = 50f;
		rb = GetComponent<Rigidbody2D>();
		//audio = GetComponent<AudioSource>();
	}
	
	void FixedUpdate(){
		Grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.02f);		
		
		if (Input.GetKey(KeyCode.Space) && Grounded==true){
			rb.AddForce(Vector2.up * JumpForce);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!winGame){
			uiText2.text	= "HP: "+hp+"/30  Lives: "+lives;	
		}
		
		direction = Vector2.zero;
		
		if (Input.GetKey(KeyCode.A)){
			direction += Vector2.left;
			print(transform.localScale.x);
			if(transform.localScale.x >0){
				transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
			}
		}
		
		if (Input.GetKey(KeyCode.D)){
			direction += Vector2.right;
			if(transform.localScale.x < 0){
				transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
			}
		}		
		
		if (Input.GetKey(KeyCode.E)){
			if(ableToActiveCandle){
				activateCandle = true;
			}
		}		
		
		if(Input.GetButtonDown("Fire1")){
			//attack
			//audio.PlayOneShot(AttackSound, 0.7F);
			//Instantiate(spearPrefab, new Vector3(spearPosition.transform.position.x,spearPosition.transform.position.y,0), Quaternion.identity);
			sword.gameObject.SetActive (true);
			StartCoroutine(desativarEspada(0.2f));
		}
		
		transform.Translate(direction*speed*Time.deltaTime);		
	}
	
	void OnCollisionEnter2D(Collision2D col){
		
		if(col.gameObject.tag == "axe" || col.gameObject.tag == "fireball" || col.gameObject.tag == "knife"){
			hp = hp - 9;
			if(hp < 1){
				dead();
			}
		}
		
		if(col.gameObject.tag == "lava" || col.gameObject.tag == "spike" ||  col.gameObject.tag == "laser"  ){
			print("colidiu com lava ou espinho");
			dead();
			//GameObject.Destroy(GameObject.Find("Player"));
		}	
		
		if(col.gameObject.tag == "vela" ){
			uiText.text	= "Press 'E' to Sacrifice yourself and Open the Door";
			ableToActiveCandle = true;
		}	

		if(col.gameObject.tag == "elder" ){
			uiText.text	= "Go my son! Down in the pit and sacrifice yourself for our people.";
		}

		if(col.gameObject.tag == "elder2" ){
			uiText.text	= "Hahaha you fool! You and the others helped me to release a ancient evil. Now, i do not need you more!";
			StartCoroutine(deactiveElder2Text(3f));
		}				
		if(col.gameObject.tag == "friendSoul" ){
			winCondition();
		}
	}
	
	public void dead(){
		
		activateCandle = false;
		ableToActiveCandle = false;
		
		lives = lives - 1;
		hp = 30;
		
		players[lives].gameObject.SetActive (false);
		tombs[lives].gameObject.SetActive (true);
	
		transform.position = new Vector3(rebornPoint.position.x,rebornPoint.position.y,rebornPoint.position.z);
	
		if(lives == 0){
			gameOver();
			GameObject.Destroy(GameObject.Find("Player"));
		}
	}
	
	public void winCondition(){
		winGame = true;
		uiText.text	= "You Win! You released you friend souls and defeated the evil. Thanks for play! Game by @folex70";
		uiText2.text	= "You Win! You released you friend souls and defeated the evil. Thanks for play! Game by @folex70";
		uiText3.text	= "";
	}
	
	public void gameOver(){
		uiText.text	= "Game Over! You sacrifice are lost. Thanks for play! Game by @folex70.";
	}
	
	void OnCollisionStay2D(Collision2D col){
		if(activateCandle){
			col.gameObject.SendMessage ("active");
			dead();
			activateCandle = false;			
		}			
	}
	
	void OnCollisionExit2D(Collision2D col){
		uiText.text	= "";
		ableToActiveCandle = false;
		activateCandle = false;
	}
	
	IEnumerator desativarEspada(float val){
		 yield return new WaitForSeconds(val);
		 sword.gameObject.SetActive (false);
	}

	IEnumerator deactiveElder2Text(float val){
		 yield return new WaitForSeconds(val);
		 elder2Text.gameObject.SetActive (false);
		 elder1.gameObject.SetActive (false);
	}	
}
