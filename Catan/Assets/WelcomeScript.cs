﻿using UnityEngine;
using UnityEngine.SceneManagement;
using Logger;
using System;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class WelcomeScript : MonoBehaviour
{
    public GameObject passwordObj;
    public GameObject emailObj;
    public GameObject failedLogInPopUp;
    private string email;
    private string password;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (emailObj.GetComponent<InputField>().isFocused)
            {
                passwordObj.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) //daca apesi enter
        {
            if (email != "" && password != "") //validare
            {
                GoToMenu();
            }
            //else { failesLogInPopUp.SetVisible(true); }
        }

        email = emailObj.GetComponent<InputField>().text;
        password = passwordObj.GetComponent<InputField>().text;
    }

    public void PressEnter()
    {
        if (email != "" && password != "")
        {
            GoToMenu();
        }
    }

    public async void GoToMenu()
    {
        emailObj.GetComponent<InputField>().text = "";
        passwordObj.GetComponent<InputField>().text = "";
        await EmailLogin.Instance.SignInWithEmailAsync(email, password);
        SceneManager.LoadScene("MainMenu");
    }

    public void SignUp()
    {
        SceneManager.LoadScene("SignUpScene");
    }

    public void SetEmail(string input)
    {
        if(!string.IsNullOrEmpty(input))
            this.email = input; //aici ar trebui sa fie o functie care trimite efectiv un mail cu parola specifica dupa ce se face apel la db
    }
}
