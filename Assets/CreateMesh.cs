using UnityEngine;
using System.Collections;

public class CreateMesh : MonoBehaviour {
	
	
	public float speed = 10;
	/*
	Vector3 p0 = new Vector3(0,0,0);
	Vector3 p1 = new Vector3(1,0,0);
	Vector3 p2 = new Vector3(0.5f,0,Mathf.Sqrt(0.75f));
	Vector3 p3 = new Vector3(0.5f,Mathf.Sqrt(0.75f),Mathf.Sqrt(0.75f)/3);

	Vector2 uv3a = new Vector2(0,0);
	Vector2 uv1  = new Vector2(0.5f,0);
	Vector2 uv0  = new Vector2(0.25f,Mathf.Sqrt(0.75f)/2);
	Vector2 uv2  = new Vector2(0.75f,Mathf.Sqrt(0.75f)/2);
	Vector2 uv3b = new Vector2(0.5f,Mathf.Sqrt(0.75f));
	Vector2 uv3c = new Vector2(1,0);
	 
	int[] newTriangles = new int[]
	{
		0, 1, 2,
		3, 4, 5,
		6, 7, 8,
		9, 10, 11
	};
	// Use this for initialization
	void Start () {
		Vector3[] newVertices = new Vector3[]
		{
			p0,p1,p2,
			p0,p2,p3,
			p2,p1,p3,
			p0,p3,p1
		};
		Vector2[] newUV = new Vector2[]
		{
	    	uv0,uv1,uv2,
	    	uv0,uv2,uv3b,
	    	uv0,uv1,uv3a,
	    	uv1,uv2,uv3c
		};
		var meshfilter = GetComponent<MeshFilter>();
		var mesh = new Mesh();
		meshfilter.mesh = mesh;
		mesh.vertices = newVertices;
		mesh.uv = newUV;
		mesh.triangles = newTriangles;
		//mesh.RecalculateNormals();
		var thing = GetComponent<MeshRenderer>();
	}
	*/

	public WorldData world;
	public IMeshGenerator meshGen;
	public IGenerateTerrain terrGen;
	
	void Start () {
		terrGen = new SimplexTerrainGenerator();
		meshGen = new MarchingCubesMeshGenerator();
		world = new WorldData(terrGen, meshGen);
		transform.Rotate(new Vector3(2, 2, 2));
		var meshfilter = GetComponent<MeshFilter>();
		Mesh mesh = new Mesh();
		mesh.vertices = world.vertices;
		mesh.uv = world.uvRays;
		mesh.triangles = world.triangles;
		//meshfilter.mesh.vertices = world.vertices;
		//meshfilter.mesh.uv = world.uvRays;
		//meshfilter.mesh.triangles = world.triangles;
		meshfilter.mesh = mesh;
		
		mesh.RecalculateNormals();
		var meshcollider = GetComponent<MeshCollider>();
		meshcollider.sharedMesh = mesh;
		//var thing = GetComponent<MeshRenderer>();
	}

	
	// Update is called once per frame
	void Update () {
	}
}
