using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonSaver
{
    public static void SaveAsJson<T>(T objectToSave, string pathWithinPersistentDataPath, bool overrideExisting = false)
    {
        string path = Path.Combine(Application.persistentDataPath, pathWithinPersistentDataPath);

        CreateDirectories(pathWithinPersistentDataPath);

        string jsonString = JsonUtility.ToJson(objectToSave, true);
        if (File.Exists(path))
            Debug.Log("file is overwritten: " + path);
        
        File.WriteAllText(path, jsonString);
        Debug.Log("saved file " + pathWithinPersistentDataPath + " at " + path);
        
    }

    private static void CreateDirectories(string pathWithinPersistentDataPath)
    {
        string[] subPaths = pathWithinPersistentDataPath.Split('/', '\\');
        
        for (int i = 0; i < subPaths.Length - 1; i++)
        {
            string addedSubPaths = subPaths[0];
            for (int j = 1; j <= i; j++)
            {
                addedSubPaths = Path.Combine(addedSubPaths, subPaths[j]);
            }

            string directoryPath = Path.Combine(Application.persistentDataPath, addedSubPaths);
            Debug.Log($"check directoryPath {directoryPath} - exists? {Directory.Exists(directoryPath)}");
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}
