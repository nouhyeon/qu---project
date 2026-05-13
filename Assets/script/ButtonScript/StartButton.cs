using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject stageSelectView;
    public void popStageSelect()
    {
        stageSelectView.SetActive(true);
    }
}
