using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMobile : MonoBehaviour
{
    private TouchScreenKeyboard _keyboard;

    public void KeyBoardOpen()
    {
        Debug.Log(TouchScreenKeyboard.visible);
        _keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
