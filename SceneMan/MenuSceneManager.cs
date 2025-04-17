using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public InputField nameInputField;
    public Button submitButton;

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmitName);
    }

    void OnSubmitName()
    {
        if (!string.IsNullOrEmpty(nameInputField.text))
        {
            // Save the name to DataLogger (persistent across scenes)
            DataLogger dataLogger = FindObjectOfType<DataLogger>();
            if (dataLogger == null)
            {
                GameObject loggerObj = new GameObject("DataLogger");
                dataLogger = loggerObj.AddComponent<DataLogger>();
                DontDestroyOnLoad(loggerObj); // Keep logger alive
            }
            dataLogger.SetPlayerName(nameInputField.text);

            // Load the driving scene
            SceneManager.LoadScene("DrivingScene");
        }
    }
}