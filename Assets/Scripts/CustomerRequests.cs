using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;

public class CustomerRequests : MonoBehaviour
{
    Action<string> createCustomerRequestCallback;

    public void CheckCustomerRequests()
    {
        createCustomerRequestCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateCustomerRequestsRoutine(jsonArrayString));
        };

        Main.Instance.staffMainMenu.SetActive(false);
        StartCoroutine(Main.Instance.web.GetCustomerRequests(createCustomerRequestCallback));
    }

    IEnumerator CreateCustomerRequestsRoutine(string jsonArrayString)
    {
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;
        for (int i = 0; i < jsonArray.Count; i++)
        {
            bool isDone = false;
            string customerRequestID = jsonArray[i].AsObject["ID"];
            JSONObject customerInfoJson = new JSONObject();

            //Create a callback to get the information from Web
            Action<string> getCustomerInfoCallback = (roomInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(roomInfo) as JSONArray;
                customerInfoJson = tempArray[i].AsObject;
            };

            //Wait until it finish downloading the information
            StartCoroutine(Main.Instance.web.GetCustomerRequests(getCustomerInfoCallback));
            yield return new WaitUntil(() => isDone == true);

            //Instantiate GameObject
            GameObject csr = Instantiate(Resources.Load("Prefabs/CSR Button") as GameObject);
            csr.transform.SetParent(this.transform);
            csr.transform.localScale = Vector3.one;
            csr.transform.localPosition = Vector3.zero;

            csr.GetComponent<Button>().onClick.AddListener(GoToDetailedView);

            //Fill information to the GameObject
            csr.transform.Find("Ticket ID Text").GetComponent<TMPro.TMP_Text>().text = customerInfoJson["ID"];
            csr.transform.Find("Request Title Text").GetComponent<TMPro.TMP_Text>().text = customerInfoJson["RequestTitle"];
            csr.transform.Find("Status Text").GetComponent<TMPro.TMP_Text>().text = customerInfoJson["Status"];
            csr.transform.Find("Date Text").GetComponent<TMPro.TMP_Text>().text = customerInfoJson["Date"];

            csr.GetComponent<CSRButton>().ticketID = customerInfoJson["ID"];
            csr.GetComponent<CSRButton>().requestTitle = customerInfoJson["RequestTitle"];
            csr.GetComponent<CSRButton>().currentStatus = customerInfoJson["Status"];
            csr.GetComponent<CSRButton>().currentDate = customerInfoJson["Date"];

            //Continue to the next room
        }
    }

    void GoToDetailedView()
    {
        RemoveCSR();
        Main.Instance.customerSupportRequestMenu2.gameObject.SetActive(true);
        Main.Instance.customerSupportRequestMenu1.SetActive(false);
    }

    public void RemoveCSR()
    {
        GameObject[] csrGO = GameObject.FindGameObjectsWithTag("CSR");
        foreach (GameObject csr in csrGO)
        {
            Destroy(csr);
        }
    }
}