using UnityEngine;

public class OpenCheckReservation : MonoBehaviour
{
    public void OpenBookingStatus()
    {
        Main.Instance.userMainMenu.SetActive(false);
        gameObject.SetActive(true);
    }
}