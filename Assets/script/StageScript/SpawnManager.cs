using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    public GameObject spearPrefab;
    public void spawnObstacle(RowData row)
    {
        Vector3 spawnPos = new Vector3(row.columns[0]*2+1,row.columns[1]*2+1,row.columns[2]*2+1);
        Debug.Log(spawnPos);
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }

    public void spawnCoin(RowData row)
    {
        Vector3 spawnPos = new Vector3(row.columns[0]*2+1,row.columns[1]*2+1,row.columns[2]*2+1);
        Debug.Log(spawnPos);
        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }



}
