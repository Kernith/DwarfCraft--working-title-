using UnityEngine;
using System.Collections;

public class WorldData {
	
	public int ChunkXSize = 75;
	public int ChunkYSize = 75;
	public int ZSize = 10;
	
	public IGenerateTerrain TerrainGenerator;
	public IMeshGenerator MeshGenerator;
	
	public bool[,,] points;
	
	public Vector3[] vertices;
	public Vector2[] uvRays;
	public int[] triangles;
	
	public WorldData(): this(new TestTerrainGenerator(), new MarchingCubesMeshGenerator())
	{
	}
	
	public WorldData(IGenerateTerrain terrGen, IMeshGenerator meshGen)
	{
		points = new bool[ChunkXSize,ChunkYSize,ZSize];
		TerrainGenerator = terrGen;
		MeshGenerator = meshGen;
		TerrainGenerator.GenerateTerrain(this);
		MeshGenerator.GenerateMesh(this);
	}
}
