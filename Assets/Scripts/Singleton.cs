﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    static T instance;
    public static T Instance
    {
        get { return instance; }
    }

    public static bool IsInitialized
    {
        get { return instance != null; }
    }
    protected virtual void Awake()
    {
        if (IsInitialized)
        {
            Debug.LogError("[Singleton] Trying to instantiate a second of a singleton class.");
            Destroy(gameObject);
        }
        else
        {
            instance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        if(instance==this)
        {
            instance = null;
        }
    }
}
