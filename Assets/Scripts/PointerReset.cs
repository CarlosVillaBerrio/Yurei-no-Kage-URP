using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerReset : MonoBehaviour
{
    private void Awake()
    {
        AwakePointer();
    }

    void AwakePointer()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
