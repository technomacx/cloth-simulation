using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

	public GameObject mAtom2;
	private static float mKs = 100f;
    public float mStartDistanceMag,mCurrentDistanceMag,mForce,mDeltaX;

	private Vector3 mStartDistance,mCurrentDistance;

	// Use this for initialization
	void Start () {
        mStartDistance = this.transform.position - mAtom2.transform.position;
        mStartDistanceMag = Mathf.Sqrt(mStartDistance.x*mStartDistance.x +mStartDistance.y * mStartDistance.y +mStartDistance.z * mStartDistance.z );
	}
	
	// Update is called once per frame
	void Update () {
       // mCurrentDistance = this.transform.position - mAtom2.transform.position;
	//	mCurrentDistanceMag=Mathf.Round(Mathf.Sqrt(mCurrentDistance.x * mCurrentDistance.x + mCurrentDistance.y * mCurrentDistance.y + mCurrentDistance.z * mCurrentDistance.z));
      //  mDeltaX = mCurrentDistanceMag - mStartDistanceMag;
       // mForce = -mKs * mDeltaX;
    }


    public Vector3 GetForce()
    {
        mCurrentDistance = this.transform.position - mAtom2.transform.position;
        mCurrentDistanceMag = Mathf.Round(Mathf.Sqrt(mCurrentDistance.x * mCurrentDistance.x + mCurrentDistance.y * mCurrentDistance.y + mCurrentDistance.z * mCurrentDistance.z));
        mDeltaX = mCurrentDistanceMag - mStartDistanceMag;
        mForce = -mKs * mDeltaX;
		float x = Vector3.Angle(mCurrentDistance , Vector3.right);
        float y = Vector3.Angle(mCurrentDistance, Vector3.up);
        float z = Vector3.Angle(mCurrentDistance, Vector3.right);
		return new Vector3 (x*Mathf.Sin(x*Mathf.Deg2Rad), y * Mathf.Sin(y * Mathf.Deg2Rad), z * Mathf.Sin(z * Mathf.Deg2Rad));
    }
}