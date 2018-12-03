using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3 : MonoBehaviour {
	public int hp;
	public int RandomAttack;
	public int RandomAttack2;
	public GameObject fireBall;
	public GameObject fireLaser;
	public GameObject friendsSoul;
	// Use this for initialization
void Start () {
		hp = 100;
	}
	
	void Update () {
		RandomAttack = Random.Range(0, 99);
		RandomAttack2 = Random.Range(0, 999);
		
		if(RandomAttack == 10){
			//audio.PlayOneShot(AttackSound, 0.7F);
			Instantiate(fireBall, new Vector3(transform.position.x+5,transform.position.y,0), Quaternion.identity);
		}
		
		if(RandomAttack2 == 10){
			//audio.PlayOneShot(AttackSound, 0.7F);
			Instantiate(fireLaser, new Vector3(transform.position.x+10,transform.position.y+2,0), Quaternion.identity);
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		
		if(col.gameObject.tag == "sword" ){
			hp = hp - 10;
			print("enemy levou 10 de dano");
			if(hp<0){
					Instantiate(friendsSoul, new Vector3(transform.position.x,transform.position.y,0), Quaternion.identity);
					Instantiate(friendsSoul, new Vector3(transform.position.x+1,transform.position.y,0), Quaternion.identity);
					Instantiate(friendsSoul, new Vector3(transform.position.x+2,transform.position.y,0), Quaternion.identity);
					Instantiate(friendsSoul, new Vector3(transform.position.x+3,transform.position.y,0), Quaternion.identity);
					Instantiate(friendsSoul, new Vector3(transform.position.x+4,transform.position.y,0), Quaternion.identity);
				    Destroy(gameObject);
			}
			
		}		
	}
}
