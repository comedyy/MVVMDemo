using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView<T> : MonoBehaviour where T : BaseViewModel
{
    public T ViewModel { get; private set; }
    [SerializeField] DataBindInfo[] bindConfigs;
    DataBindingConnection[] _connections;

    private void Awake()
    {
        ViewModel = (T)Activator.CreateInstance(typeof(T));
    }

    private void OnEnable()
    {
        Bind();
    }

    private void OnDisable()
    {
        UnBind();
    }

    private void Bind()
    {
        if (_connections == null)
        {
            _connections = new DataBindingConnection[bindConfigs.Length];

            for (int i = 0; i < bindConfigs.Length; i++)
            {
                _connections[i] = new DataBindingConnection(ViewModel, bindConfigs[i]);
                _connections[i].Bind();
            }
        }
    }

    private void UnBind()
    {
        for (int i = 0; i < bindConfigs.Length; i++)
        {
            _connections[i].UnBind();
        }
    }


}
