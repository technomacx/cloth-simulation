﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshFilter))]
public class MeshCreator : MonoBehaviour
{
	Mesh mesh1;

	Vector3[] vertices;
	int[] triangles;

	public GameObject mesh, atom;
	public GameObject corner1, corner2, corner3, corner4;
	public Texture sss;

	private GameObject[,] atomArray;
	public int length, width;
	public float xOffset, yOffset;
	public float Ks, Kd, KsSh , kbending;
	// Use this for initialization
	void Awake ()
	{
		mesh1 = GetComponent<MeshFilter> ().mesh;
	}

	void Start ()
	{
		Spring.mKd = Kd;
		Spring.mKs = Ks;
		Spring.mKsSh = KsSh;
		Spring.mKsBn = kbending;
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

				if (i > 0 && j > 0) {
					atomArray [j, i].GetComponent<Spring> ().mAtom5 = atomArray [j - 1, i - 1];
				}
				if (i < length - 1 && j < width - 1) {
					atomArray [j, i].GetComponent<Spring> ().mAtom6 = atomArray [j + 1, i + 1];
				}
				if (i < length - 1 && j > 0) {
					atomArray [j, i].GetComponent<Spring> ().mAtom7 = atomArray [j - 1, i + 1];
				}
				if (i > 0 && j < width - 1) {
					atomArray [j, i].GetComponent<Spring> ().mAtom8 = atomArray [j + 1, i - 1];
				}

				if (j < width - 2) {
					atomArray [j, i].GetComponent<Spring> ().mAtom9 = atomArray [j + 2, i];
				}
				if (j > 1) {
					atomArray [j, i].GetComponent<Spring> ().mAtom10 = atomArray [j - 2, i];
				}
				if (i < length - 2) {
					atomArray [j, i].GetComponent<Spring> ().mAtom11 = atomArray [j, i + 2];
				}
				if (i > 1) {
					atomArray [j, i].GetComponent<Spring> ().mAtom12 = atomArray [j, i - 2];
				}
			}
			atomArray [0, 0].GetComponent<Spring> ().mAtom2 = corner1;
			atomArray [0, length - 1].GetComponent<Spring> ().mAtom2 = corner2;
			atomArray [width - 1, 0].GetComponent<Spring> ().mAtom1 = corner3;
			atomArray [width - 1, length - 1].GetComponent<Spring> ().mAtom1 = corner4;
		}
		vertices = new Vector3[width * length];
		triangles = new int[(width) * (length - 1) * 6];
		int q = 0;
		for (int i = 0; i < length; i++) {
			for (int j = 0; j < width; j++) {
				if (j != width - 1 && i != length - 1) {
					triangles [q++] = (i * width) + j;
					triangles [q++] = (i * width) + j + 1;
					triangles [q++] = ((1 + i) * width) + j;
				}
				if (j != 0 && i != 0) {
					triangles [q++] = (i * width) + j;
					triangles [q++] = (i * width) + j - 1;
					triangles [q++] = ((-1 + i) * width) + j;
				}
			}
		}
		gameObject.GetComponent<Renderer> ().material.mainTexture = sss;
		MakeMeshData ();
		CreateMesh ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		MakeMeshData ();
		CreateMesh ();
	}

	void MakeMeshData ()
	{
		int q = 0;
		for (int i = 0; i < length; i++) {
			for (int j = 0; j < width; j++) {
				vertices [q++] = atomArray [i, j].transform.position;
			}
		}
	}

	void CreateMesh ()
	{
		mesh1.Clear ();
		mesh1.vertices = vertices;
		mesh1.triangles = triangles;
	}
}
