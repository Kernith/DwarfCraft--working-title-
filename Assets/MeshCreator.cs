using UnityEngine;
using System.Collections;

public class MeshCreator : MonoBehaviour {
	
	public WorldData world = new WorldData();
	public Transform prefab;
	
	// Use this for initialization
	void Start () {
		for(int x=0; x<world.points.GetLength(0); x++)
		{
			for(int y=0; y<world.points.GetLength(1); y++)
			{
				for (int z=0; z<world.points.GetLength(2); z++)
				{
					if (!world.points[x,y,z])
						Instantiate(prefab, new Vector3(x,y,z), transform.rotation);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
