using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    void Start()
    {
        if (SceneController.instance != null)
        {
            GetComponent<Button>().onClick.AddListener(() => SceneController.instance.ExitGame());
        }
    }
}
