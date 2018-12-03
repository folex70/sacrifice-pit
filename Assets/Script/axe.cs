using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour {

	public float xVal ;
	public float xVel ;
	public float duration;

	// Use this for initialization
	void Start () {
		//xVel = 0.1f;
		xVal = transform.position.x;
		Destroy(gameObject,duration);
	}
	
	// Update is called once per frame
	void Update () {		
		xVal += xVel;
		transform.position = new Vector3 (xVal,transform.position.y,0);
	}
	
	void OnCollisionEnter2D(Collision2D col){		
		if(col.gameObject.tag == "Player"  ){
			Destroy(gameObject);
		}	

		if(col.gameObject.tag == "sword"){
			 Destroy(gameObject);
		}			
	}
}
