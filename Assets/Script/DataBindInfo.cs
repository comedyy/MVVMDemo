using System;
using UnityEngine;

[Serializable]
internal class DataBindInfo
{
    public Component component;
    public string invokeFunctionName;
    public string propertyName;
}

[Serializable]
internal class EventBindInfo
{
    public Component component;
    public string className;
    public string invokeFunctionName;
}