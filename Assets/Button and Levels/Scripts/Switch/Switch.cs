using UnityEngine;
using UnityEngine.Rendering;

public class Switch : MonoBehaviour
{
    Animator _animator;
    public LightFlicker lights;
    AudioSource _audioSource;
    public bool switchState;
    public AudioClip[] sound;
   
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
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
        lights.LightFlickerOn = true;
    }

    public void SwitchOffSound()
    {
        _audioSource.clip = sound[1];
        _audioSource.Play();                   
         lights.LightFlickerOn = false;
    }

}
