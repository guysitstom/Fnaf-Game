using UnityEngine;
using UnityEngine.Rendering;

public class Switch : Powered
{
    Animator _animator;
    public LightFlicker lights;
    public GameObject light;
    AudioSource _audioSource;
    public bool switchState;
    public AudioClip[] sound;
   
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        wattage = 0.1f;
    }
    private void OnMouseDown()
    {
        switchState = !switchState;
        _animator.SetBool("switchState", switchState);
    }
    public void SwitchOnSound()
    {
        _audioSource.clip = sound[0];
        _audioSource.Play();
        if (light.activeInHierarchy)
        {
            Power.Instance.UsePower(this);
            lights.LightFlickerOn = true;
        }
        
    }

    public void SwitchOffSound()
    {
        _audioSource.clip = sound[1];
        _audioSource.Play();
        if (light.activeInHierarchy)
        {
            Power.Instance.Releasepower(this);
            lights.LightFlickerOn = false;
        }
    }

    public override void OnPowerOutage()
    {
        light.SetActive(false);
    }
}
