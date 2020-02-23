using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static ControlKey;

public class changeKey : MonoBehaviour
{
    public Button button;
    public int folder;
    public bool transfert;
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
                    if (KeyCatch1 == kcode || KeyCatch2 == kcode || KeyCatch3 == kcode || KeyCatch4 == kcode || KeyTransfert1 == kcode || KeyTransfert2 == kcode || KeyTransfert3 == kcode || KeyTransfert4 == kcode)
                        return;
                    if (folder == 1)
                    {
                        if (transfert)
                            KeyTransfert1 = kcode;
                        else
                            KeyCatch1 = kcode;
                    }
                    else if (folder == 2)
                    {
                        if (transfert)
                            KeyTransfert2 = kcode;
                        else
                            KeyCatch2 = kcode;
                    }
                    else if (folder == 3)
                    {
                        if (transfert)
                            KeyTransfert3 = kcode;
                        else
                            KeyCatch3 = kcode;
                    }
                    else if (folder == 4)
                    {
                        if (transfert)
                            KeyTransfert4 = kcode;
                        else
                            KeyCatch4 = kcode;
                    }
                }
            }
        }
    }
}
