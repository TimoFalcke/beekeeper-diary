using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName ="Runtime/Single Instance/SceneLoader")]
public class SceneLoader : ScriptableObject
{
    [SerializeField] List<int> previousScenes = new List<int>() { 0 };

    public void LoadScene(int index)
    {
        previousScenes.Add(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(index);
    }

    public void LoadScene(string name)
    {
        previousScenes.Add(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(name);
    }

    public void BackToPreviousScene()
    {
        Debug.Log("Load Previous Scene");
        
        int previousSceneIndex = previousScenes[previousScenes.Count - 1];
        previousScenes.RemoveAt(previousScenes.Count - 1);

        LoadScene(previousSceneIndex);        
    }
}
