using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public abstract class JsonModifier<T> : ScriptableObject
{
    public string folderPath;
    public string currentDataObjectPath;
    public string countPlayerPrefsKey;

    protected abstract string DataObjectName(T dataObject);
    public abstract T UpdateData(T dataObject, string key, string data);
    public abstract string GetData(T dataObject, string key);
    
    // callback
    public event Action<T> OnSaveCompleted;
    
    public void SaveJson(T dataObject, bool overrideExisting)
    {
        Debug.Log(this + " Create Json");
        JsonSaver.SaveAsJson(
            dataObject,
            DataObjectPath(dataObject), 
            overrideExisting);
        
        OnSaveCompleted?.Invoke(dataObject);
    }
    
    public virtual string DataObjectPath(T dataObject)
    {
        return Path.Combine(folderPath, DataObjectName(dataObject) + ".json");
    }
}
