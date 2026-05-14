using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int count;
    public int coin;

    public int sceneNum;

    bool clear;



    public GameObject pause;
    void Start()
    {
        count = coin = 0;
        clear = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pause.SetActive(true);
        }
    }
}
