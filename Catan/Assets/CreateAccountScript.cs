using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Logger;

public class CreateAccountScript : MonoBehaviour
{
    public void GoToLogin()
    {
        SceneManager.LoadScene("LogInScene");
    }

    public void CreateAccount(string username, string password, string email)
    {
        EmailLogin.CreateNewAccountAsync(email, password, username);
    }

}
