using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    public InputField nameInputField;
    public GameObject drivingScene; // Reference to the scene to enable after input

    public void OnSubmitName()
    {
        DataLogger dataLogger = FindObjectOfType<DataLogger>();
        if (dataLogger != null && !string.IsNullOrEmpty(nameInputField.text))
        {
            dataLogger.SetPlayerName(nameInputField.text);
            drivingScene.SetActive(true); // Enable driving scene
            gameObject.SetActive(false); // Disable name input UI
        }
    }
}