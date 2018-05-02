using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//transform.position=new Vector3(-2,0.5f * -9.8f * Time.timeSinceLevelLoad*Time.timeSinceLevelLoad,0);
		//print ("Test" + transform.position.y.ToString ());
		//this.transform.position= new Vector3((-2f*this.transform.position.x),5f,0f);
		this.transform.position= new Vector3((2.5f*Mathf.Cos((Mathf.PI/2)*Time.timeSinceLevelLoad)),5f,0f);

	}
}
