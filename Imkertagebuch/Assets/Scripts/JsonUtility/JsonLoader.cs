using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonLoader
{
    private static string LoadJSONFromPersistentDataPath(string pathInStreamingAssets)
    {
        string path = Path.Combine(Application.persistentDataPath, pathInStreamingAssets);
        string json = File.ReadAllText(path);

        return json;        
    }

    /// <summary>
    /// Load object of given type from a json at given folder in StreaminAssets
    /// </summary>
    /// <typeparam name="T">type of object to load - struct representing the JSON</typeparam>
    /// <param name="path">path within the Application.persistentDataPath folder where the JSON is located</param>
    /// <returns></returns>
    public static T LoadFromJSON<T>(string path)
    {
        string jsonString = LoadJSONFromPersistentDataPath(path);
        T loadedObject = JsonUtility.FromJson<T>(jsonString);
        return loadedObject;
    }

    /// <summary>
    /// Load all JSON files within the given directory, transform them into given type
    /// </summary>
    /// <typeparam name="T">type of json</typeparam>
    /// <param name="directoryPath"></param>
    /// <returns></returns>
    public static List<T> LoadAllFilesInDirectory<T>(string directoryPath)
    {
        List<T> loadedObjects = new List<T>();

        string fullDirectoryPath = Path.Combine(Application.persistentDataPath, directoryPath);
        if (!Directory.Exists(fullDirectoryPath))
            Directory.CreateDirectory(fullDirectoryPath);
        
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Application.persistentDataPath, directoryPath));
        
        FileInfo[] files = directoryInfo.GetFiles();

        foreach (FileInfo file in files)
        {
            if (!IsValidJsonFile(file))
            {
                Debug.Log("don't load" + file.Name);
                continue;
            }

            T loadedObject = LoadFromJSON<T>(Path.Combine(directoryPath, file.Name));
            loadedObjects.Add(loadedObject);
        }

        return loadedObjects;
    }

    private static bool IsValidJsonFile(FileInfo file)
    {
        if (!file.Name.EndsWith(".json"))
            return false;

        return true;
    }
}
