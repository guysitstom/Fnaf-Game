using UnityEngine;

public class Lever : MonoBehaviour
{
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
        
    }
    private void OnMouseDown()
    {
        leverState = !leverState;
        ventState = !ventState;
        _animator.SetBool("leverState", leverState);
        vent_anim.SetBool("Vent_state", ventState);
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




