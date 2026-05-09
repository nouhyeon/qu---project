
using System.Collections;
using Unity.Collections;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Map map;

    public int characterSize;

    public GameManager gameManager;

    bool canMove = true;

    bool isMoving = false;

    int gridX = 0;
    int gridY = 0;
    int gridZ = 0;

    public float moveSpeed;

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
            if (nextX < 0 || nextX >= map.mapXSize
            || nextY < 0 || nextY >= map.mapYSize
            || nextZ < 0 || nextZ >= map.mapZSize)
            {
                break;
            }
            int checkIndex = nextX + nextY * map.mapXSize + nextZ * map.mapXSize * map.mapYSize;
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
        if (isMoving)
        {
            return;
        }
        Vector3 targetPos = findMovePosition(moveInfor);
        if(targetPos == transform.position)
        {
            return;
        }
        ++gameManager.count;
        StartCoroutine(SmoothMove(targetPos));
    }

    IEnumerator SmoothMove(Vector3 target)
    {
        isMoving = true;
        canMove = false;
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = target;
        isMoving = false;
        canMove = true;
    }

    private void CalVector(Vector2 end_start)
    {
        float acTan = Mathf.Atan2(end_start.y, end_start.x) * Mathf.Rad2Deg;
        Debug.Log(acTan);
        int[] returnArr = new int[3] { 0, 0, 0 };
        if (acTan > 0 && acTan <= 60)
        {
            returnArr[0] = 1;
        }
        else if (acTan > 60 && acTan <= 120)
        {
            returnArr[1] = 1;
        }
        else if (acTan > 120 && acTan <= 180)
        {
            returnArr[2] = 1;
        }
        else if (acTan > (-180) && acTan <= (-120))
        {
            returnArr[0] = -1;
        }
        else if (acTan > (-120) && acTan <= (-60))
        {
            returnArr[1] = -1;
        }
        else if (acTan > (-60) && acTan <= 0)
        {
            returnArr[2] = -1;
        }
        CharacterMove(returnArr);

    }
    void Update()
    {
        if ((Input.touchCount > 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) && canMove)
        {
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            gameManager.coin++;
            Destroy(other.gameObject);
        }
    }

    void CheakEndPoint(Vector3 characterPoint)
    {
        if(transform.position == map.endPoint)
        {
                StageClear();
        }
    }

    void StageClear()
    {
        gameManager.clear = true;
    }

}
