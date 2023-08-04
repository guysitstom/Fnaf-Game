using UnityEngine;

public class Button : MonoBehaviour 
{
    
    Animator _animator;
    public Animator door_anim;
    AudioSource _audioSource;
    public AudioSource door_audioSource;
    public AudioClip[] sound;
    public bool buttState;
    public bool doorState;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        buttState = !buttState;
        doorState= !doorState;
        if (doorState)
        {
            DoorClose();
        }
        else
        {
            DoorOpen();
        }
        door_anim.SetBool("Door_state", doorState);
        _animator.SetBool("buttState", buttState);
       
        
    }
    public void ButtonSound()
    {
        _audioSource.clip = sound[0];
        _audioSource.Play();
    }
    public void DoorOpen()
    {
        door_audioSource.clip = sound[1];
        door_audioSource.Play();
    }
    public void DoorClose()
    {
        door_audioSource.clip = sound[2];
        door_audioSource.Play();
    }

}
