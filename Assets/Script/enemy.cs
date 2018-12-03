using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {


	public int RandomWalk;
	public float enemyTime;
	public int RandomJump;
	public int RandomAttack;
	public int RandomAttackSpecial;
	public Rigidbody2D rb;
	public float JumpForce;
	public bool volta = false;
	public float xVal;
	public GameObject axePrefab;
	
	//AudioSource audio;
	//public AudioClip  hitSound;
	//public AudioClip  AttackSound;

	public int hp;

	// Use this for initialization
	void Start () {
		hp = 15;
		
		enemyTime = 1f;
		JumpForce = 150f;
		rb = GetComponent<Rigidbody2D>();
		volta = false;
		xVal = transform.position.x;
		//audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
		enemyTime -= Time.deltaTime;
		
		if (volta) {
			xVal += 0.02f;
		} else {
			xVal -= 0.02f;
		}
		
		//transform.Translate(direction*speed*Time.deltaTime);
		
		
		if(enemyTime < 0){
			if (volta) {
				volta = false;
			}else if(!volta){
				volta = true;
			}
			enemyTime = 2f;
		}
		
		RandomWalk = Random.Range(0, 10);
		RandomJump = Random.Range(0, 99);
		RandomAttack = Random.Range(0, 99);
		RandomAttackSpecial = Random.Range(0, 1000);
		

		
		if(RandomJump == 10){
			rb.AddForce(Vector2.up * JumpForce);
		}
		
	
		if(RandomAttack == 10){
			//audio.PlayOneShot(AttackSound, 0.7F);
			Instantiate(axePrefab, new Vector3(transform.position.x+1,transform.position.y,0), Quaternion.identity);
		}
		
		if(RandomAttackSpecial == 10){
			//audio.PlayOneShot(AttackSound, 0.7F);
			//audio.PlayOneShot(AttackSound, 0.7F);
			//audio.PlayOneShot(AttackSound, 0.7F);
			Instantiate(axePrefab, new Vector3(transform.position.x+1,transform.position.y,0), Quaternion.identity);
			Instantiate(axePrefab, new Vector3(transform.position.x+1,transform.position.y+1,0), Quaternion.identity);
			Instantiate(axePrefab, new Vector3(transform.position.x+1,transform.position.y-1,0), Quaternion.identity);
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D col){
		
		if(col.gameObject.tag == "sword" ){
			hp = hp - 10;
			rb.AddForce(Vector2.left * 1000f);
			print("enemy levou 10 de dano");
			if(hp<0){
				    Destroy(gameObject);
			}
			
		}		
	}
}



