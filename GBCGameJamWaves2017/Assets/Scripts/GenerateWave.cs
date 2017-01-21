using UnityEngine;
using System.Collections;



//Kenneth Mak
//From www.youtube.com/watch?v=f6cAAjMfPs8 - channel Mario Haberle

public class GenerateWave : MonoBehaviour {


	[Range(0.1f, 20.0f)]
	public float heightScale = 5.0f; //how high they can reach

	[Range(0.1f, 40.0f)]
	public float detailScale = 5.0f; //how smooth the waves are

	private Mesh myMesh;
	private Vector3[] vertices;



	public bool waves = false; //whether  they are animated or not
	public float wavesSpeed = 5.0f; //how fast they take to reach a point


	void FixedUpdate(){
		createWave ();
	}


	void createWave(){
		myMesh = GetComponent<MeshFilter> ().mesh;
		vertices = myMesh.vertices;

		int counter = 0;
		int yLevel = 0;

		for (int i = 0; i < 11; i++) {
			for (int j = 0; j < 11; j++) {
				CalculationMethod (counter, yLevel); //changing vertices here and applying them later
				counter++;
			}
			yLevel++;
		}
		myMesh.vertices = vertices;
		myMesh.RecalculateBounds ();
		myMesh.RecalculateNormals ();
		//recreating the mesh collider to suit the new bounds
		Destroy (GetComponent<MeshCollider> ());
		MeshCollider collider = gameObject.AddComponent<MeshCollider> ();
		collider.sharedMesh = null;
		collider.sharedMesh = myMesh;
	}


	void CalculationMethod(int i, int j){
		if (waves) {
			vertices [i].z = Mathf.PerlinNoise (
				Time.time / wavesSpeed + (vertices [i].x + transform.position.x) / detailScale,
				Time.time / wavesSpeed + (vertices [i].y + transform.position.y) / detailScale) * heightScale;
			vertices [i].z -= j;


		} else if (!waves) {
			vertices[i].z = Mathf.PerlinNoise(
				(vertices[i].x+transform.position.x)/detailScale,
				(vertices[i].y+transform.position.y)/detailScale) * heightScale;
			vertices [i].z -= j;
		}

	}


}
