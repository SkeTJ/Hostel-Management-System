using UnityEngine;

public class DisplayUser : MonoBehaviour
{
    public void OnEnable()
    {
        gameObject.GetComponent<TMPro.TMP_Text>().text = Main.Instance.userInfo.userName;
    }
}