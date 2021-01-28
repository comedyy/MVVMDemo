using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIBindingFunctions
{
    public static void SetText(Text text, int value) 
    {
        text.text = value.ToString();
    }

    public static void SetToggle(Toggle toggle, bool value) 
    {
        toggle.isOn = value;
    }
}
