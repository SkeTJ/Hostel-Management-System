using UnityEngine;

public class OpenPayReservation : MonoBehaviour
{
    public void OpenBookingStatus()
    {
        Main.Instance.userMainMenu.SetActive(false);
        gameObject.SetActive(true);
    }
}