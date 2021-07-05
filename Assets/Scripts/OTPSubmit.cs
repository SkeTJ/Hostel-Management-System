using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OTPSubmit : MonoBehaviour
{
    public UserInfo userInfo;

    public void GoToMainMenu()
    {
        Main.Instance.otpMenu.SetActive(false);
        switch (userInfo.userIsStaff)
        {
            default:
                break;
            case "0":
                Main.Instance.userMainMenu.SetActive(true);
                break;
            case "1":
                Main.Instance.staffMainMenu.SetActive(true);
                break;
        }
    }
}