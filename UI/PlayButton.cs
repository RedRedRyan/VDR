using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject pausePanel;


    public void OnPlayButtonClicked()
    {
        // Resume game time
        Time.timeScale = 1f;
        
        // Hide pause panel and show gameplay UI
        pausePanel.SetActive(false);
    }
}