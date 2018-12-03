using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vela : MonoBehaviour {
	
	public bool candleActive; 
	public GameObject doorOpened;
	public GameObject doorClosed;
	public GameObject candleOn;
	public GameObject candleOff;
	
	// Use this for initialization
	void Start () {
		candleActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(candleActive){
			doorOpened.gameObject.SetActive (true);
			doorClosed.gameObject.SetActive (false);
			candleOff.gameObject.SetActive (false);
			candleOn.gameObject.SetActive  (true);
		}
	}
	
	public void active(){
		candleActive = true;
	}
}
