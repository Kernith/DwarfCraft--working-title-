using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MarchingCubesMeshGenerator : IMeshGenerator
{
	List<Vector3> vertices;
	List<Vector2> uvRays;
	List<int> triangles;
	
	public void GenerateMesh (WorldData world)
	{
		vertices = new List<Vector3> ();
		uvRays = new List<Vector2> ();
		triangles = new List<int> ();
		var points = world.points;
		for (int x=0; x < points.GetLength(0) - 1; x++) {
			for (int y=0; y < points.GetLength(1) - 1; y++) {
				for (int z=0; z < points.GetLength(2) - 1; z++) {
					AddToMesh (points [x, y, z], points [x + 1, y, z],
							   points [x + 1, y + 1, z], points [x, y + 1, z],
							   points [x, y, z + 1], points [x + 1, y, z + 1],
							   points [x + 1, y + 1, z + 1], points [x, y + 1, z + 1],
							   x, y, z);
				}
			}
		}
		world.vertices = vertices.ToArray ();
		world.uvRays = uvRays.ToArray ();
		world.triangles = triangles.ToArray ();
	}

	private void AddToMesh (bool pt0, bool pt1, bool pt2, bool pt3,
						   bool pt4, bool pt5, bool pt6, bool pt7, float x, float y, float z)
	{
		int triNum = 	(pt0 ? 1 : 0) +
						(pt1 ? 2 : 0) +
						(pt2 ? 4 : 0) +
						(pt3 ? 8 : 0) +
						(pt4 ? 16 : 0) +
						(pt5 ? 32 : 0) +
						(pt6 ? 64 : 0) +
						(pt7 ? 128 : 0);
		int[] numberedVertices = MarchingCubeLookupTable.TriangleTable [triNum];
		for (int i=0; numberedVertices[i]!=-1; i+=3) {
			int index = vertices.Count;
			vertices.Add (MarchingCubeLookupTable.VertexTable [numberedVertices [i]] + new Vector3(x, y, z));
			vertices.Add (MarchingCubeLookupTable.VertexTable [numberedVertices [i + 1]] + new Vector3(x, y, z));
			vertices.Add (MarchingCubeLookupTable.VertexTable [numberedVertices [i + 2]] + new Vector3(x, y, z));
			uvRays.Add (new Vector2 (0f, 0f));
			uvRays.Add (new Vector2 (1f, 0f));
			uvRays.Add (new Vector2 (0f, 1f));
			triangles.Add (index);
			triangles.Add (index + 1);
			triangles.Add (index + 2);
		}
	}
	

}