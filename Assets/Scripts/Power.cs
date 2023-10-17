using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public static Power Instance { get; private set; }

    float PowerSink = 0.04f;

    public Powered[] PoweredObjects;

    public Text PowerText;
    public Sprite[] battery;
    public Image image;
    public GameObject mark;
    public GameObject UI;

    public float Charge { get; private set; }
    void Start()
    {
        Instance= this;
        Charge= 100f;
        PoweredObjects = FindObjectsOfType<Powered>();
    }
    private void OnGUI()
    {
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
            UI.SetActive(false);
            this.enabled= false;
        }
        if (PowerSink > 0.035f & PowerSink < 0.045f)
        {
            image.sprite = battery[0];
            mark.SetActive(false);
        }
        else if (PowerSink > 0.35f & PowerSink < 0.45f)
        {
            image.sprite = battery[1];
            mark.SetActive(false);
        }
        else if(PowerSink > 0.75f & PowerSink < 0.85) 
        {
            image.sprite = battery[2];
            mark.SetActive(false);
        }
        else if (PowerSink > 1.15f & PowerSink < 1.25)
        {
            image.sprite = battery[3];
            mark.SetActive(false);
        }
        else if (PowerSink > 1.55f & PowerSink < 1.65)
        {
            mark.SetActive(true);
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
