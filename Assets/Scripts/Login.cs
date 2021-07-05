using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public TMPro.TMP_InputField usernameInput;
    public TMPro.TMP_InputField passwordInput;
    public Button loginButton;

    string hashedPassword;

    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(() =>
        {
            hashedPassword = SHA256.Hash(passwordInput.text);
            //Debug.Log(hashedPassword);
            StartCoroutine(Main.Instance.web.LogIn(usernameInput.text, hashedPassword));
        });
    }
}