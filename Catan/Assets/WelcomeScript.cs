using UnityEngine;
using UnityEngine.SceneManagement;
using Logger;
using System;

public class WelcomeScript : MonoBehaviour
{
    private string email;
    private string username;
    private string password;
    public void QuitGame()
    {
        Application.Quit();
    }

    public async void GoToMenu()
    {
        EmailLogin.Instance.SignInWithEmailAsync("octavian_milea@outlook.com", "tavitavi");
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
