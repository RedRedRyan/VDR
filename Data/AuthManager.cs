using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class AuthManager : MonoBehaviour
{
    public static AuthManager Instance;
    
    public UserData currentUser;
    private UserDatabase userDatabase;
    private string dataPath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "userData.json");
        LoadUserDatabase();
    }

    private void LoadUserDatabase()
    {
        if (File.Exists(dataPath))
        {
            string json = File.ReadAllText(dataPath);
            userDatabase = JsonUtility.FromJson<UserDatabase>(json);
        }
        else
        {
            userDatabase = new UserDatabase();
        }
    }

    private void SaveUserDatabase()
    {
        string json = JsonUtility.ToJson(userDatabase, true);
        File.WriteAllText(dataPath, json);
    }

    public bool Register(string email, string password)
    {
        // Check if user already exists
        if (userDatabase.users.Exists(u => u.email == email))
        {
            return false;
        }

        // Create new user
        UserData newUser = new UserData
        {
            email = email,
            password = password // In production, hash this password
        };

        userDatabase.users.Add(newUser);
        SaveUserDatabase();
        return true;
    }

    public bool Login(string email, string password)
    {
        UserData user = userDatabase.users.Find(u => u.email == email);
        if (user != null && user.password == password) // In production, compare hashes
        {
            currentUser = user;
            return true;
        }
        return false;
    }

    public void Logout()
    {
        currentUser = null;
    }

    public bool IsLoggedIn()
    {
        return currentUser != null;
    }
}