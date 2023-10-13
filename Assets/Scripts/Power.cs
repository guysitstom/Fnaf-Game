using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public static Power Instance { get; private set; }

    float PowerSink = 0.025f;

    public Powered[] PoweredObjects;

    public Text PowerText;

    public float Charge { get; private set; }
    void Start()
    {
        Instance= this;
        Charge= 100f;
        PoweredObjects = FindObjectsOfType<Powered>();
    }
    private void OnGUI()
    {
        GUILayout.Label(Charge.ToString());
        GUILayout.Label(PowerSink.ToString());

       
        int  decimalVal = Convert.ToInt32(Charge);

        PowerText.text = decimalVal.ToString() + "%";

    }
    // Update is called once per frame
    void Update()
    {
        Charge -= PowerSink * Time.deltaTime;
        if (Charge <= 0.0f) 
        {
            Charge= 0.0f;

            foreach (var poweredItem in PoweredObjects)
            {
                poweredItem.OnPowerOutage();
            }
            this.enabled= false;
        }
    }

    public void UsePower(Powered poweredObject)
    {
        PowerSink += poweredObject.wattage;
    }
    public void Releasepower(Powered poweredObject) 
    {
        PowerSink -= poweredObject.wattage;
    }
}
