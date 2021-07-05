using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetRoomAvailability());
    }

    //IEnumerator GetUsers()
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/HostelManagementDatabase/GetUsers.php"))
    //    {
    //        yield return www.SendWebRequest();

    //        if(www.isNetworkError || www.isHttpError)
    //        {
    //            Debug.Log(www.error);
    //        }

    //        else
    //        {
    //            Debug.Log(www.downloadHandler.text);

    //            byte[] results = www.downloadHandler.data;
    //        }
    //    }
    //}

    public IEnumerator LogIn(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/HostelManagementDatabase/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
                Main.Instance.userInfo.SetUserInfo(username, password);
                using (var reader = new StringReader(www.downloadHandler.text))
                {
                    string firstLine = reader.ReadLine();
                    Main.Instance.userInfo.SetUserID(firstLine);

                    string secondLine = reader.ReadLine();
                    Main.Instance.userInfo.SetUserAccessLevel(secondLine);
                }

                if (www.downloadHandler.text.Contains("Username does not exists.") || www.downloadHandler.text.Contains("Wrong Username/Password."))
                {
                    Debug.Log("Try again!");
                }

                else
                {
                    Main.Instance.otpMenu.SetActive(true);
                    Main.Instance.login.gameObject.SetActive(false);
                }
            }
        }
    }

    public IEnumerator RegisterUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("registerUser", username);
        form.AddField("registerPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/HostelManagementDatabase/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }

            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.Instance.registrationMenu.SetActive(false);
                Main.Instance.login.gameObject.SetActive(true);
            }
        }
    }

    public IEnumerator GetCustomerRequests(System.Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/HostelManagementDatabase/GetCustomerRequests.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }

            else
            {
                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);
            }
        }
    }

    public IEnumerator GetRoomAvailability(System.Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/HostelManagementDatabase/GetRoomAvailability.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }

            else
            {
                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);
            }
        }
    }

    public IEnumerator GetRoomImage(string roomID, System.Action<Sprite> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("roomID", roomID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/HostelManagementDatabase/GetRoomImage.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }

            else
            {
                //Debug.Log(www.downloadHandler.text);

                byte[] bytes = www.downloadHandler.data;
                DownloadHandler handler = www.downloadHandler;

                //Create Texture2D
                Texture2D texture = new Texture2D(8, 482);
                Sprite sprite = null;

                //Create Sprite
                if(texture.LoadImage(handler.data))
                {
                    sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                }

                if(sprite != null)
                {
                    callback(sprite);
                }
            }
        }
    }
}