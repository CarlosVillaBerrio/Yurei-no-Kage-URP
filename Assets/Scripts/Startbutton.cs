using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startbutton : MonoBehaviour
{
    //private SceneController sceneManager;
    void Start()
    {
        if (SceneController.instance != null)
        {
            GetComponent<Button>().onClick.AddListener(() => SceneController.instance.LoadNextScene("Prologue"));
        }
    }
}
