using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider slider;

    public BoxCollider box;
    public SphereCollider sphere;

    //float timeElapsed;
    //float lerpDuration = 3;
    void Start()
    {

        slider.maxValue = lightRange;
        light = GetComponent<Light>();
        light.intensity = lightRange;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = light.intensity;
        CheckLightOn();
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

    public void CheckLightOn()
    {
        if(light.intensity <= 0f)
        {
            box.size = Vector3.zero;
            sphere.radius = 0f;
        }
        else
        {
            box.size = new Vector3(0.44f, 1.32f, 5.64f);
            sphere.radius = 1.51f;
        }
    }


}
