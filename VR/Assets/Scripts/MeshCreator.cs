using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator : MonoBehaviour
{

	public GameObject mesh, atom;
	public GameObject corner1, corner2,corner3,corner4;

	private GameObject[,] atomArray;
	public int length, width;
	public float xOffset, yOffset;
	public float Ks, Kd;
	// Use this for initialization
	void Start ()
	{
		Spring.mKd = Kd;
		Spring.mKs = Ks;
		atomArray = new GameObject[width, length];
		for (int i = 0; i < length; i++) {
			for (int j = 0; j < width; j++) {
				atomArray [j, i] = Instantiate (atom, new Vector3 (j * xOffset, 3, i * yOffset), Quaternion.identity, mesh.transform);
			}
		}
		for (int i = 0; i < length; i++) {
			for (int j = 0; j < width; j++) {
				if (j < width - 1) {
					atomArray [j, i].GetComponent<Spring> ().mAtom1 = atomArray [j + 1, i];
				}
				if (j > 0) {
					atomArray [j, i].GetComponent<Spring> ().mAtom2 = atomArray [j - 1, i];
				}
				if (i < length - 1) {
					atomArray [j, i].GetComponent<Spring> ().mAtom3 = atomArray [j, i + 1];
				}
				if (i > 0) {
					atomArray [j, i].GetComponent<Spring> ().mAtom4 = atomArray [j, i - 1];
				}
			}
			atomArray [0, 0].GetComponent<Spring> ().mAtom2 = corner1;
			atomArray [0, length-1].GetComponent<Spring> ().mAtom2 = corner2;
			atomArray [width-1, 0].GetComponent<Spring> ().mAtom1 = corner3;
			atomArray [width-1, length-1].GetComponent<Spring> ().mAtom1 =corner4;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
