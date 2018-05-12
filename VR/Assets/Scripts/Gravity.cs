using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	static private float g=-9.8f;
	public float mMass;

	// Use this for initialization
	void Start () {
        //f=mg
        //mPos = this.GetComponent<Transform>();
        //mYPos = this.GetComponent<Transform>().position.y;
		//print(mYPos);
    }
	
	// Update is called once per frame
	void Update () {
		//mYPos = 0.5f * g * Mathf.Pow(Time.timeSinceLevelLoad,2);
    	//this.GetComponent<Transform>().position = new Vector3( mPos.position.x , -mYPos , mPos.position.z);
	}

	public Vector3 GetForce(){
		return new Vector3(0f,mMass * g,0f);
	} 
}
