using Unity.VisualScripting;
using UnityEngine;

public class Button : Powered 
{

    [SerializeField] private bool right;
    public Zombie_1_Movement zom;
    public Zombie_1_Movement1 zom2;
    Animator _animator;
    public Animator door_anim;
    AudioSource _audioSource;
    public AudioSource door_audioSource;
    public AudioClip[] sound;
    public bool buttState;
    public bool doorState;
    public GameObject door;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        wattage = 0.4f;
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
        if (right)
        {
            zom.Open = true;
            Power.Instance.Releasepower(this);
        }
        else { 
            zom2.Open = true;
            Power.Instance.Releasepower(this);
        }
    }
    public void DoorClose()
    {
        door_audioSource.clip = sound[2];
        door_audioSource.Play();
        if (right)
        {
            zom.Open = false;
            Power.Instance.UsePower(this);
        }
        else 
        { zom2.Open = false; Power.Instance.UsePower(this); }
    }

    public override void OnPowerOutage()
    {
        door.SetActive(false);
        zom.Open = true;
        zom2.Open = true;
    }
}

