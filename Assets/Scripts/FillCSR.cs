using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillCSR : MonoBehaviour
{
    FillCSR fillCSR;

    public TMPro.TMP_Text ticketId;
    public TMPro.TMP_Text requestTitle;
    public TMPro.TMP_Text currentStatus;
    public TMPro.TMP_Text currentDate;

    void Start()
    {
        fillCSR = GetComponent<FillCSR>();
    //    ticketId = GameObject.Find("Ticket ID Number").GetComponent<TMPro.TMP_Text>();
    //    requestTitle = GameObject.Find("Request Title Text").GetComponent<TMPro.TMP_Text>();
    //    currentStatus = GameObject.Find("Current Status").GetComponent<TMPro.TMP_Text>();
    //    currentDate = GameObject.Find("Current Date").GetComponent<TMPro.TMP_Text>();
    }

    public void FillText(string _id, string _requestTitle, string _status, string _date)
    {
        ticketId.text = _id;
        requestTitle.text = _requestTitle;
        currentStatus.text = _status;
        currentDate.text = _date;

        for (int i = 0; i < fillCSR.transform.childCount; i++)
        {
            var child = fillCSR.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(true);
        }
    }

    public void Unfill()
    {
        for (int i = 0; i < fillCSR.transform.childCount; i++)
        {
            var child = fillCSR.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
    }
}