using UnityEngine;
using System.Linq;
using System.Collections;

public class Fliparino : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh mesh = GetComponent<MeshFilter> ().mesh;
		mesh.triangles = mesh.triangles.Reverse ().ToArray ();
	}
}
