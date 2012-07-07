using UnityEngine;
using System.Collections;
using System;

public class SimplexTerrainGenerator : IGenerateTerrain {

	public void GenerateTerrain(WorldData world)
	{
		for(int x=0; x<world.points.GetLength(0); x++)
		{
			for(int y=0; y<world.points.GetLength(1); y++)
			{
				int height = (int)Mathf.Clamp((5*world.points.GetLength(2)*(SimplexNoise.noise(x/50f, y/50f, 0)) + 0.35f), 1f, 5f);
				
				for (int z=0; z<world.points.GetLength(2); z++)
				{
					//world.points[x,y,z] = false;
					//if (z<3) world.points[x,y,z] = true;
					//if (x==4 && y==4 && z==3) world.points[x,y,z] = true;
					world.points[x,y,z] = z > height;
				}
			}
		}
	}
	
}
