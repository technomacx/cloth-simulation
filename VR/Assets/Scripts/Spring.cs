using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

	public GameObject mAtom1, mAtom2, mAtom3, mAtom4;
	public static float mKs = 0.1f, mKd = 0.01f;
	private float mStartDistanceMag1, mCurrentDistanceMag1, mForce1, mDeltaX1;
	private float mStartDistanceMag2, mCurrentDistanceMag2, mForce2, mDeltaX2;
	private float mStartDistanceMag3, mCurrentDistanceMag3, mForce3, mDeltaX3;
	private float mStartDistanceMag4, mCurrentDistanceMag4, mForce4, mDeltaX4;

	private Vector3 mStartDistance1, mCurrentDistance1;
	private Vector3 mStartDistance2, mCurrentDistance2;

	private Vector3 mStartDistance3, mCurrentDistance3;
	private Vector3 mStartDistance4, mCurrentDistance4;

	// Use this for initialization
	void Start ()
	{
		if (mAtom1 != null) {
			mStartDistance1 = this.transform.position - mAtom1.transform.position;
		}
		if (mAtom2 != null) {
			mStartDistance2 = this.transform.position - mAtom2.transform.position;
		}
		if (mAtom3 != null) {
			mStartDistance3 = this.transform.position - mAtom3.transform.position;
		}
		if (mAtom4 != null) {
			mStartDistance4 = this.transform.position - mAtom4.transform.position;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{

	}


	public Vector3 GetForce (Vector3 v)
	{
		return GetForce1 (v) + GetForce2 (v) + GetForce3 (v) + GetForce4 (v);
	}

	public Vector3 GetForce1 (Vector3 v)
	{
		if (mAtom1 == null) {
			return new Vector3 (0, 0, 0);
		}
		mCurrentDistance1 = this.transform.position - mAtom1.transform.position;        
		mDeltaX1 = mCurrentDistance1.magnitude - mStartDistance1.magnitude;
		if (mDeltaX1 > -0.1 && mDeltaX1 < 0.1) {
			return new Vector3 (0, 0, 0);
		}
		mCurrentDistance1 /= mCurrentDistance1.magnitude;
		float vl = v.x * mCurrentDistance1.x + v.y * mCurrentDistance1.y + v.z * mCurrentDistance1.z;
		mCurrentDistance1 *= (-mKs * mDeltaX1) - (mKd * vl);
		return mCurrentDistance1;
	}

	public Vector3 GetForce2 (Vector3 v)
	{
		if (mAtom2 == null) {
			return new Vector3 (0, 0, 0);
		}
		mCurrentDistance2 = this.transform.position - mAtom2.transform.position;
		mDeltaX2 = mCurrentDistance2.magnitude - mStartDistance2.magnitude;
		if (mDeltaX2 == 0) {
			return new Vector3 (0, 0, 0);
		}
		mCurrentDistance2 /= mCurrentDistance2.magnitude;
		float vl = v.x * mCurrentDistance2.x + v.y * mCurrentDistance2.y + v.z * mCurrentDistance2.z;
		mCurrentDistance2 *= (-mKs * mDeltaX2) - (mKd * vl);

		return mCurrentDistance2;
	}

	public Vector3 GetForce3 (Vector3 v)
	{
		if (mAtom3 == null) {
			return new Vector3 (0, 0, 0);
		}
		mCurrentDistance3 = this.transform.position - mAtom3.transform.position;
		mDeltaX3 = mCurrentDistance3.magnitude - mStartDistance3.magnitude;
		if (mDeltaX3 == 0) {
			return new Vector3 (0, 0, 0);
		}
		mCurrentDistance3 /= mCurrentDistance3.magnitude;
		float vl = v.x * mCurrentDistance3.x + v.y * mCurrentDistance3.y + v.z * mCurrentDistance3.z;
		mCurrentDistance3 *= (-mKs * mDeltaX3) - (mKd * vl);

		return mCurrentDistance3;
	}

	public Vector3 GetForce4 (Vector3 v)
	{
		if (mAtom4 == null) {
			return new Vector3 (0, 0, 0);
		}
		mCurrentDistance4 = this.transform.position - mAtom4.transform.position;
		mDeltaX4 = mCurrentDistance4.magnitude - mStartDistance4.magnitude;
		if (mDeltaX4 == 0) {
			return new Vector3 (0, 0, 0);
		}
		mCurrentDistance4 /= mCurrentDistance4.magnitude;
		float vl = v.x * mCurrentDistance4.x + v.y * mCurrentDistance4.y + v.z * mCurrentDistance4.z;
		mCurrentDistance4 *= (-mKs * mDeltaX4) - (mKd * vl);

		return mCurrentDistance4;
	}
}




/*       //mCurrentDistance = new Vector3 (this.transform.position.x, 0f, 0f);
//return new Vector3 (-2.5f*mCurrentDistance.x, 0f, 0f); 
mCurrentDistance4 = this.transform.position - mAtom4.transform.position;
//float vl = v.magnitude * Mathf.Cos(Vector3.Angle(v, mCurrentDistance2));

//print("vl2:" + vl);
mDeltaX4 = mCurrentDistance4.magnitude - mStartDistance4.magnitude;
print(mCurrentDistance4.magnitude.ToString() + "==" + mStartDistance4.magnitude.ToString());
if (mDeltaX4 == 0)
{
	print("Spring zero");
	return new Vector3(0, 0, 0);
}
mCurrentDistance4 /= mCurrentDistance4.magnitude;
float vl = v.x * mCurrentDistance4.x + v.y * mCurrentDistance4.y + v.z * mCurrentDistance4.z;

//float vl = this.GetComponent<Transform>().position.magnitude - mAtom4.GetComponent<Transform>().position.magnitude;

print("sss" + mCurrentDistance4.magnitude);
mCurrentDistance4 *= (-mKs * mDeltaX4) - (mKd * vl);
//print ("deltaX= " + mDeltaX);
//print ("curSPring Force= " + mCurrentDistance.ToString ());
return mCurrentDistance4;
//mCurrentDistanceMag = Mathf.Round(Mathf.Sqrt(mCurrentDistance.x * mCurrentDistance.x + mCurrentDistance.y * mCurrentDistance.y + mCurrentDistance.z * mCurrentDistance.z));
//mDeltaX = mCurrentDistanceMag - mStartDistanceMag;
//mForce = -mKs * mDeltaX;
//float x = Vector3.Angle(mCurrentDistance , Vector3.right);
//float y = Vector3.Angle(mCurrentDistance, Vector3.up);
//float z = Vector3.Angle(mCurrentDistance, Vector3.right);
//return new Vector3 (x*Mathf.Sin(x*Mathf.Deg2Rad), y * Mathf.Sin(y * Mathf.Deg2Rad), z * Mathf.Sin(z * Mathf.Deg2Rad));
*/