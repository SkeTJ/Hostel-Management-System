using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSRButton : MonoBehaviour
{
    public string ticketID;
    public string requestTitle;
    public string currentStatus;
    public string currentDate;

    Button csrButton;
    FillCSR fillCSR;

    void OnEnable()
    {
        csrButton = GetComponent<Button>();
        fillCSR = GameObject.Find("Customer Support Request Menu 2 (Do not turn off)").GetComponent<FillCSR>();
    }

    void Update()
    {
        csrButton.onClick.AddListener(delegate { fillCSR.FillText(ticketID, requestTitle, currentStatus, currentDate); });
    }
}