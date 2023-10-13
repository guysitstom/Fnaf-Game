using UnityEngine;

public class Lever : Powered
{
    public Zombie_1_Movement2 zom;
    public bool open;
    Animator _animator;
    public Animator vent_anim;
    AudioSource _audioSource;
    public AudioClip[] sound;
    public bool leverState;
    public bool ventState;
    public GameObject vent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        zom.Open = open;
        wattage = 0.1f;
        
    }
    private void OnMouseDown()
    {
        leverState = !leverState;
        ventState = !ventState;
        open= !open; 
        _animator.SetBool("leverState", leverState);
        vent_anim.SetBool("Vent_state", ventState);
        zom.Open = open;
        if (vent.activeInHierarchy)
        {
            if(zom.Open)
            {
                Power.Instance.Releasepower(this);
            }
            else
            {
                Power.Instance.UsePower(this);
            }
            
        }
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

    public override void OnPowerOutage()
    {
        vent.SetActive(false);
    }
}




