using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

	public GameObject mAtom2;
	private static float mKs = 0.1f;
	public float mStartDistanceMag, mCurrentDistanceMag, mForce, mDeltaX;

	private Vector3 mStartDistance, mCurrentDistance;

	// Use this for initialization
	void Start ()
	{
		mStartDistance = this.transform.position - mAtom2.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// mCurrentDistance = this.transform.position - mAtom2.transform.position;
		//	mCurrentDistanceMag=Mathf.Round(Mathf.Sqrt(mCurrentDistance.x * mCurrentDistance.x + mCurrentDistance.y * mCurrentDistance.y + mCurrentDistance.z * mCurrentDistance.z));
		//  mDeltaX = mCurrentDistanceMag - mStartDistanceMag;
		// mForce = -mKs * mDeltaX;
	}


	public Vector3 GetForce ()
	{
		mCurrentDistance = new Vector3 (this.transform.position.x, 0f, 0f);
		return new Vector3 (-2.5f*mCurrentDistance.x, 0f, 0f); 
		/*mCurrentDistance = this.transform.position - mAtom2.transform.position;
		mDeltaX =mCurrentDistance.magnitude- mStartDistance.magnitude;
		print (mCurrentDistance.magnitude.ToString() + "==" + mStartDistance.magnitude.ToString());
		if (mDeltaX == 0) {
			print ("Spring zero");
			return new Vector3 (0, 0, 0);
		}
		mCurrentDistance /= mCurrentDistance.magnitude;
		print ("sss" + mCurrentDistance.magnitude);
		mCurrentDistance *= -mKs * mDeltaX;
		//print ("deltaX= " + mDeltaX);
		//print ("curSPring Force= " + mCurrentDistance.ToString ());
		return mCurrentDistance;
		//mCurrentDistanceMag = Mathf.Round(Mathf.Sqrt(mCurrentDistance.x * mCurrentDistance.x + mCurrentDistance.y * mCurrentDistance.y + mCurrentDistance.z * mCurrentDistance.z));
		//mDeltaX = mCurrentDistanceMag - mStartDistanceMag;
		//mForce = -mKs * mDeltaX;
		//float x = Vector3.Angle(mCurrentDistance , Vector3.right);
		//float y = Vector3.Angle(mCurrentDistance, Vector3.up);
		//float z = Vector3.Angle(mCurrentDistance, Vector3.right);
		//return new Vector3 (x*Mathf.Sin(x*Mathf.Deg2Rad), y * Mathf.Sin(y * Mathf.Deg2Rad), z * Mathf.Sin(z * Mathf.Deg2Rad));
	*/}
}