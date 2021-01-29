using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class EditorPropertyCache
{
    static Dictionary<Type, List<string>> _dicComponentFuncs;
    static Dictionary<string, List<string>> _dicViewModelPropertys;
    static Dictionary<string, List<string>> _dicViewModelMethodsAndPropertys;

    static void Init() 
    {
        InitComponentFuncs();
        InitViewModelPropertys();
    }

    static void InitViewModelPropertys() 
    {
        if (_dicViewModelPropertys != null)
        {
            return;
        }

        _dicViewModelPropertys = new Dictionary<string, List<string>>();
        _dicViewModelMethodsAndPropertys = new Dictionary<string, List<string>>();

        Type[] types = typeof(BaseViewModel).Assembly.GetTypes();
        foreach (var type in types)
        {
            if (!type.IsSubclassOf(typeof(BaseViewModel)))
            {
                continue;
            }

            string name = type.Name;
            if (!_dicViewModelMethodsAndPropertys.TryGetValue(name, out List<string> lstMetheds))
            {
                lstMetheds = new List<string>();
                _dicViewModelMethodsAndPropertys.Add(name, lstMetheds);
            }

            if (!_dicViewModelPropertys.TryGetValue(name, out List<string> lstPropertys))
            {
                lstPropertys = new List<string>();
                _dicViewModelPropertys.Add(name, lstPropertys);
            }

            MemberInfo[] members = type.GetMembers(BindingFlags.Public | BindingFlags.Instance);
            foreach (var member in members)
            {
                if (member is PropertyInfo)
                {
                    lstPropertys.Add(member.Name);
                    lstMetheds.Add(member.Name);
                }
                else if (member is MethodInfo)
                {
                    lstMetheds.Add(member.Name);
                }
            }
        }
    }

    static void InitComponentFuncs()
    {
        if (_dicComponentFuncs != null)
        {
            return;
        }

        _dicComponentFuncs = new Dictionary<Type, List<string>>();

        MethodInfo[] infos = typeof(UIBindingFunctions).GetMethods(BindingFlags.Public | BindingFlags.Static);
        foreach (var info in infos)
        {
            ParameterInfo[] ps = info.GetParameters();
            if (ps.Length < 2)
            {
                continue;
            }

            Type t = ps[0].ParameterType;
            if (!_dicComponentFuncs.TryGetValue(t, out List<string> list))
            {
                list = new List<string>();
                _dicComponentFuncs.Add(t, list);
            }

            list.Add(info.Name);
        }
    }

    public static List<string> GetComponentOpts(Type type)
    {
        Init();

        List<string> lstFunc = new List<string>();
        foreach (var key in _dicComponentFuncs.Keys)
        {
            if (key.IsAssignableFrom(type))
            {
                lstFunc.AddRange(_dicComponentFuncs[key]); ;
            }
        }

        return lstFunc;
    }

    public static List<string> GetPropertys(string type) 
    {
        Init();
        if (_dicViewModelPropertys.TryGetValue(type, out List<string> list))
        {
            return list;
        }

        return new List<string>();
    }

    //public static List<string> GetMethodAndPropertys(string type) 
    //{
    
    //}
}
