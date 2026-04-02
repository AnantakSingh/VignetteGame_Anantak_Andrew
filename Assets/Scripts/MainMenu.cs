using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method will be called when the Start button is clicked
    public void LoadGameScene()
    {
        // Load the scene exactly named "scene2"
        SceneManager.LoadScene("scene2");
    }
    public void LoadStartScene()
    {
        // Load the scene exactly named "scene2"
        SceneManager.LoadScene("StartScene");
    }

}
