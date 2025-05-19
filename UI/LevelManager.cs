using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private int sceneIndex;

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
