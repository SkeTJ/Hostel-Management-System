using UnityEngine;

public class OpenCustomerRequests : MonoBehaviour
{
    public void OpenCSR()
    {
        Main.Instance.staffMainMenu.SetActive(false);
        gameObject.SetActive(true);
    }
}