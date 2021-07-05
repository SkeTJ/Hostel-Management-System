using UnityEngine;

public class GoToRegister : MonoBehaviour
{
    public void RegistrationMenu()
    {
        Main.Instance.login.gameObject.SetActive(false);
        Main.Instance.registrationMenu.SetActive(true);
    }
}