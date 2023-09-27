using UnityEngine;

public class Lever : MonoBehaviour
{
    Zombie_1_Movement2 zom;
    public bool open;
    Animator _animator;
    public Animator vent_anim;
    AudioSource _audioSource;
    public AudioClip[] sound;
    public bool leverState;
    public bool ventState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        zom.Open = open;
        
    }
    private void OnMouseDown()
    {
        leverState = !leverState;
        ventState = !ventState;
        open= !open; 
        _animator.SetBool("leverState", leverState);
        vent_anim.SetBool("Vent_state", ventState);
        zom.Open = open;
    }
    public void LeverOnSound()
    {
        _audioSource.clip = sound[0];
        _audioSource.Play();
    }

    public void LeverOffSound()
    {
        _audioSource.clip = sound[1];
        _audioSource.Play();
    }
}




