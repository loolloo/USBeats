using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static ControlKey;

public class changeKey : MonoBehaviour
{
    public TextMeshProUGUI Key;
    public Button button;
    private bool active = false;

    public void clicked()
    {
        active = true;
    }

    void Update()
    {
        if (active == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse2) || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
            {
                active = false;
                return;
            }
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    active = false;
                    string tmp = kcode.ToString();
                    if (KeyCatch1 == tmp || KeyCatch2 == tmp || KeyCatch3 == tmp || KeyCatch4 == tmp || KeyTransfert1 == tmp || KeyTransfert2 == tmp || KeyTransfert3 == tmp || KeyTransfert4 == tmp)
                    {
                        return;
                    }
                    Key.text = tmp;
                }
            }
        }
    }
}
