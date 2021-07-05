using UnityEngine;

public class OpenCustomerSupport : MonoBehaviour
{
    public void OpenCS()
    {
        Main.Instance.userMainMenu.SetActive(false);
        gameObject.SetActive(true);
    }
}