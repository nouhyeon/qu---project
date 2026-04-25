using UnityEngine;


[System.Serializable]
public class RowData
{
    public int[] columns;
}

[System.Serializable]
public class GridManager
{
    public RowData[] rows;
}
