using UnityEngine;
using UnityEngine.UI;

// Input Name Scene attached to Game Manager


public class PlayerNameInput : MonoBehaviour
{
    public InputField nameInputField;
    public GameObject drivingScene; // Reference to the driving scene 

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