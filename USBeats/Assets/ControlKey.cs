using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ControlKey : MonoBehaviour
{
    public static string KeyCatch1 = "A";
    public static string KeyCatch2 = "Z";
    public static string KeyCatch3 = "E";
    public static string KeyCatch4 = "R";
    public static string KeyTransfert1 = "Q";
    public static string KeyTransfert2 = "S";
    public static string KeyTransfert3 = "D";
    public static string KeyTransfert4 = "F";

    public TextMeshProUGUI catch1;
    public TextMeshProUGUI catch2;
    public TextMeshProUGUI catch3;
    public TextMeshProUGUI catch4;
    public TextMeshProUGUI transfert1;
    public TextMeshProUGUI transfert2;
    public TextMeshProUGUI transfert3;
    public TextMeshProUGUI transfert4;

    // Update is called once per frame
    void Update()
    {
        KeyCatch1 = catch1.text;
        KeyCatch2 = catch2.text;
        KeyCatch3 = catch3.text;
        KeyCatch4 = catch4.text;
        KeyTransfert1 = transfert1.text;
        KeyTransfert2 = transfert2.text;
        KeyTransfert3 = transfert3.text;
        KeyTransfert4 = transfert4.text;
    }
}
