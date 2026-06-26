using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public GameObject[] stages;
    void Awake()
    {
        MapFile recordFile = new MapFile
        {
            records = new List<MapData>(MapDataManager.Instance.GetAllRecords().Values)
        };

        foreach(MapData data in recordFile.records)
        {
            
        }
    }
}