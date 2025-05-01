using System.Collections.Generic; 

[System.Serializable]
public class UserData
{
    public string email;
    public string password; 
    
}

[System.Serializable]
public class UserDatabase
{
    public List<UserData> users = new List<UserData>();
}