using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public TMPro.TMP_InputField usernameInput;
    public TMPro.TMP_InputField passwordInput;
    public Button registerButton;

    string hashedPassword;

    // Start is called before the first frame update
    void Start()
    {
        registerButton.onClick.AddListener(() =>
        {
            hashedPassword = SHA256.Hash(passwordInput.text);
            StartCoroutine(Main.Instance.web.RegisterUser(usernameInput.text, hashedPassword));
        });
    }
}