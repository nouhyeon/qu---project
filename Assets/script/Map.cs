using UnityEngine;

public class Map : MonoBehaviour
{
    public int mapXSize;
    public int mapYSize;
    public int mapZSize;

    public Vector3 endPoint;
    
    public bool[] mapData;

    public GridManager obstacleData;
    public GridManager coinData;

    public SpawnManager spawnManager;

   
    public void Awake()
    {
        mapData = new bool[mapXSize*mapYSize*mapZSize];
        foreach(RowData row in obstacleData.rows)
        {
            mapData[row.columns[0] + row.columns[1]*mapXSize + row.columns[2]*mapXSize*mapYSize] = true;
            spawnManager.spawnObstacle(row);
          
        }

        foreach(RowData row in coinData.rows)
        {
            spawnManager.spawnCoin(row);
        }
        

    } 
    
}





