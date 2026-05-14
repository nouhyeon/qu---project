using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void reloadScene()
    {
        SceneManager.LoadScene("stage1");
    }
}
