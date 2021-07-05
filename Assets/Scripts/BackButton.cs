using UnityEngine;

public class BackButton : MonoBehaviour
{
    UserInfo userInfo;

    private void Start()
    {
        userInfo = GetComponent<UserInfo>();
    }

    public void BackToMainMenu()
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
        Main.Instance.customerSupportRequestMenu1.SetActive(false);
        Main.Instance.customerSupportRequestMenu2.Unfill();
        Main.Instance.staffStatisticsMenu.SetActive(false);

        //Debug.Log("User Level: " + userInfo.userIsStaff);

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