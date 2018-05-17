using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

	// Use this for initialization
	public float rad;
	void Start () {
		rad=gameObject.transform.localScale.z *5/9.6f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
