using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
namespace Logger
{
    public enum AccountLoginStatus { 
        failed = 0,
        success = 1
    }

    public enum AccountRegisterStatus { 
        accountAlreadyExists = 0,
        confirmationMailSent = 1,
        registrationFailed = 2
    }

    public class EmailLogin
    {
        private static Action<AccountLoginStatus> afterLogin;
        private static Action<AccountRegisterStatus> afterCreatingAcc;
        private static Action<int> afterResetingPass;
        
        public void SubscribeToLoginSucceded(Action<AccountLoginStatus> action)
        {
                afterLogin = action;
        }
        
        public void subscribeToAccountCreated( Action<AccountRegisterStatus> action)
        {
            afterCreatingAcc = action;
        }

        public void subscribeToPasswordReset(Action<int> action)
        {
            afterResetingPass = action;
        }

        private EmailLogin() { }
        private static readonly object padlock = new object();
        private static EmailLogin instance = null;
        private Func<int> afterRestingPass;

        public static EmailLogin Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new EmailLogin();
                    }
                    return instance;
                }
            }
        }
        public void CreateNewAccount(String email, String pass, String username)
        {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBBVQYk-GFc4InkQub-Z-stYing-81UUQc"));
                var auth =  authProvider.CreateUserWithEmailAndPasswordAsync(email, pass, username, true).Result;
        }

        public async Task SignInWithEmailAsync(String email, String pass)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBBVQYk-GFc4InkQub-Z-stYing-81UUQc"));
            var auth = authProvider.SignInWithEmailAndPasswordAsync(email, pass);
        }

        public async Task EmailResetPassAsync(String email)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyDITPuS64TxugEpwPLKU773Q1n-yy58-6k"));
            var auth = authProvider.SendPasswordResetEmailAsync(email);
        }
    }
}
