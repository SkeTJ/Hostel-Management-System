using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public string userID { get; private set; }
    public string userIsStaff { get; private set; }
    public string userName { get; private set; }
    string userPassword;
    string isStaff;

    public void SetUserInfo(string _userName, string _userPassword)
    {
        userName = _userName;
        userPassword = _userPassword;
    }

    public void SetUserID(string _userID)
    {
        userID = _userID;
    }

    public void SetUserAccessLevel(string _userIsStaff)
    {
        userIsStaff = _userIsStaff;
    }
}