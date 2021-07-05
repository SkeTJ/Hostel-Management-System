using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStaffStatistics : MonoBehaviour
{
    public void OpenSS()
    {
        Main.Instance.staffMainMenu.SetActive(false);
        gameObject.SetActive(true);
    }
}