using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int count;
    public int coin;
    public int stageNum;

    public bool clear = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        count = coin = 0;
    }
}
