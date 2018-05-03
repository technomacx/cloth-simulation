using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

	public GameObject mAtom1,mAtom2;
	private static float mKs = 0.1f;
    public float mStartDistanceMag1, mCurrentDistanceMag1, mForce1, mDeltaX1;
	public float mStartDistanceMag2, mCurrentDistanceMag2, mForce2, mDeltaX2;

    private Vector3 mStartDistance1, mCurrentDistance1;
	private Vector3 mStartDistance2, mCurrentDistance2;

	// Use this for initialization
	void Start ()
	{
        mStartDistance1 = this.transform.position - mAtom1.transform.position;
        mStartDistance2 = this.transform.position - mAtom2.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
	{
		// mCurrentDistance = this.transform.position - mAtom1.transform.position;
		//	mCurrentDistanceMag=Mathf.Round(Mathf.Sqrt(mCurrentDistance.x * mCurrentDistance.x + mCurrentDistance.y * mCurrentDistance.y + mCurrentDistance.z * mCurrentDistance.z));
		//  mDeltaX = mCurrentDistanceMag - mStartDistanceMag;
		// mForce = -mKs * mDeltaX;
	}


	public Vector3 GetForce ()
	{
		return GetForce1() + GetForce2() ;
	}
    public Vector3 GetForce1()
    {
        //mCurrentDistance = new Vector3 (this.transform.position.x, 0f, 0f);
        //return new Vector3 (-2.5f*mCurrentDistance.x, 0f, 0f); 
        mCurrentDistance1 = this.transform.position - mAtom1.transform.position;
        mDeltaX1 = mCurrentDistance1.magnitude - mStartDistance1.magnitude;
        print(mCurrentDistance1.magnitude.ToString() + "==" + mStartDistance1.magnitude.ToString());
        if (mDeltaX1 == 0)
        {
            print("Spring zero");
            return new Vector3(0, 0, 0);
        }
        mCurrentDistance1 /= mCurrentDistance1.magnitude;
        print("sss" + mCurrentDistance1.magnitude);
        mCurrentDistance1 *= -mKs * mDeltaX1;
        //print ("deltaX= " + mDeltaX);
        //print ("curSPring Force= " + mCurrentDistance.ToString ());
        return mCurrentDistance1;
        //mCurrentDistanceMag = Mathf.Roun1d(Mathf.Sqrt(mCurrentDistance.x * mCurrentDistance.x + mCurrentDistance.y * mCurrentDistance.y + mCurrentDistance.z * mCurrentDistance.z));
        //mDeltaX = mCurrentDistanceMag - mStartDistanceMag;
        //mForce = -mKs * mDeltaX;
        //float x = Vector3.Angle(mCurrentDistance , Vector3.right);
        //float y = Vector3.Angle(mCurrentDistance, Vector3.up);
        //float z = Vector3.Angle(mCurrentDistance, Vector3.right);
        //return new Vector3 (x*Mathf.Sin(x*Mathf.Deg2Rad), y * Mathf.Sin(y * Mathf.Deg2Rad), z * Mathf.Sin(z * Mathf.Deg2Rad));
    }
    public Vector3 GetForce2()
    {
        //mCurrentDistance = new Vector3 (this.transform.position.x, 0f, 0f);
        //return new Vector3 (-2.5f*mCurrentDistance.x, 0f, 0f); 
        mCurrentDistance2 = this.transform.position - mAtom2.transform.position;
        mDeltaX2 = mCurrentDistance2.magnitude - mStartDistance2.magnitude;
        print(mCurrentDistance2.magnitude.ToString() + "==" + mStartDistance2.magnitude.ToString());
        if (mDeltaX2 == 0)
        {
            print("Spring zero");
            return new Vector3(0, 0, 0);
        }
        mCurrentDistance2 /= mCurrentDistance2.magnitude;
        print("sss" + mCurrentDistance2.magnitude);
        mCurrentDistance2 *= -mKs * mDeltaX2;
        //print ("deltaX= " + mDeltaX);
        //print ("curSPring Force= " + mCurrentDistance.ToString ());
        return mCurrentDistance2;
        //mCurrentDistanceMag = Mathf.Round(Mathf.Sqrt(mCurrentDistance.x * mCurrentDistance.x + mCurrentDistance.y * mCurrentDistance.y + mCurrentDistance.z * mCurrentDistance.z));
        //mDeltaX = mCurrentDistanceMag - mStartDistanceMag;
        //mForce = -mKs * mDeltaX;
        //float x = Vector3.Angle(mCurrentDistance , Vector3.right);
        //float y = Vector3.Angle(mCurrentDistance, Vector3.up);
        //float z = Vector3.Angle(mCurrentDistance, Vector3.right);
        //return new Vector3 (x*Mathf.Sin(x*Mathf.Deg2Rad), y * Mathf.Sin(y * Mathf.Deg2Rad), z * Mathf.Sin(z * Mathf.Deg2Rad));
    }
}