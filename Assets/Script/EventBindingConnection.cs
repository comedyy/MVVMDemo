using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

internal class EventBindingConnection
{
    private EventBindInfo eventBindInfo;
    private BaseViewModel viewModel;

    MethodInfo _invokeMethod;

    public EventBindingConnection(BaseViewModel viewModel, EventBindInfo dataBindInfo)
    {
        this.eventBindInfo = dataBindInfo;
        this.viewModel = viewModel;

        _invokeMethod = viewModel.GetType().GetMethod(dataBindInfo.invokeFunctionName, BindingFlags.Public | BindingFlags.Instance);
        if (_invokeMethod == null)
        {
            Debug.LogErrorFormat("get invokeMethod null {0}", dataBindInfo.invokeFunctionName);
        }
    }

    private void OnEvent()
    {
        _invokeMethod.Invoke(viewModel, null);
    }

    internal void Bind()
    {
        ((Button)eventBindInfo.component).onClick.AddListener(OnEvent);
    }

    internal void UnBind()
    {
        ((Button)eventBindInfo.component).onClick.RemoveListener(OnEvent);
    }
}