using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalismaBehavior : MonoBehaviour
{
    [SerializeField] private Light light;

    [Range(0f,0.40f)]
    [SerializeField] public float lightRange;
    [Range(0f, 0.1f)]
    public float dischargeRate = 0.0001f;
    [Range(0f, 0.1f)]
    public float rechargeRate = 0.08f;

    private bool isChargingLight = false;

    //float timeElapsed;
    //float lerpDuration = 3;
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
                light.intensity -= dischargeRate * Time.deltaTime;
            }
        }

        //if (light.intensity > 0f && timeElapsed < lerpDuration)
        //{
        //    light.intensity = Mathf.Lerp(0.4f, 0, timeElapsed / lerpDuration);
        //    timeElapsed += Time.deltaTime;
        //}

        if (isChargingLight)
        {
            if (light.intensity <= 0.40f)
            {
                light.intensity += rechargeRate * Time.deltaTime;
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
