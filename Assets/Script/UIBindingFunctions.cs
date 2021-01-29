﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

public static class UIBindingFunctions
{
    public static void SetText<T>(Text text, T value)
    {
        if (text == null)
        {
            Debug.LogError("SetText Error, Text Null");
            return;
        }

        if (value == null)
        {
            Debug.LogError("SetText Error, Value Null " + text.ToString());
            return;
        }

        text.text = value.ToString();
    }

    public static void SetToggle(Toggle toggle, bool value) 
    {
        toggle.isOn = value;
    }

    public static void SetSlider(Slider slider, float value) 
    {
        slider.value = value;
    }

    public static void SetImage(Image image, string path)
    {
        image.sprite = Resources.Load<Sprite>(path);
    }

    public static void SetList(IListSetter l, IList data) 
    {
        l.SetListData(data);
    }
}
