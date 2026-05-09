using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int count;
    public int coin;

    public GameObject panel;

    void Start()
    {
        count = coin = 0;
    }

    private void Update() {
        if (Input.GetButtonDown("Cancel"))
        {
            panel.SetActive(true);
        }
    }
}
