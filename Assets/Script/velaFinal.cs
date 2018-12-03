using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class velaFinal : MonoBehaviour {
	public GameObject finalBoss;
	public Text uiText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D col){		

		if(col.gameObject.tag == "sword"){
			print("vela colidiuu com espada");
			 if(finalBoss != null){
				 finalBoss.gameObject.SetActive(true);
				 uiText.text	= "You released the ancient evil.";
			 }
			 Destroy(gameObject);
		}			
	}
}
