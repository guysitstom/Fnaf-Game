 using UnityEngine;
 using System.Collections;
 
 public class LightFlicker : MonoBehaviour
 {
     public bool LightFlickerOn;
     public float maximumDim;
     public float maximumBoost;
     public float speed;
     public float strength;
     private Light source;
     private float initialIntensity;
    bool finished;
 
     public void Reset()
     {
         maximumDim = 0.2f;
         maximumBoost = 0.2f;
         speed = 0.1f;
         strength = 250;
     }
 
     public void Awake()
     {
         source = GetComponent<Light>();
         initialIntensity = source.intensity;
         StartCoroutine(Flicker());
     }
    private void Update()
    {
        if (finished && LightFlickerOn)
        {
            StartCoroutine(Flicker());
        }
        if(LightFlickerOn == false)
        {
            source.intensity = 0;
        }
    }



    private IEnumerator Flicker()
     {
            
                finished = false;
                source.intensity = Mathf.Lerp(source.intensity, Random.Range(initialIntensity - maximumDim, initialIntensity + maximumBoost), strength * Time.deltaTime);
                yield return new WaitForSeconds(speed);
                finished = true;
                           
         
     }
 }



