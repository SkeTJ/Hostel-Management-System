using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoutButton : MonoBehaviour
{
    public void BackToLoginMenu()
    {
        Main.Instance.roomsCA.RemoveRoomRoutine();
        Main.Instance.roomsPA.RemoveRoomRoutine();
        foreach (GameObject others in Main.Instance.otherMenus)
        {
            others.SetActive(false);
        }

        Main.Instance.paymentMenu.SetActive(false);
        Main.Instance.bookingMenu.SetActive(false);
        Main.Instance.makeReservationMenu.SetActive(false);
        Main.Instance.customerSupportMenu.SetActive(false);
        Main.Instance.registrationMenu.SetActive(false);
        Main.Instance.userMainMenu.SetActive(false);
        Main.Instance.staffMainMenu.SetActive(false);
        Main.Instance.staffStatisticsMenu.SetActive(false);
        Main.Instance.customerSupportRequestMenu1.SetActive(false);
        Main.Instance.customerSupportRequestMenu2.Unfill();
        Main.Instance.login.gameObject.SetActive(true);
    }
}