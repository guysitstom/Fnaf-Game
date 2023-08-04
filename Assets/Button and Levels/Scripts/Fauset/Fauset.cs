using UnityEngine;

public class Fauset : MonoBehaviour
{
    Animator _animator;
    AudioSource _audioSource;
    public AudioClip sound;
    public bool fausetState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        fausetState = !fausetState;
        _animator.SetBool("fausetState", fausetState);
    }
    public void FausetSound()
    {
        _audioSource.clip = sound;
        _audioSource.Play();
    }
}
