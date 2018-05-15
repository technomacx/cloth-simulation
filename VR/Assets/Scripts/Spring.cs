using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

	public GameObject mAtom1, mAtom2, mAtom3, mAtom4;
	public GameObject mAtom5, mAtom6, mAtom7, mAtom8;
	public GameObject mAtom9, mAtom10, mAtom11, mAtom12;

	public static float mKs = 0.1f, mKd = 0.01f, mKsSh = 0.05f, mKsBn = 0.02f;
	/*private float mStartDistanceMag1, mCurrentDistanceMag1, mForce1, mDeltaX1;
	private float mStartDistanceMag2, mCurrentDistanceMag2, mForce2, mDeltaX2;
	private float mStartDistanceMag3, mCurrentDistanceMag3, mForce3, mDeltaX3;
	private float mStartDistanceMag4, mCurrentDistanceMag4, mForce4, mDeltaX4;
*/
	private Vector3 mStartDistance1/*, mCurrentDistance1*/;
	private Vector3 mStartDistance2/*, mCurrentDistance2*/;

	private Vector3 mStartDistance3/*, mCurrentDistance3*/;
	private Vector3 mStartDistance4/*, mCurrentDistance4*/;

	private Vector3 mStartDistance5/*, mCurrentDistance5*/;
	private Vector3 mStartDistance6/*, mCurrentDistance6*/;

	private Vector3 mStartDistance7/*, mCurrentDistance7*/;
	private Vector3 mStartDistance8/*, mCurrentDistance8*/;

	private Vector3 mStartDistance9;
	private Vector3 mStartDistance10;
	private Vector3 mStartDistance11;
	private Vector3 mStartDistance12;

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


		if (mAtom5 != null) {
			mStartDistance5 = this.transform.position - mAtom5.transform.position;
		}
		if (mAtom6 != null) {
			mStartDistance6 = this.transform.position - mAtom6.transform.position;
		}
		if (mAtom7 != null) {
			mStartDistance7 = this.transform.position - mAtom7.transform.position;
		}
		if (mAtom8 != null) {
			mStartDistance8 = this.transform.position - mAtom8.transform.position;
		}


		if (mAtom9 != null) {
			mStartDistance9 = this.transform.position - mAtom9.transform.position;
		}
		if (mAtom10 != null) {
			mStartDistance10 = this.transform.position - mAtom10.transform.position;
		}
		if (mAtom11 != null) {
			mStartDistance11 = this.transform.position - mAtom11.transform.position;
		}
		if (mAtom12 != null) {
			mStartDistance12 = this.transform.position - mAtom12.transform.position;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{

	}


	public Vector3 GetForce (Vector3 v)
	{
		return 
			GetStructureForce (v, mAtom1, mStartDistance1) + GetStructureForce (v, mAtom2, mStartDistance2) + GetStructureForce (v, mAtom3, mStartDistance3) + GetStructureForce (v, mAtom4, mStartDistance4)
			+ GetShearForce (v, mAtom5, mStartDistance5) + GetShearForce (v, mAtom6, mStartDistance6) + GetShearForce (v, mAtom7, mStartDistance7) + GetShearForce (v, mAtom8, mStartDistance8)
		+ GetBendForce (v, mAtom9, mStartDistance9) + GetBendForce (v, mAtom10, mStartDistance10) + GetBendForce (v, mAtom11, mStartDistance11) + GetBendForce (v, mAtom12, mStartDistance12);

		//return GetForce1 (v) + GetForce2 (v) + GetForce3 (v) + GetForce4 (v);
	}

	public Vector3 GetStructureForce (Vector3 v, GameObject atom, Vector3 StartDistance)
	{
		if (atom == null) {
			return new Vector3 (0, 0, 0);
		}

		Vector3 CurrentDistance = this.transform.position - atom.transform.position;        
		float DeltaX = CurrentDistance.magnitude - StartDistance.magnitude;
		if (DeltaX > -0.1 && DeltaX < 0.1) {
			return new Vector3 (0, 0, 0);
		}
		CurrentDistance /= CurrentDistance.magnitude;
		float vl1 = v.x * CurrentDistance.x + v.y * CurrentDistance.y + v.z * CurrentDistance.z;

		/*
		ToatalForce f2 = atom.GetComponent<ToatalForce> ();
		Vector3 v2 = new Vector3 (0, 0, 0);
		if (f2 != null) {
			v2 = f2.getVelocity ();
		}
		float vl2 = v2.x * CurrentDistance.x + v2.y * CurrentDistance.y + v2.z * CurrentDistance.z;
		*/

		CurrentDistance *= (-mKs * DeltaX) - (mKd * (vl1));
		return CurrentDistance;
	}

	public Vector3 GetShearForce (Vector3 v, GameObject atom, Vector3 StartDistance)
	{
		if (atom == null) {
			return new Vector3 (0, 0, 0);
		}

		Vector3 CurrentDistance = this.transform.position - atom.transform.position;        
		float DeltaX = CurrentDistance.magnitude - StartDistance.magnitude;
		if (DeltaX > -0.1 && DeltaX < 0.1) {
			return new Vector3 (0, 0, 0);
		}
		CurrentDistance /= CurrentDistance.magnitude;
		float vl1 = v.x * CurrentDistance.x + v.y * CurrentDistance.y + v.z * CurrentDistance.z;

		/*ToatalForce f2 = atom.GetComponent<ToatalForce> ();
		Vector3 v2 = new Vector3 (0, 0, 0);
		if (f2 != null) {
			v2 = f2.getVelocity ();
		}
		float vl2 = v2.x * CurrentDistance.x + v2.y * CurrentDistance.y + v2.z * CurrentDistance.z;
		*/
		CurrentDistance *= (-mKsSh * DeltaX) - (mKd * (vl1));
		return CurrentDistance;
	}

	public Vector3 GetBendForce (Vector3 v, GameObject atom, Vector3 StartDistance)
	{
		if (atom == null) {
			return new Vector3 (0, 0, 0);
		}

		Vector3 CurrentDistance = this.transform.position - atom.transform.position;        
		float DeltaX = CurrentDistance.magnitude - StartDistance.magnitude;
		if (DeltaX > -0.1 && DeltaX < 0.1) {
			return new Vector3 (0, 0, 0);
		}
		CurrentDistance /= CurrentDistance.magnitude;
		float vl1 = v.x * CurrentDistance.x + v.y * CurrentDistance.y + v.z * CurrentDistance.z;

		/*ToatalForce f2 = atom.GetComponent<ToatalForce> ();
		Vector3 v2 = new Vector3 (0, 0, 0);
		if (f2 != null) {
			v2 = f2.getVelocity ();
		}
		float vl2 = v2.x * CurrentDistance.x + v2.y * CurrentDistance.y + v2.z * CurrentDistance.z;
		*/
		CurrentDistance *= (-mKsBn * DeltaX) - (mKd * (vl1));
		return CurrentDistance;
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

/*public Vector3 GetForce1 (Vector3 v)
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
	float vl1 = v.x * mCurrentDistance1.x + v.y * mCurrentDistance1.y + v.z * mCurrentDistance1.z;

	ToatalForce f2 = mAtom1.GetComponent<ToatalForce> ();
	Vector3 v2 = new Vector3 (0, 0, 0);
	if (f2 != null) {
		v2 = f2.getVelocity ();
	}
	float vl2 = v2.x * mCurrentDistance1.x + v2.y * mCurrentDistance1.y + v2.z * mCurrentDistance1.z;

	mCurrentDistance1 *= (-mKs * mDeltaX1) - (mKd * (vl1-vl2));
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

	ToatalForce f2 = mAtom2.GetComponent<ToatalForce> ();
	Vector3 v2 = new Vector3 (0, 0, 0);
	if (f2 != null) {
		v2 = f2.getVelocity ();
	}
	float vl2 = v2.x * mCurrentDistance1.x + v2.y * mCurrentDistance1.y + v2.z * mCurrentDistance1.z;
	mCurrentDistance2 *= (-mKs * mDeltaX2) - (mKd * (vl-vl2));

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

	ToatalForce f2 = mAtom3.GetComponent<ToatalForce> ();
	Vector3 v2 = new Vector3 (0, 0, 0);
	if (f2 != null) {
		v2 = f2.getVelocity ();
	}
	float vl2 = v2.x * mCurrentDistance1.x + v2.y * mCurrentDistance1.y + v2.z * mCurrentDistance1.z;

	mCurrentDistance3 *= (-mKs * mDeltaX3) - (mKd * (vl-vl2));

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

	ToatalForce f2 = mAtom4.GetComponent<ToatalForce> ();
	Vector3 v2 = new Vector3 (0, 0, 0);
	if (f2 != null) {
		v2 = f2.getVelocity ();
	}
	float vl2 = v2.x * mCurrentDistance1.x + v2.y * mCurrentDistance1.y + v2.z * mCurrentDistance1.z;

	mCurrentDistance4 *= (-mKs * mDeltaX4) - (mKd * (vl-vl2));

	return mCurrentDistance4;
}*/