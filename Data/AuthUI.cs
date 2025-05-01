using UnityEngine;
using UnityEngine.UI;

public class AuthUI : MonoBehaviour
{
    [SerializeField] private InputField emailInput;
    [SerializeField] private InputField passwordInput;
    [SerializeField] private Text statusText;
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject welcomePanel;
    [SerializeField] private Text welcomeText;

    private void Start()
    {
        UpdateUI();
    }

    public void OnRegister()
    {
        if (AuthManager.Instance.Register(emailInput.text, passwordInput.text))
        {
            statusText.text = "Registration successful!";
            AuthManager.Instance.Login(emailInput.text, passwordInput.text);
            UpdateUI();
        }
        else
        {
            statusText.text = "Email already registered";
        }
    }

    public void OnLogin()
    {
        if (AuthManager.Instance.Login(emailInput.text, passwordInput.text))
        {
            statusText.text = "Login successful!";
            UpdateUI();
        }
        else
        {
            statusText.text = "Invalid email or password";
        }
    }

    public void OnLogout()
    {
        AuthManager.Instance.Logout();
        UpdateUI();
    }

    private void UpdateUI()
    {
        bool loggedIn = AuthManager.Instance.IsLoggedIn();
        loginPanel.SetActive(!loggedIn);
        welcomePanel.SetActive(loggedIn);

        if (loggedIn)
        {
            welcomeText.text = $"Welcome, {AuthManager.Instance.currentUser.email}";
        }
    }
}