using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegisterButton : MonoBehaviour
{
    public Button registerButton;
    public TMP_InputField username;
    public TMP_InputField password;
    public Toggle robotCheck;

    public void EnableRegisterButton()
    {
        if(robotCheck.isOn && username.textComponent.textInfo.characterCount > 1 && password.textComponent.textInfo.characterCount > 1)
        {
            registerButton.interactable = true;
        }

        else
        {
            registerButton.interactable = false;
        }
    }
}