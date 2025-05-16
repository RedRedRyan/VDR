using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultSystem : MonoBehaviour
{
    // Reference to your result panel images
    public GameObject passImage;
    public GameObject failImage;

    // This would be called when player collides with finish cube
    public void ShowResult(bool isPass)
    {
        // Activate the appropriate image
        passImage.SetActive(isPass);
        failImage.SetActive(!isPass);

        // Pause the game
        Time.timeScale = 0;
    }

    // Optional: Method to restart level
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
