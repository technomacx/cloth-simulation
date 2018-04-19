using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToatalForce : MonoBehaviour {

	Vector3 mGravity,mSpring,mTotalForce;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float mXPos,mYPos,mZPos;
        mGravity = this.GetComponent<Gravity>().GetForce();
        mSpring = this.GetComponent<Spring>().GetForce();
        mTotalForce = mGravity + mSpring;
        print(mTotalForce.ToString());
		//mXPos = 0.5f * g * Mathf.Pow(Time.timeSinceLevelLoad,2);
        //mYPos = 0.5f * g * Mathf.Pow(Time.timeSinceLevelLoad,2);
       // mZPos = 0.5f * g * Mathf.Pow(Time.timeSinceLevelLoad,2);
        //this.GetComponent<Transform>().position = new Vector3( mPos.position.x , -mYPos , mPos.position.z);	
    }
}
