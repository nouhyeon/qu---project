using Unity.Collections;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Map map;

    public int characterSize;
    
    int gridX = 0;
    int gridY = 0;
    int gridZ = 0;

    Vector3 findMovePosition(int[] moveInfor)
    {
        int count = 0;
        int dx = moveInfor[0];
        int dy = moveInfor[1];
        int dz = moveInfor[2];
        while (true)
        {
            int nextX = gridX + dx;
            int nextY = gridY + dy;
            int nextZ = gridZ + dz;
            if(nextX<0 || nextX >= map.mapXSize
            ||nextY<0 || nextY >= map.mapYSize
            ||nextZ<0 || nextZ >= map.mapZSize)
            {
                break;
            }
            int checkIndex = nextX + nextY*map.mapXSize + nextZ*map.mapXSize*map.mapYSize;
            if (map.mapData[checkIndex])
            {
                break;
            }
            gridX = nextX; gridY = nextY; gridZ = nextZ;
            count++;
        }
        return new Vector3(
            transform.position.x + (count * dx * characterSize),
            transform.position.y + (count * dy * characterSize),
            transform.position.z + (count * dz * characterSize)
            );
    }
    public void CharacterMove(int[] moveInfor)
    {
        transform.position = findMovePosition(moveInfor);
    }

    void Start()
    {
        int[] move = new int[] {1,0,0};
        CharacterMove(move);
    }
}
