using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToMainButton : MonoBehaviour
{
    public void moveToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
