using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OnStartClick()
    {
               UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    public void OnExitClick()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
                Application.Quit(); 
    }
}
