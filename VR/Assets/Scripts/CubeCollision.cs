using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour {

	// Use this for initialization
	public float x,y,z;
	void Start () {
		x=gameObject.transform.localScale.x *5/9.6f;
		y=gameObject.transform.localScale.y *5/9.6f;
		z=gameObject.transform.localScale.z *5/9.6f;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
