using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int count;
    public int coin;

    public GameObject pause;
    void Start()
    {
        count = coin = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pause.SetActive(true);
        }
    }
}
