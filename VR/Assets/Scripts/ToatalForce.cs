using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToatalForce : MonoBehaviour
{

	Vector3 mGravity, mSpring, mTotalForce, ac, v, v1, p1, p;
	float m ;
	// Use this for initialization
	void Start ()
	{
		m = gameObject.GetComponent<Gravity>().mMass;
		//Vector3 dd= new Vector3 (2, 2, 6);
		//print( dd.ToString());
		//print( dd.magnitude);
		//print((dd/dd.magnitude).ToString());
		//print((dd/dd.magnitude).magnitude);



		mTotalForce = new Vector3 (0, 0, 0);
		v = new Vector3 (0, 0, 0);
		v1 = new Vector3 (0, 0, 0);
		ac = new Vector3 (0, 0, 0);
		p = this.transform.position;
		p1 = new Vector3 (0, 0, 0);
	}

    // Update is called once per frame

    void Update()
    {
    }
	
	void FixedUpdate ()
	{
		mGravity = this.GetComponent<Gravity> ().GetForce ();
		mSpring = this.GetComponent<Spring> ().GetForce (v);
		//mSpring= new Vector3 (-2.5f * this.transform.position.x, 0f, 0f);
		//print (mSpring.ToString ());
		mTotalForce = mGravity + mSpring;
		//print ("totoal="+mTotalForce.ToString ());
		ac = mTotalForce / m;   // f = m * a
		v1.x = v.x + ac.x * Time.deltaTime;
		v1.y = v.y + ac.y * Time.deltaTime;
		v1.z = v.z + ac.z * Time.deltaTime;

		p1.x = p.x + v1.x * Time.deltaTime;
		p1.y = p.y + v1.y * Time.deltaTime;
		p1.z = p.z + v1.z * Time.deltaTime;

		transform.position = p1;
		p = p1;
		v = v1;
	}
}
//float mXPos,mYPos,mZPos;
//mGravity =new Vector3(0,1,0); //this.GetComponent<Gravity>().GetForce();
//mSpring = new Vector3(1,0,0);//this.GetComponent<Spring>().GetForce();
//mTotalForce = mGravity + mSpring;
//Vector3 ac = mTotalForce/ 10;
//Vector3 v=
//print(mTotalForce.ToString());
//print(ac.ToString());
//mXPos = 0.5f * g * Mathf.Pow(Time.timeSinceLevelLoad,2);
//mYPos = 0.5f * g * Mathf.Pow(Time.timeSinceLevelLoad,2);
// mZPos = 0.5f * g * Mathf.Pow(Time.timeSinceLevelLoad,2);
//this.GetComponent<Transform>().position = new Vector3( mPos.position.x , -mYPos , mPos.position.z);