using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBlock : MonoBehaviour {

	public Transform tf;
	public float upVal ;
	public bool upping = true;
	public float movTime;
	
	// Use this for initialization
	void Start () {
		upVal 	= tf.position.y;
		movTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		movTime += Time.deltaTime;
		
		if (upping) {
			upVal += 0.05f;
		} else {
			upVal -= 0.05f;
		} 

		if(movTime > 4){
			upping = !upping;
			movTime = 0;
		}


		tf.position = new Vector3 (tf.position.x, upVal, 0);	


	}
}
