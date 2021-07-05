using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;

public class RoomsPayAvailability : MonoBehaviour
{
    Action<string> createRoomsCallback;

    public void CheckRooms()
    {
        createRoomsCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateRoomsRoutine(jsonArrayString));
        };

        Main.Instance.userMainMenu.SetActive(false);
        StartCoroutine(Main.Instance.web.GetRoomAvailability(createRoomsCallback));
    }

    IEnumerator CreateRoomsRoutine(string jsonArrayString)
    {
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;
        for (int i = 0; i < jsonArray.Count; i++)
        {
            bool isDone = false;
            string roomID = jsonArray[i].AsObject["ID"];
            JSONObject roomInfoJson = new JSONObject();

            Action<string> getRoomInfoCallback = (roomInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(roomInfo) as JSONArray;
                roomInfoJson = tempArray[i].AsObject;
            };

            //Wait until it finish downloading the information
            StartCoroutine(Main.Instance.web.GetRoomAvailability(getRoomInfoCallback));
            yield return new WaitUntil(() => isDone == true);

            //Instantiate GameObject
            GameObject room = Instantiate(Resources.Load("Prefabs/Room") as GameObject);
            room.transform.SetParent(this.transform);
            room.transform.localScale = Vector3.one;
            room.transform.localPosition = Vector3.zero;

            room.GetComponent<Button>().onClick.AddListener(GoToPayment);

            //Fill information to the GameObject
            room.transform.Find("Room Description").GetComponent<TMPro.TMP_Text>().text = roomInfoJson["Description"];
            room.transform.Find("Room Price").GetComponent<TMPro.TMP_Text>().text = roomInfoJson["Price"];
            room.transform.Find("Room Size").GetComponent<TMPro.TMP_Text>().text = roomInfoJson["Size"];

            Action<Sprite> getRoomImageCallback = (downloadedImage) =>
            {
                room.transform.Find("Room Image").GetComponent<Image>().sprite = downloadedImage;
            };

            //Start applying the image to the prefab
            StartCoroutine(Main.Instance.web.GetRoomImage(roomID, getRoomImageCallback));

            //Continue to the next room
        }
    }

    void GoToPayment()
    {
        RemoveRoomRoutine();
        Main.Instance.paymentMenu.SetActive(true);
        Main.Instance.makeReservationMenu.SetActive(false);
    }

    public void RemoveRoomRoutine()
    {
        GameObject[] roomGO = GameObject.FindGameObjectsWithTag("Room");
        foreach (GameObject room in roomGO)
        {
            Destroy(room);
        }
    }
}