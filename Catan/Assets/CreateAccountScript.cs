using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Logger;
using System;
using UnityEngine.UI;
using System.IO;

public class CreateAccountScript : MonoBehaviour
{
    public GameObject usernameObj;
    public GameObject emailObj;
    public GameObject passwordObj;
    public GameObject passwordConfirmationObj;
	public GameObject successPopUp;
    private string Name;
    private string Email;
    private string Password;
    private string PasswordConfirmation;
    //private bool EmailValid = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (emailObj.GetComponent<InputField>().isFocused)
			{
				usernameObj.GetComponent<InputField>().Select();
			}
			if (usernameObj.GetComponent<InputField>().isFocused)
			{
				passwordObj.GetComponent<InputField>().Select();
			}
			if (passwordObj.GetComponent<InputField>().isFocused)
			{
				passwordConfirmationObj.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (PasswordConfirmation != "" && Password != "" && Email != "" && Name != "")
			{
				CreateAccount();
				successPopUp.SetActive(true);
			}
		}

		Name = usernameObj.GetComponent<InputField>().text;
		Email = emailObj.GetComponent<InputField>().text;
		Password = passwordObj.GetComponent<InputField>().text;
		PasswordConfirmation = passwordConfirmationObj.GetComponent<InputField>().text;
	}

	public void PressSubmit()
    {
		if (PasswordConfirmation != "" && Password != "" && Email != "" && Name != "")
		{
			CreateAccount();
		}
	}

	public void GoToLogin()
    {
        SceneManager.LoadScene("LogInScene");
    }


    public async void CreateAccount()
    {
        EmailLogin.Instance.CreateNewAccount(Email, Password, Name);
    }

}
