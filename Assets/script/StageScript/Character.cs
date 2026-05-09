
using Unity.Collections;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Map map;

    public int characterSize;

    bool canMove = true;
    
    int gridX = 0;
    int gridY = 0;
    int gridZ = 0;

    Vector3 touchStart;
    Vector3 touchEnd;

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
        canMove = true;
    }

    private void CalVector(Vector2 end_start)
    {
        float acTan = Mathf.Atan2(end_start.y, end_start.x)* Mathf.Rad2Deg;
        Debug.Log(acTan);
        int[] returnArr = new int[3]{0,0,0};
        if(acTan>0 && acTan <= 60)
        {
            returnArr[0] = 1;
        }
        else if(acTan>60 && acTan <= 120)
        {
            returnArr[1] = 1;
        }
        else if(acTan>120 && acTan <= 180)
        {
            returnArr[2] = 1;
        }
        else if(acTan> (-180) && acTan <= (-120))
        {
            returnArr[0] = -1;
        }
        else if(acTan>(-120) && acTan <= (-60))
        {
            returnArr[1] = -1;
        }
        else if(acTan>(-60) && acTan <= 0)
        {
            returnArr[2] = -1;
        }
        CharacterMove(returnArr);
        
    }
    void Update()
    {
        
        if ((Input.touchCount > 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) && canMove)
    {
        // 터치 입력 처리
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) touchStart = touch.position;
            if (touch.phase == TouchPhase.Ended) 
            {
                touchEnd = touch.position;
                CalVector(touchEnd - touchStart);
            }
        }
        // 마우스 입력 처리 (테스트용)
        else if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touchEnd = Input.mousePosition;
            CalVector(touchEnd - touchStart);
        }
    }

        


    }

}
