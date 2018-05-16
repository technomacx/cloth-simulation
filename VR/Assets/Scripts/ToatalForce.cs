using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToatalForce : MonoBehaviour
{
	private GameObject[] ballColl, cubeColl;
	Vector3 mGravity, mSpring, mTotalForce, ac, v, v1, p1, p;
	float m;

	void Start ()
	{
		m = gameObject.GetComponent<Gravity> ().mMass;
		mTotalForce = new Vector3 (0, 0, 0);
		v = new Vector3 (0, 0, 0);
		v1 = new Vector3 (0, 0, 0);
		ac = new Vector3 (0, 0, 0);
		p = this.transform.position;
		p1 = new Vector3 (0, 0, 0);
		ballColl = GameObject.FindGameObjectsWithTag ("BallCollision");
		cubeColl = GameObject.FindGameObjectsWithTag ("CubeCollision");
	}

	// Update is called once per frame

	void Update ()
	{
	}

	void FixedUpdate ()
	{
		mGravity = this.GetComponent<Gravity> ().GetForce ();
		mSpring = this.GetComponent<Spring> ().GetForce (v);
		mTotalForce = mGravity + mSpring;
		checkCollisionWithBall1 ();
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
		checkCollisionWithBall ();
		//checkCollisionWithCube ();
	}

	public Vector3 getVelocity ()
	{
		return v;
	}

	private void checkCollisionWithBall ()
	{
		foreach (GameObject ball in ballColl) {
			float rad = ball.GetComponent<BallCollision> ().rad;
			float dis = (gameObject.transform.position - ball.transform.position).magnitude;
			if (dis > rad) {
				continue;
			}
			Vector3 np = gameObject.transform.position - ball.transform.position;
			np = np / np.magnitude;
			np *= rad + 0.1f;
			gameObject.transform.position = ball.transform.position + np;
			p = gameObject.transform.position;
		}
	}	
	private void checkCollisionWithBall1 ()
	{
		foreach (GameObject ball in ballColl) {
			float rad = ball.GetComponent<BallCollision> ().rad;
			float dis = (gameObject.transform.position - ball.transform.position).magnitude;
			if (dis > rad) {
				continue;
			}
			Vector3 np = gameObject.transform.position - ball.transform.position;
			if(Vector3.Angle (np, mTotalForce)>90)
			{
				mTotalForce +=np.normalized * mTotalForce.magnitude * Mathf.Cos (Vector3.Angle (np, mTotalForce))*5;
			}
		}
	}

	private void checkCollisionWithCube ()
	{
		foreach (GameObject cube in cubeColl) {
			float x = cube.GetComponent<CubeCollision> ().x;
			float y = cube.GetComponent<CubeCollision> ().y;
			float z = cube.GetComponent<CubeCollision> ().z;
			Vector3 pos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			if (Mathf.Abs (gameObject.transform.position.x - cube.transform.position.x) <= x &&
			    Mathf.Abs (gameObject.transform.position.y - cube.transform.position.y) <= y &&
			    Mathf.Abs (gameObject.transform.position.z - cube.transform.position.z) <= z) {

			}

		}
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