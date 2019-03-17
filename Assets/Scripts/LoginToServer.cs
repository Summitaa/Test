using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class LoginToServer : MonoBehaviour
{

    public InputField Email, password;
    public void LoginButtonPressed()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(Email.text, password.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("Błędne dane ");
                return;
            }
            Firebase.Auth.FirebaseUser newUser = task.Result;
            SceneManager.LoadScene("Lobby");
            Debug.Log("Zalogowano!");
        });

    }
}