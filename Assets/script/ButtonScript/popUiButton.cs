using UnityEngine;


public class popUiButton : MonoBehaviour
{
    public GameObject panel;

    public void popPanel()
    {
        panel.SetActive(true);
    }
}
