using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameplayUI;

    public void OnPauseButtonClicked()
    {
        // Pause game time
        Time.timeScale = 0f;
        
        // Show pause panel and hide gameplay UI
        pausePanel.SetActive(true);
        gameplayUI.SetActive(false);
    }
}