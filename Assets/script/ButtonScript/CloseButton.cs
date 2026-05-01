using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject closeView;

    public void CloseView()
    {
        closeView.SetActive(false);
    }
}
