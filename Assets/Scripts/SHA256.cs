using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SHA256 : MonoBehaviour
{
    public static string Hash(string str)
    {
        System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
        System.Text.StringBuilder hash = new System.Text.StringBuilder();
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetByteCount(str));
        foreach (byte bit in crypto)
        {
            hash.Append(bit.ToString("x2"));
        }
        return hash.ToString().ToLower();
    }
}