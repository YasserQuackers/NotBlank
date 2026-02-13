using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GoToMainMenu()
    {
        // 1. Unlock the cursor so it can move freely
        Cursor.lockState = CursorLockMode.None;

        // 2. Make the cursor visible
        Cursor.visible = true;

        // 3. Load the scene
        SceneManager.LoadScene("MainMenu");
    }
}