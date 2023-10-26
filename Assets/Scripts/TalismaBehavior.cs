using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalismaBehavior : MonoBehaviour
{
    [SerializeField] private Light light;

    [Range(0f,0.40f)]
    [SerializeField] public float lightRange;

    private bool isChargingLight = false;
    void Start()
    {
        light = GetComponent<Light>();
        light.intensity = lightRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChargingLight)
        {
            if(light.intensity > 0f)
            {
                light.intensity -= 0.02f * Time.deltaTime;
            }
        }

        if (isChargingLight)
        {
            if (light.intensity <= 0.40f)
            {
                light.intensity += 0.08f * Time.deltaTime;
            }
        }
    }

    public void IsOnRecharger()
    {
        isChargingLight = true;        
    }

    public void IsOutOfRecharger()
    {
        isChargingLight = false;
    }


}
