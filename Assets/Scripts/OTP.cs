using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using OtpNet;

public class OTP : MonoBehaviour
{
    public TMPro.TMP_InputField OTPInput;
    public TMPro.TMP_Text OTPCode;
    public Button submitButton;

    string result;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(GenarateTOTP());
    }

    // Update is called once per frame
    void Update()
    {
        if(OTPInput.text == result)
        {
            submitButton.interactable = true;
        }

        else
        {
            submitButton.interactable = false;
        }
    }

    IEnumerator GenarateTOTP()
    {
        var bytes = Base32Encoding.ToBytes("JBSWY3DPEHPK3PXP");
        var totp = new Totp(bytes, step: 1, OtpHashMode.Sha256);
        result = totp.ComputeTotp();

        OTPCode.text = result;

        var input = OTPInput.text;
        long timeStepMatched;
        bool verify = totp.VerifyTotp(input, out timeStepMatched, window: null);

        yield return null;
    }
}