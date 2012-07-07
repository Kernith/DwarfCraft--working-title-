using System.Collections;

public class TestTerrainGenerator : IGenerateTerrain{

	public void GenerateTerrain(WorldData world)
	{
		var rand = new System.Random();
		for(int x=0; x<world.points.GetLength(0); x++)
		{
			for(int y=0; y<world.points.GetLength(1); y++)
			{
				int height = rand.Next(4);
				
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
