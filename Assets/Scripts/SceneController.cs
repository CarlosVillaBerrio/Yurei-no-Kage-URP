using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadNextScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void ExitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
