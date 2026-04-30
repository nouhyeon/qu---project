using UnityEngine;


public class SettingButton : MonoBehaviour
{
    public GameObject settingView;

    public void popSettingView()
    {
        settingView.SetActive(true);
    }
}
