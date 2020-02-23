using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ControlKey : MonoBehaviour
{
    public static KeyCode KeyCatch1 = KeyCode.A;
    public static KeyCode KeyCatch2 = KeyCode.Z;
    public static KeyCode KeyCatch3 = KeyCode.E;
    public static KeyCode KeyCatch4 = KeyCode.R;
    public static KeyCode KeyTransfert1 = KeyCode.Q;
    public static KeyCode KeyTransfert2 = KeyCode.S;
    public static KeyCode KeyTransfert3 = KeyCode.D;
    public static KeyCode KeyTransfert4 = KeyCode.F;

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
        catch1.text = KeyCatch1.ToString();
        catch2.text = KeyCatch2.ToString();
        catch3.text = KeyCatch3.ToString();
        catch4.text = KeyCatch4.ToString();
        transfert1.text = KeyTransfert1.ToString();
        transfert2.text = KeyTransfert2.ToString();
        transfert3.text = KeyTransfert3.ToString();
        transfert4.text = KeyTransfert4.ToString();
    }
}
