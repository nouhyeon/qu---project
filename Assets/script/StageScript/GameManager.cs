using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int moveCount;

    public int moveCount_Max;

    public bool[] stars;

    public int sGrade;
    public int aGrade;
    public int bGrade;
    public string stageName;


    public Vector3 endPosition;

    public GameObject pausePanel;
    public GameObject clearPanel;
    public GameObject gameOverPanel;
    public Character character;
    public CountController countController;


    void Start()
    {
        moveCount = 0;
        countController.ChangeCountTMP(moveCount, moveCount_Max);
        countController.ChangeGradeTMP(sGrade,aGrade,bGrade);
    }

    private void Update() {
        if (Input.GetButtonDown("Cancel"))
        {
            character.canMove = false;
            pausePanel.SetActive(true);
        }
    }

    public void Clear()
    {
        character.canMove = false;
        clearPanel.SetActive(true);
        MapDataManager.Instance.UpdateClearResult(stageName,stars,moveCount);
    }

    public void GameOver()
    {
        character.canMove = false;
        gameOverPanel.SetActive(true);
    }

    public void changeCountUi()
    {
        countController.ChangeCountTMP(moveCount, moveCount_Max);
    }
}
