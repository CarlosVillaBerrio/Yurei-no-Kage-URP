using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    Transform ts;
    void Start()
    {
        ts = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor(Transform _transform)
    {
        ts = _transform;
    }
}
