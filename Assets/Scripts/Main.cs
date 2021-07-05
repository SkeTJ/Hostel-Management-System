using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;

    public Web web;
    public UserInfo userInfo;
    public Login login;
    public RoomsCheckAvailability roomsCA;
    public RoomsPayAvailability roomsPA;

    public GameObject userMainMenu;
    public GameObject staffMainMenu;
    public GameObject otpMenu;
    public GameObject registrationMenu;
    public GameObject makeReservationMenu;
    public GameObject paymentMenu;
    public GameObject bookingMenu;
    public GameObject customerSupportMenu;
    public GameObject customerSupportRequestMenu1;
    public FillCSR customerSupportRequestMenu2;
    public GameObject staffStatisticsMenu;
    public GameObject[] otherMenus;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        web = GetComponent<Web>();
        userInfo = GetComponent<UserInfo>();
    }
}