using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    public void ChangeStage()
    {
        SceneManager.LoadScene("Stage1");
    }
}
