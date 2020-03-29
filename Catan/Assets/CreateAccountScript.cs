using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Logger;

public class CreateAccountScript : MonoBehaviour
{
    private string username;
    private string password;
    private string email;

    public void GoToLogin()
    {
        SceneManager.LoadScene("LogInScene");
    }

    public bool isValid(string thing)
    {
        if (string.IsNullOrEmpty(thing)) //+alte validari
            return false;
        else return true;
    }

    public void SetUsername(string user)
    {
        if(isValid(user))
            this.username = user;
    }

    public void SetPassword(string pass)
    {
        if (isValid(pass))
            this.password = pass; ;
    }

    public void SetEmail(string email)
    {
        if (isValid(email))
            this.email = email;
    }

    public async void CreateAccount()
    {
        EmailLogin.Instance.CreateNewAccount("emailParam", "PassParam");
    }

    public async void Submit()
    {
    }

}
